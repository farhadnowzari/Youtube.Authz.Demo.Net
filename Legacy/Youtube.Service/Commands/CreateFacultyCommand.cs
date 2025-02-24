using MediatR;
using Youtube.Service.Database;
using Youtube.Service.Database.Entities;

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

public class CreateFacultyCommandHandler(ApplicationDbContext dbContext) : IRequestHandler<CreateFacultyCommand, Faculty>
{
    public Task<Faculty> Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
    {
        var faculty = new Faculty
        {
            Name = request.Name,
            ManagerId = request.ManagerId,
            Courses = []
        };
        if (request.Courses.Any())
        {
            faculty.Courses.AddRange(request.Courses.Select(c => new Course
            {
                Name = c.Name,
            }));
        }
        dbContext.Faculties.Add(faculty);
        dbContext.SaveChanges();

        return Task.FromResult(faculty);
    }
}