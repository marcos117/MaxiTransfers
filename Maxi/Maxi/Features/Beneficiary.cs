
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Maxi.Features;

[ApiController]
[Route("api/[controller]")]
public class Beneficiary : ControllerBase
{
    [HttpPost("add")]
    public void AddBeneficiary()
    {
        
    }
    
    [HttpPut("update")]
    public void UpdateBeneficiary()
    {
        
    }
    
    [HttpDelete("remove")]
    public void RemoveBeneficiary()
    {
        
    }
}