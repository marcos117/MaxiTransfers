using System.ComponentModel.DataAnnotations;

namespace Maxi.Features.Models;

public record EmployeeDto
{
    [Key]
    // Add Id for Beneficiary
    public int EmployeeNumber { get; set; }
    public string Name { get; set; }  = string.Empty;
    public string LastName { get; set; }  = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public string Curp { get; set; }  = string.Empty;
    public int Ssn { get; set; }
    public string Phone { get; set; }  = string.Empty;
    public string Nacionality { get; set; }  = string.Empty;
}