using BethanyPieShopsHRM.App.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace BethanyPieShopsHRM.App.Pages
{
    public partial class EmployeeEdit
    {

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        public ICountryDataService CountryDataService { get; set; }
        [Inject]
        public IJobCategoryDataService JobCategoryDataService { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Employee Employee { get; set; } = new Employee();
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

        protected string CountryId = string.Empty;

        protected string JobCategoryId = string.Empty;

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        public bool d=false;
        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            Countries = (await CountryDataService.GetAllCountries()).ToList();
            //Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();

            int.TryParse(EmployeeId, out var employeeId);

            if (employeeId == 0) //new employee is being created
            {
                //add some defaults
                Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
            }
            else
            {
                Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            }

            CountryId = Employee.CountryId.ToString();
            JobCategoryId = Employee.JobCategoryId.ToString();
        }
        private IBrowserFile selectedFile;
        private long maxAllowedSize=3840 * 1500;

        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
           
            StateHasChanged();
        }
        protected async Task HandleValidSubmit()
        { bool r = false;
            Saved = false;
            Employee.CountryId = int.Parse(CountryId);
            Employee.JobCategoryId = int.Parse(JobCategoryId);

            if (Employee.EmployeeId == 0) //new
            {
                if (selectedFile != null)//take first image
                {
                    var file = selectedFile;
                    Stream stream = file.OpenReadStream(maxAllowedSize);
                    MemoryStream ms = new();
                    await stream.CopyToAsync(ms);
                    stream.Close();

                    Employee.ImageName = file.Name;
                    Employee.ImageContent = ms.ToArray();
                }
                var addedEmployee = await EmployeeDataService.AddEmployee(Employee);
                if (addedEmployee != null)
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully.";
                    Saved = true;
                    var timer = new System.Threading.Timer(x => NavigateToOverview(), null, 2000, System.Threading.Timeout.Infinite);
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new employee. Please try again.";
                    Saved = false;
                    var timer = new System.Threading.Timer(x => NavigateToOverview(), null, 2000, System.Threading.Timeout.Infinite);
                }
            }
            else
            {
                if (selectedFile != null)//take first image
                {
                    var file = selectedFile;
                    Stream stream = file.OpenReadStream(maxAllowedSize);
                    MemoryStream ms = new();
                    await stream.CopyToAsync(ms);
                    stream.Close();

                    Employee.ImageName = file.Name;
                    Employee.ImageContent = ms.ToArray();
                    
                }
                
                await EmployeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success";
                Message = "Employee updated successfully.";
                Saved = true;
                var timer = new System.Threading.Timer(x => NavigateToOverview(), null, 1000, System.Threading.Timeout.Infinite);


            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }
        protected async Task DeleteEmployee()
        {
            await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
            var timer = new System.Threading.Timer(x => NavigateToOverview(), null, 2000, System.Threading.Timeout.Infinite);
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }

    }

}
