
using Maxi.Features.Beneficiaries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maxi.Features;

[ApiController]
[Route("api/[controller]")]
public class Beneficiary : ControllerBase
{
    private readonly IMediator _mediator;
    public Beneficiary(IMediator mediator) => _mediator = mediator;
    
    [HttpPost("add")]
    public async Task<ActionResult> AddBeneficiary([FromBody] AddBeneficiary.RequestB requestB)
    {
        await _mediator.Send(requestB);
        return Ok("Success");
    }
    
    [HttpPut("update")]
    public async Task<ActionResult> UpdateBeneficiary([FromBody] UpdateBeneficiary.RequestBu requestBU)
    {
        await _mediator.Send(requestBU);
        return Ok("Success");
    }
    
    [HttpDelete("remove/{employeeNumber:int}")]
    public async Task<ActionResult> RemoveBeneficiary(int employeeNumber, [FromBody] RemoveBeneficiary.RequestBr request)
    {

        var info = new RemoveBeneficiary.RequestBr { EmployeeNumber = employeeNumber, BeneficiaryId  = request.BeneficiaryId };
        var remove = await _mediator.Send(info);
        return Ok();
    }
}