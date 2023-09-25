using Maxi.Features.Beneficiaries;
using Maxi.Features.Models;
using Maxi.Infrastructure;
using MediatR;

namespace Maxi.Features.Employees;

public class RemoveEmployee
{
    public class RequestEr : IRequest<ResponseEr>
    {
        public int EmployeeNumber { get; init; }
    }
    
    public class Remove : IRequestHandler<RequestEr, ResponseEr>
    {
        public async Task<ResponseEr> Handle(RequestEr requestEr, CancellationToken cancellationToken)
        {
            await using (var context = new DataBaseContext())
            {
                var request = new EmployeeDto()
                {
                    EmployeeNumber = requestEr.EmployeeNumber,
                };
                context.Remove(request);
                await context.SaveChangesAsync(cancellationToken);
            }

            return new ResponseEr();
        }
    }

    public class ResponseEr
    {
    
    }
}