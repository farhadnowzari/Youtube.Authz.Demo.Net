using MediatR;
using Youtube.Service.Database;
using Youtube.Service.Database.Entities;

namespace Youtube.Service.Commands;

public class CreateEnrollmentCommand : IRequest<Enrollment>
{
    public string CourseId { get; set; }
    public string StudentId { get; set; }
}

public class CreateEnrollmentCommandHandler(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : IRequestHandler<CreateEnrollmentCommand, Enrollment>
{
    public Task<Enrollment> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
    {
        
        var enrollment = new Enrollment
        {
            CourseId = Guid.Parse(request.CourseId),
            StudentId = Guid.Parse(request.StudentId)
        };

        dbContext.Enrollments.Add(enrollment);
        dbContext.SaveChanges();

        return Task.FromResult(enrollment);
    }
}