namespace Data.Models;

public record EmployeeBeneficiaryDto
{
    // Add FK for Employee
    public int EmployeeNumber { get; set; }
    // Add FK for Beneficiary
    public int BeneficiaryId { get; set; }
};