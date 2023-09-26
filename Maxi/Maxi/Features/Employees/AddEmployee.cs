using Data.Infrastructure;
using Data.Models;
using MediatR;

namespace Maxi.Features.Employees;

public class AddEmployee
{
    public class RequestE : IRequest<ResponseE>
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
    
    public class Add : IRequestHandler<RequestE, ResponseE>
    {
        public async Task<ResponseE> Handle(RequestE requestE, CancellationToken cancellationToken)
        {
            using (var context = new DataBaseContext())
            {
                var request = new EmployeeDto()
                {
                    Nationality = requestE.Nationality,
                    Name = requestE.Name,
                    Phone = requestE.Phone,
                    EmployeeNumber = requestE.EmployeeNumber,
                    LastName = requestE.LastName,
                    Ssn = requestE.Ssn,
                    Curp = requestE.Curp,
                    DateOfBirth = requestE.DateOfBirth
                };
                context.Add(request);
                await context.SaveChangesAsync(cancellationToken);
            }

            return new ResponseE();
        }
    }

    public class ResponseE
    {
    
    }
}

