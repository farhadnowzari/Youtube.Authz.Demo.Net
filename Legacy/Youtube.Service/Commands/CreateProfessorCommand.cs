using MediatR;
using Youtube.Service.Database;
using Youtube.Service.Database.Entities;

namespace Youtube.Service.Commands;

public class CreateProfessorCommand : PersonBaseInput, IRequest<Professor>;

public class CreateProfessorCommandHandler(ApplicationDbContext dbContext) : IRequestHandler<CreateProfessorCommand, Professor>
{
    public Task<Professor> Handle(CreateProfessorCommand request, CancellationToken cancellationToken)
    {
        var professor = new Professor
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Title = request.Title,
        };

        dbContext.Professors.Add(professor);
        dbContext.SaveChanges();

        return Task.FromResult(professor);
    }
}
