using Maxi.Features.Models;
using Microsoft.EntityFrameworkCore;

namespace Maxi.Infrastructure;

public class DataBaseContext : DbContext
{
    public DbSet<EmployeeDto> EmployeeData { get; set; }
    public DbSet<BeneficiaryDto> BeneficiaryData { get; set; }

    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions
        <DataBaseContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=NAG6CHANDRVAR01; initial catalog=Maxi;integrated security=true;");
    }
}