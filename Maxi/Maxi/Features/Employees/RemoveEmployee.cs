using MediatR;

namespace Maxi.Features.Employees;

public class RemoveEmployee
{
    public class Request : IRequest<Response>
    {
        public int EmployeeNumber { get; set; }
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