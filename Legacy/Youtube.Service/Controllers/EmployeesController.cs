using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Youtube.Service.Commands;
using Youtube.Service.Database.Entities;

namespace Youtube.Service.Controllers;

[ApiController]
[Route("employees")]
[Authorize(Roles = "manager")]
public class EmployeesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<Employee> Create(CreateEmployeeCommand request) => await mediator.Send(request);
}