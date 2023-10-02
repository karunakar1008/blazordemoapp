using EmployeeManagement.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

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
        public async Task<Employee> UpdateEmployee(int id, Employee updatedEmployee)
        {
            //return await httpClient.PutJsonAsync<Employee>("api/employees", updatedEmployee);
            var response = await httpClient.PutAsJsonAsync<Employee>($"api/employees/{id}", updatedEmployee);
            return updatedEmployee;
        }
        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            //string json = JsonConvert.SerializeObject(newEmployee);   //using Newtonsoft.Json
            //StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            //var response = await httpClient.PostAsync($"api/employees/", httpContent);
            var result= await httpClient.PostAsJsonAsync<Employee>("api/employees", newEmployee);
            return newEmployee;
        }
        public async Task DeleteEmployee(int id)
        {
            await httpClient.DeleteAsync($"api/employees/{id}");
        }
    }
}
