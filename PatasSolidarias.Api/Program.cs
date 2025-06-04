using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PatasSolidaras.Infra.Extensions;
using PatasSolidarias.Domain.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    // infra
    builder.Services.RegisterInfrastructure(builder.Configuration);
    builder.Services.AddRepositories();
    
    // domain
    builder.Services.AddDomainServices();
    
    // controllers
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(p =>
        {
            p.TokenValidationParameters = new TokenValidationParameters
            {
                ValidAudience = "patas-solidarias",
                IssuerSigningKey = new SymmetricSecurityKey("super-secret-key-1234567890-abcdef"u8.ToArray()) // TODO usar user secrets
            };
        });
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    });
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseCors("AllowAll");
    app.Run();
}