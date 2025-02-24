using MediatR;
using Microsoft.AspNetCore.Mvc;
using Youtube.Service.Commands;
using Youtube.Domain.Database.Entities;

namespace Youtube.Service.Controllers;

[ApiController]
[Route("students")]
public class StudentsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<Student> Create(CreateStudentCommand request) => await mediator.Send(request);
}