using MediatR;
using Microsoft.AspNetCore.Mvc;
using Youtube.Service.Commands;
using Youtube.Service.Database.Entities;

namespace Youtube.Service.Controllers;

[ApiController]
[Route("professors")]
public class ProfessorsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<Professor> Create(CreateProfessorCommand request) => await mediator.Send(request);
}