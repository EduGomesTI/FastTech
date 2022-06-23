using FastTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastTech.Infrastructure.Contexts;

public class SqlServerDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Produto>? Produtos { get; set; }
}
