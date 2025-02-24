using MediatR;
using Youtube.Domain.Database;
using Youtube.Domain.Database.Entities;

namespace Youtube.Service.Commands;

public class CreateEmployeeCommand : PersonBaseInput, IRequest<Employee>;


public class CreateEmployeeCommandHandler(ApplicationDbContext dbContext) : IRequestHandler<CreateEmployeeCommand, Employee>
{
    public Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            Title = request.Title,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        dbContext.Employees.Add(employee);
        dbContext.SaveChanges();

        return Task.FromResult(employee);
    }
}