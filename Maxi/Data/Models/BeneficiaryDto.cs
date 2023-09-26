using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public record BeneficiaryDto
{
    [Key]
    // Add Id for Beneficiary
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; }  = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Curp { get; set; }  = string.Empty;
    public int Ssn { get; set; }
    public string Phone { get; set; }  = string.Empty;
    public string Nationality { get; set; }  = string.Empty;
    public int ParticipationPercentage { get; set; }
};