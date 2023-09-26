using Data.Infrastructure;
using Data.Models;
using MediatR;

namespace Maxi.Features.Employees;

public class UpdateEmployee
{
    public class RequestEu : IRequest<ResponseEu>
    {
        public string Name { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public DateTime DateOfBirth { get; init; } = DateTime.MaxValue;
        public int EmployeeNumber { get; init; }
        public string Curp { get; init; } = string.Empty;
        public int Ssn { get; init; }
        public string Phone { get; init; } = string.Empty;
        public string Nationality { get; init; } = string.Empty;
    }

    public class Update : IRequestHandler<RequestEu, ResponseEu>
    {
        public async Task<ResponseEu> Handle(RequestEu requestEu, CancellationToken cancellationToken)
        {
            await using (var context = new DataBaseContext())
            {
                var request = new EmployeeDto()
                {
                    Nationality = requestEu.Nationality,
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