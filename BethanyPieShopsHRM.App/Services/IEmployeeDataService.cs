using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components.Forms;
namespace BethanyPieShopsHRM.App.Services
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeDetails(int employeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
        Task<IEnumerable<Employee>> GetLongEmployeeList();
        Task<IEnumerable<Employee>> GetTakeLongEmployeeList(int startIndex, int count);
    }
}
