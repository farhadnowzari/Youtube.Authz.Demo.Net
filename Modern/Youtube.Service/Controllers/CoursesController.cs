using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Youtube.Service.Controllers;

[ApiController]
[Route("courses")]
public class CoursesController(IMediator mediator) : ControllerBase
{
    // [HttpPost]
    // public async Task<Course> Create(CreateCourseCommand request) => await mediator.Send(request);
}