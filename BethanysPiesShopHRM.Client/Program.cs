using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BethanyPieShopsHRM.App.Services;
using Microsoft.AspNetCore.Components;


namespace BethanysPieShopHRM.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<BethanyPieShopsHRM.App.App>("#app");
            
            builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client => client.BaseAddress = new Uri("https://localhost:44340"));
            builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(client => client.BaseAddress = new Uri("https://localhost:44340"));
            builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(client => client.BaseAddress = new Uri("https://localhost:44340"));

            await builder.Build().RunAsync();
        }
    }
}
