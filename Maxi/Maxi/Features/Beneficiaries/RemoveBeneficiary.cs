using MediatR;

namespace Maxi.Features.Beneficiaries;

public class RemoveBeneficiary
{
    public class Request : IRequest<Response>
    {
        public int EmployeeNumber { get; set; }
        public string BeneficiaryName { get; set; }
    }
    
    public class Remove : IRequestHandler<Request, Response>
    {
        public Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class Response
    {
    
    }
}