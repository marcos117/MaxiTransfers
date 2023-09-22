using MediatR;

namespace Maxi.Features.Employees;

public class AddEmployee
{
    public class Request : IRequest<Response>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public int EmployeeNumber { get; set; }
        public string CURP { get; set; }
        public int SSN { get; set; }
        public string Phone { get; set; }
        public string Nacionality { get; set; }
    }
    
    public class Add : IRequestHandler<Request, Response>
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

