using PatasSolidaras.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.RegisterInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
        app.UseSwagger();

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}