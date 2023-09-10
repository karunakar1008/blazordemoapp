using EmployeeManagement.Models.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models;

// Employee class

public class Employee
{
    public int EmployeeId { get; set; }
    [Required(ErrorMessage = "FirstName is mandatory")]
    [StringLength(100, MinimumLength = 2)]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [EmailDomainValidator(AllowedDomain = "kpmg.com")]
    public string Email { get; set; }

    [CompareProperty("Email",
        ErrorMessage = "Email and Confirm Email must match")]
    public string ConfirmEmail { get; set; }=string.Empty;

    public DateTime DateOfBrith { get; set; }
    public Gender Gender { get; set; }

    [ValidateComplexType]
    public Department Department { get; set; }
    public int DepartmentId { get; set; }
    public string PhotoPath { get; set; }
}

