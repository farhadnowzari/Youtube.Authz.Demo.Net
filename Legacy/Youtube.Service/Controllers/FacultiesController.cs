using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Youtube.Service.Commands;
using Youtube.Service.Database.Entities;

namespace Youtube.Service.Controllers;

[ApiController]
[Route("faculties")]
public class FacultiesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<Faculty> Create(CreateFacultyCommand request) => await mediator.Send(request);
}