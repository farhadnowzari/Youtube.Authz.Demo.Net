using MediatR;
using Microsoft.AspNetCore.Mvc;
using Youtube.Service.Commands;
using Youtube.Domain.Database.Entities;
using Keycloak.Authz.Net.Attributes;

namespace Youtube.Service.Controllers;

[ApiController]
[Route("faculties")]
public class FacultiesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Authz(["faculty#create"])]
    public async Task<Faculty> Create(CreateFacultyCommand request) => await mediator.Send(request);

    [HttpPost("{facultyId}/courses")]
    [Authz(["faculty:{facultyId}#create:course"])]
    public async Task<Course> CreateCourse([FromRoute] string facultyId, CreateCourseCommand request)
    {
        request.FacultyId = Guid.Parse(facultyId);
        return await mediator.Send(request);
    }
}