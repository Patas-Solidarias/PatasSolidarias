using Microsoft.EntityFrameworkCore;
using PatasSolidarias.Domain.Entities;

namespace PatasSolidaras.Infra.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        AddUsuarioModelConfiguration(builder);
        AddUsuarioTipoConfiguration(builder);
    }

    private void AddUsuarioTipoConfiguration(ModelBuilder builder)
    {
        builder.Entity<UsuarioTipo>(p =>
        {
            p.ToTable("UsuarioTipo");
            p.HasKey(pS => pS.Id);
            p.Property(pS => pS.Nome).IsRequired().HasMaxLength(100);
            p.HasData(UsuarioTipo.UsuarioTipos); // Cria o enum no banco de dados
        });
    }

    private static void AddUsuarioModelConfiguration(ModelBuilder builder)
    {
        builder.Entity<Usuario>(p =>
        {
            p.ToTable("Usuario");
            p.HasKey(pS => pS.Id);
            p.Property(pS => pS.Id).ValueGeneratedOnAdd();
            p.Property(pS => pS.Nome).IsRequired().HasMaxLength(100);
            p.Property(pS => pS.Email).IsRequired().HasMaxLength(100);
            p.Property(pS => pS.Senha).IsRequired().HasMaxLength(100);
            p.Property(pS => pS.CriadoDataHora).IsRequired();
            p.Property(pS => pS.Descricao).IsRequired().HasMaxLength(500);
            p.Property(pS => pS.UsuarioTipoId).IsRequired().HasMaxLength(15);
            
            p.HasOne(pS => pS.UsuarioTipo)
                .WithMany()
                .HasForeignKey(pS => pS.UsuarioTipoId)
                .OnDelete(DeleteBehavior.NoAction)
            ;
        });
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioTipo> UsuarioTipos { get; set; }
}