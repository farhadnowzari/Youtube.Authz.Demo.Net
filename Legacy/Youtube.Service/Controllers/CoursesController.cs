using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Youtube.Service.Commands;
using Youtube.Service.Database.Entities;

namespace Youtube.Service.Controllers;

[ApiController]
[Route("courses")]
public class CoursesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<Course> Create(CreateCourseCommand request) => await mediator.Send(request);
}