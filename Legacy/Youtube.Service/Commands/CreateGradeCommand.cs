using MediatR;
using Youtube.Service.Database;
using Youtube.Service.Database.Entities;

namespace Youtube.Service.Commands;

public class CreateGradeCommand : IRequest<Grade>
{
    public Guid EnrollmentId { get; set; }
    public float Value { get; set; }
}

public class CreateGradeCommandHandler(ApplicationDbContext dbContext) : IRequestHandler<CreateGradeCommand, Grade>
{
    public Task<Grade> Handle(CreateGradeCommand request, CancellationToken cancellationToken)
    {
        var grade = new Grade
        {
            EnrollmentId = request.EnrollmentId,
            Value = request.Value
        };
        dbContext.Grades.Add(grade);
        dbContext.SaveChanges();

        return Task.FromResult(grade);
    }
}