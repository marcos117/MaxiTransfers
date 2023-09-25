using Maxi.Features.Employees;
using Maxi.Features.Models;
using Maxi.Infrastructure;
using MediatR;

namespace Maxi.Features.Beneficiaries;

public class AddBeneficiary
{
    public class RequestB : IRequest<ResponseB>
    {
        public string Name { get; init; }  = string.Empty;
        public string LastName { get; init; }  = string.Empty;
        public DateOnly DateOfBirth { get; init; } = DateOnly.MaxValue;
        public string Curp { get; init; }  = string.Empty;
        public int Ssn { get; init; }
        public string Phone { get; init; }  = string.Empty;
        public string Nacionality { get; init; }  = string.Empty;
        public int ParticipationPercentage { get; init; }
    }
    
    public class Add : IRequestHandler<RequestB, ResponseB>
    {
        public async Task<ResponseB> Handle(RequestB requestB, CancellationToken cancellationToken)
        {
            await using (var context = new DataBaseContext())
            {
                var request = new BeneficiaryDto()
                {
                    Nacionality = requestB.Nacionality,
                    Name = requestB.Name,
                    Phone = requestB.Phone,
                    LastName = requestB.LastName,
                    Ssn = requestB.Ssn,
                    Curp = requestB.Curp,
                    DateOfBirth = requestB.DateOfBirth,
                    ParticipationPercentage = requestB.ParticipationPercentage
                };
                context.Add(request);
                await context.SaveChangesAsync(cancellationToken);
            }

            return new ResponseB();
        }
    }

    public class ResponseB
    {
    
    }
}

