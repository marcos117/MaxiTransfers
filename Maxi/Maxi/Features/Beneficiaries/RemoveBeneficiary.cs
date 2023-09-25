using Data.Infrastructure;
using Data.Models;
using MediatR;

namespace Maxi.Features.Beneficiaries;

public class RemoveBeneficiary
{
    public class RequestBr : IRequest<ResponseBR>
    {
        public int EmployeeNumber { get; init; }
        public int BeneficiaryId { get; init; }
    }
    
    public class Remove : IRequestHandler<RequestBr, ResponseBR>
    {
        public async Task<ResponseBR> Handle(RequestBr requestBRr, CancellationToken cancellationToken)
        {
            await using (var context = new DataBaseContext())
            {
                var request = new EmployeeBeneficiaryDto()
                {
                    EmployeeNumber = requestBRr.EmployeeNumber,
                    BeneficiaryId = requestBRr.BeneficiaryId
                };
                context.Remove(request);
                await context.SaveChangesAsync(cancellationToken);
            }

            return new ResponseBR();
        }
    }

    public class ResponseBR
    {
    
    }
}