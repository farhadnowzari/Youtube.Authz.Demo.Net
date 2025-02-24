using System.Text.Json.Serialization;
using Keycloak.Authz.Net;
using Keycloak.Authz.Net.Resources;
using Youtube.Domain.Database;
using Youtube.Domain.Repositories;
using Youtube.Service;
using Youtube.Service.GraphQL;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services
    .AddKeycloakAuthz(configure => builder.Configuration.GetSection("Authz").Bind(configure))
    .AddAuthzResources();
builder.Services.AddRepositories();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(configure => configure.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddSwaggerGen();
builder.Services.AddAppGraphQL();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthentication();
app.MapControllers();
app.MapGraphQL();

app.Run();