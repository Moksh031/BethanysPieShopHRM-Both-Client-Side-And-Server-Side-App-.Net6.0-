using BethanyPieShopsHRM.App.Services;
using BethanysPieShopHRM.ComponentsLibrary.Map;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanyPieShopsHRM.App.Pages
{
    public partial class EmployeeDetail
    {

        [Parameter]
        public string EmployeeId { get; set; }
      
        public Employee Employee { get; set; } = new Employee();

        public Country Countries { get; set; } = new Country();
        public JobCategory JobCategories { get; set; } = new JobCategory();

        public List<Marker> MapMarkers { get; set; } = new List<Marker>();

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        public IJobCategoryDataService JobCategoryDataService { get; set; }
        [Inject]
        public ICountryDataService CountryDataService { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            JobCategories= await JobCategoryDataService.GetJobCategoryById(Employee.JobCategoryId);
           
           Countries= await CountryDataService.GetCountryById(Employee.CountryId);
            
            MapMarkers = new List<Marker>
            {
                new Marker{Description = $"{Employee.FirstName} {Employee.LastName}",  ShowPopup = true, X = Employee.Longitude, Y = Employee.Latitude}
            };
           
        }

    }
}