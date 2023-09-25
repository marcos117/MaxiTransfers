
using Maxi.Features.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Maxi.Features;

[ApiController]
[Route("api/[controller]")]
public class Employee : ControllerBase
{
    
    private readonly IMediator _mediator;

    public Employee(IMediator mediator) => _mediator = mediator;
    
    
    [HttpPost("add")]
    public async Task<ActionResult> AddEmployee([FromBody] AddEmployee.RequestE requestE)
    {
        await _mediator.Send(requestE);
        return Ok("Success");
    }
    
    [HttpPut("update")]
    public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployee.RequestEu requestEu)
    {
        await _mediator.Send(requestEu);
        return Ok("Success");
    }

    [HttpDelete("remove/{employeeNumber:int}")]
    public async Task<ActionResult> RemoveEmployee(int employeeNumber)
    {
        var request = new RemoveEmployee.RequestEr { EmployeeNumber = employeeNumber};
        var remove = await _mediator.Send(request);
        return Ok();
    }
}