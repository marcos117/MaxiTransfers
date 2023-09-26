﻿using Data.Infrastructure;
using Data.Models;
using MediatR;

namespace Maxi.Features.Beneficiaries;

public class UpdateBeneficiary
{
    public class RequestBu : IRequest<ResponseBu>
    {
        public string Name { get; init; }  = string.Empty;
        public string LastName { get; init; }  = string.Empty;
        public DateTime DateOfBirth { get; init; } = DateTime.MaxValue;
        public string Curp { get; init; }  = string.Empty;
        public int Ssn { get; init; }
        public string Phone { get; init; }  = string.Empty;
        public string Nationality { get; init; }  = string.Empty;
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
                    Nationality = requestBu.Nationality,
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