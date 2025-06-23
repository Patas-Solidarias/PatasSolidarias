using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PatasSolidaras.Infra.Extensions;
using PatasSolidarias.Backend.Configurations;
using PatasSolidarias.Backend.Services;
using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    // configuration
    builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
    builder.Services.AddSingleton<IConfiguracao>(p =>
    {
        var configuration = p.GetRequiredService<IConfiguration>();
        var configuracaoSection = configuration.GetRequiredSection(nameof(Configuracao));
        var configuracao = configuracaoSection.Get<Configuracao>();
        if (configuracao == null)
        {
            throw new ArgumentNullException(nameof(Configuracao), "A configuração não foi encontrada.");
        }
        return configuracao;
    });

    // infra
    builder.Services.RegisterInfrastructure(builder.Configuration);
    builder.Services.AddRepositories();
    
    // domain
    builder.Services.AddDomainServices();

    // auth
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddSingleton<IPasswordHasher<Usuario>, PasswordHashService>();
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(p =>
        {
            var jwtSection = builder.Configuration.GetRequiredSection(nameof(Configuracao))
                .GetRequiredSection(nameof(Configuracao.Jwt))
                .Get<ConfiguracoesJwt>()
            ;

            if (jwtSection == null)
            {
                throw new ArgumentNullException(nameof(ConfiguracoesJwt), "As configurações JWT não foram encontradas.");
            }

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSection.Key));
            p.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSection.Issuer,
                ValidAudience = jwtSection.Audience,
                IssuerSigningKey = key 
            };
        });
    
    // controllers
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddHttpContextAccessor();
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