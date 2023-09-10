﻿using EmployeeManagement.Models;

namespace BlazorServerApp.Services;

public class DepartmentService : IDepartmentService
{
    private readonly HttpClient httpClient;

    public DepartmentService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<Department> GetDepartment(int id)
    {
        return await httpClient.GetFromJsonAsync<Department>($"api/departments/{id}");
    }

    public async Task<IEnumerable<Department>> GetDepartments()
    {
        return await httpClient.GetFromJsonAsync<Department[]>("api/departments");
    }
}