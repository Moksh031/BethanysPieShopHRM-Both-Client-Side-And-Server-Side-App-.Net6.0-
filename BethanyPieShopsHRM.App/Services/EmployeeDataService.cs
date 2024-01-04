using BethanyPieShopsHRM.App.Services;
using BethanysPieShopHRM.Shared;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Json;

public class EmployeeDataService : IEmployeeDataService
{
    private readonly HttpClient _httpClient;
    public EmployeeDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<Employee>> GetLongEmployeeList()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>($"api/employee/long");
    }

    public async Task<IEnumerable<Employee>> GetTakeLongEmployeeList(int startIndex, int count)
    {
        return await _httpClient.GetFromJsonAsync<List<Employee>>($"api/employee/long/{startIndex}/{count}");
    }
    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(await _httpClient.GetStreamAsync($"api/employee"), new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        });
    }
    public async Task<Employee> AddEmployee(Employee employee)
    {
        var employeeJson = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("api/employee/", employeeJson);
        if (response.IsSuccessStatusCode)
        {
            return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
        }
        return null;
    }
    public async Task<Employee> GetEmployeeDetails(int employeeId)
    {
        return await JsonSerializer.DeserializeAsync<Employee>(await _httpClient.GetStreamAsync($"api/employee/{employeeId}"), new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        });
    }
    public async Task UpdateEmployee(Employee employee)
    {
        var employeeJson = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");
        await _httpClient.PutAsync($"api/employee/", employeeJson);
    }
    public async Task DeleteEmployee(int employeeId)
    {
        await _httpClient.DeleteAsync($"api/employee/{employeeId}");
    }
}