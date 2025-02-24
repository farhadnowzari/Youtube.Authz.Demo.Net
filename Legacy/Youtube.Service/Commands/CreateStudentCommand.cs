using MediatR;
using Youtube.Service.Database;
using Youtube.Service.Database.Entities;

namespace Youtube.Service.Commands;

public class CreateStudentCommand : PersonBaseInput, IRequest<Student>;

public class CreateStudentCommandHandler(ApplicationDbContext dbContext) : IRequestHandler<CreateStudentCommand, Student>
{
    public Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = new Student
        {
            Title = request.Title,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        dbContext.Students.Add(student);
        dbContext.SaveChanges();

        return Task.FromResult(student);
    }
}