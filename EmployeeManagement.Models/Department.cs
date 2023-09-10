using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models;

// Department Class

public class Department
{
    public int DepartmentId { get; set; }
    [Required]
    public string DepartmentName { get; set; }
}