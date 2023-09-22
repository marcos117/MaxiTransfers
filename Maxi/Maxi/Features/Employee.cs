
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
    public async Task<ActionResult> AddEmployee([FromBody] AddEmployee.Request request)
    {
        var add = await _mediator.Send(request);
        return Ok();
    }
    
    [HttpPut("update")]
    public void UpdateEmployee(int employeeNumber)
    {
        
    }

    [HttpDelete("remove/{employeeNumber:int}")]
    public async Task<ActionResult> RemoveEmployee(int employeeNumber)
    {
        var request = new RemoveEmployee.Request { EmployeeNumber = employeeNumber};
        var remove = await _mediator.Send(request);
        return Ok();
    }
}