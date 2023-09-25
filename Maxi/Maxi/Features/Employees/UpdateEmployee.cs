using Maxi.Features.Models;
using Maxi.Infrastructure;
using MediatR;

namespace Maxi.Features.Employees;

public class UpdateEmployee
{
    public class RequestEu : IRequest<ResponseEu>
    {
        public string Name { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public DateOnly DateOfBirth { get; init; } = DateOnly.MaxValue;
        public int EmployeeNumber { get; init; }
        public string Curp { get; init; } = string.Empty;
        public int Ssn { get; init; }
        public string Phone { get; init; } = string.Empty;
        public string Nacionality { get; init; } = string.Empty;
    }
    
    public class Update : IRequestHandler<RequestEu, ResponseEu>
    {
        public async Task<ResponseEu> Handle(RequestEu requestEu, CancellationToken cancellationToken)
        {
            await using (var context = new DataBaseContext())
            {
                var request = new EmployeeDto()
                {
                    Nacionality = requestEu.Nacionality,
                    Name = requestEu.Name,
                    Phone = requestEu.Phone,
                    LastName = requestEu.LastName,
                    Ssn = requestEu.Ssn,
                    Curp = requestEu.Curp,
                    DateOfBirth = requestEu.DateOfBirth
                };
                context.Update(request);
                await context.SaveChangesAsync(cancellationToken);
            }

            return new ResponseEu();
        }
    }

    public class ResponseEu
    {
    
    }
}