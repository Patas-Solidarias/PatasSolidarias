using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PatasSolidaras.Infra.Extensions;
using PatasSolidarias.Backend.Services;
using PatasSolidarias.Domain.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    // configuration
    builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

    // infra
    builder.Services.RegisterInfrastructure(builder.Configuration);
    builder.Services.AddRepositories();
    
    // domain
    builder.Services.AddDomainServices();
    
    // controllers
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(p =>
        {
            var jwtSection = builder.Configuration.GetSection("Jwt");
            var key = jwtSection["Key"];
            var issuer = jwtSection["Issuer"];
            var audience = jwtSection["Audience"];
            p.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key!))
            };
        });
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddScoped<IUser, User>();
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}