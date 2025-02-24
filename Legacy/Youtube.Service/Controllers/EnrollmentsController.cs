using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Youtube.Service.Commands;
using Youtube.Service.Database.Entities;

namespace Youtube.Service.Controllers;

[ApiController]
[Route("enrollments")]
public class EnrollmentsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "manager")]
    public async Task<Enrollment> Create(CreateEnrollmentCommand request) => await mediator.Send(request);
}