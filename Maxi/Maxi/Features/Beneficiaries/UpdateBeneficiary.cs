using Maxi.Features.Models;
using Maxi.Infrastructure;
using MediatR;

namespace Maxi.Features.Beneficiaries;

public class UpdateBeneficiary
{
    public class RequestBu : IRequest<ResponseBu>
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
    
    public class Update : IRequestHandler<RequestBu, ResponseBu>
    {
        public async Task<ResponseBu> Handle(RequestBu requestBu, CancellationToken cancellationToken)
        {
            await using (var context = new DataBaseContext())
            {
                var request = new BeneficiaryDto()
                {
                    Nacionality = requestBu.Nacionality,
                    Name = requestBu.Name,
                    Phone = requestBu.Phone,
                    LastName = requestBu.LastName,
                    Ssn = requestBu.Ssn,
                    Curp = requestBu.Curp,
                    DateOfBirth = requestBu.DateOfBirth,
                    ParticipationPercentage = requestBu.ParticipationPercentage
                };
                context.Update(request);
                await context.SaveChangesAsync(cancellationToken);
            }

            return new ResponseBu();
        }
    }

    public class ResponseBu
    {
    
    }
}