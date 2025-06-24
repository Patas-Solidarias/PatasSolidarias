using Microsoft.EntityFrameworkCore;
using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Entities.Campanha;
using PatasSolidarias.Domain.Entities.Doacoes;

namespace PatasSolidaras.Infra.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        AddUsuarioModelConfiguration(builder);
        AddUsuarioTipoConfiguration(builder);
        AddDoacaoModelConfiguration(builder);
        AddCampanhaModelConfiguration(builder);
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
                .OnDelete(DeleteBehavior.NoAction);

            p.HasMany(pS => pS.Doacoes)
                .WithOne()
                .HasForeignKey(dS => dS.IdDoador);
        });
    }

    private static void AddDoacaoModelConfiguration(ModelBuilder builder)
    {
        builder.Entity<Doacao>(d =>
        {
            d.ToTable("Doação");
            d.HasKey(pS => pS.Id);
            d.Property(pS => pS.Id).ValueGeneratedOnAdd();
            d.Property(pS => pS.Valor).IsRequired();
            d.Property(pS => pS.MetodoPagamento).IsRequired();
        });
    }

    private static void AddCampanhaModelConfiguration(ModelBuilder builder)
    {
        builder.Entity<Campanha>(c =>
        {
            c.HasOne(pS => pS.OngUsuario)
                .WithMany()
                .HasForeignKey(p => p.OngUsuarioId);
                
             c.HasMany(pS => pS.Doacoes)
                .WithOne()
                .HasForeignKey(dS => dS.IdCampanha);
        });
    }

    private static void AddImagemEmCampanha(ModelBuilder builder)
    {
        builder.Entity<ImagemEmCampanha>(i =>
        {
            i.ToTable("ImagemEmCampanha");
            i.HasKey(pS => pS.Id);
            i.Property(pS => pS.Id).ValueGeneratedOnAdd();
            i.Property(pS => pS.Imagem).IsRequired().HasMaxLength(500);
            i.Property(pS => pS.CampanhaId).IsRequired();

            i.HasOne(pS => pS.Campanha)
                .WithMany(c => c.Imagens)
                .HasForeignKey(pS => pS.CampanhaId);
        });
    }
    

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioTipo> UsuarioTipos { get; set; }
    public DbSet<Doacao> Doacoes { get; private set; } = null!;
    public DbSet<Campanha> Campanhas { get; private set; } = null!;
}