using MediatR;
using Youtube.Domain.Database;
using Youtube.Domain.Database.Entities;


namespace Youtube.Service.Commands;

public class CreateCourseCommand : IRequest<Course> {
    public string Name { get; init; }
    public Guid FacultyId { get; set; }
}


public class CreateCourseCommandHandler(ApplicationDbContext dbContext) : IRequestHandler<CreateCourseCommand, Course>
{
    public Task<Course> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = new Course
        {
            Name = request.Name,
            FacultyId = request.FacultyId
        };
        dbContext.Courses.Add(course);
        dbContext.SaveChanges();

        return Task.FromResult(course);
    }
}
