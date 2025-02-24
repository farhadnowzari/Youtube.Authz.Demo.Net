using MediatR;
using Microsoft.AspNetCore.Mvc;
using Youtube.Service.Commands;
using Youtube.Domain.Database.Entities;

namespace Youtube.Service.Controllers;

[ApiController]
[Route("enrollments")]
public class EnrollmentsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<Enrollment> Create(CreateEnrollmentCommand request) => await mediator.Send(request);
}