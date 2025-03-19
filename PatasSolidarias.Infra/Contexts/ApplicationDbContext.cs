using Microsoft.EntityFrameworkCore;

namespace PatasSolidaras.Infra.Contexts;

public class ApplicationDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}