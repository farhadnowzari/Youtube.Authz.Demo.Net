using MediatR;
using Youtube.Domain.Database;
using Youtube.Domain.Database.Entities;
using Youtube.Domain.Repositories;

namespace Youtube.Service.Commands;

public class CreateFacultyCommand : IRequest<Faculty>
{
    public string Name { get; init; }
    public Guid? ManagerId { get; init; }
    public IEnumerable<CreateFacultyCourseInput> Courses { get; init; } = [];
}

public record CreateFacultyCourseInput
{
    public string Name { get; init; }
}

public class CreateFacultyCommandHandler(FacultyRepository repository) : IRequestHandler<CreateFacultyCommand, Faculty>
{
    public Task<Faculty> Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
    {
        var faculty = new Faculty
        {
            Name = request.Name,
            ManagerId = request.ManagerId,
            Courses = [..request.Courses.Select(course => new Course
            {
                Name = course.Name
            })]
        };
        repository.Create(faculty);
        return Task.FromResult(faculty);
    }
}