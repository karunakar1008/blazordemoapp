using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorServerApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            System.Threading.Thread.Sleep(4000);
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        }
        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
        }
        public async Task<Employee> UpdateEmployee(int id,Employee updatedEmployee)
        {
            //return await httpClient.PutJsonAsync<Employee>("api/employees", updatedEmployee);
            var response= await httpClient.PutAsJsonAsync<Employee>($"api/employees/{id}", updatedEmployee);
            return updatedEmployee;
        }
        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            var response = await httpClient.PostAsJsonAsync<Employee>("api/employees", newEmployee);
            return newEmployee;
        }
        public async Task DeleteEmployee(int id)
        {
            await httpClient.DeleteAsync($"api/employees/{id}");
        }
    }
}
