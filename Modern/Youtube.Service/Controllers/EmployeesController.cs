using MediatR;
using Microsoft.AspNetCore.Mvc;
using Youtube.Service.Commands;
using Youtube.Domain.Database.Entities;
using Keycloak.Authz.Net.Attributes;

namespace Youtube.Service.Controllers;

[ApiController]
[Route("employees")]
public class EmployeesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Authz(["employee#create"])]
    public async Task<Employee> Create(CreateEmployeeCommand request) => await mediator.Send(request);
}