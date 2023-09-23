
using Maxi.Features.Beneficiaries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Maxi.Features;

[ApiController]
[Route("api/[controller]")]
public class Beneficiary : ControllerBase
{
    private readonly IMediator _mediator;
    public Beneficiary(IMediator mediator) => _mediator = mediator;
    
    [HttpPost("add")]
    public async Task<ActionResult> AddBeneficiary([FromBody] AddBeneficiary.Request request)
    {
        var add = await _mediator.Send(request);
        return Ok();
    }
    
    [HttpPut("update")]
    public void UpdateBeneficiary()
    {
        
    }
    
    [HttpDelete("remove/{employeeNumber:int}")]
    public async Task<ActionResult> RemoveBeneficiary([FromBody] RemoveBeneficiary.Request request)
    {
        var info = new RemoveBeneficiary.Request { EmployeeNumber = request.EmployeeNumber, BeneficiaryName  = request.BeneficiaryName };
        var remove = await _mediator.Send(info);
        return Ok();
    }
}