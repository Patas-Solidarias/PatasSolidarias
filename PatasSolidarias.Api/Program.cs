using PatasSolidaras.Infra.Extensions;
using PatasSolidarias.Application.Extensions;
using PatasSolidarias.Domain.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    // infra
    builder.Services.RegisterInfrastructure(builder.Configuration);
    builder.Services.AddRepositories();
    
    // domain
    builder.Services.AddDomainServices();
    
    // application
    builder.Services.AddApplicationServices();
    
    // controllers
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}