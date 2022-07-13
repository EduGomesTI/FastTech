using FastTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastTech.Infrastructure.Contexts;

public class SqlServerDbContext : DbContext
{
    public DbSet<Produto>? Produtos { get; set; }

    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .LogTo(x => Console.WriteLine(x))
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .DefaultTypeMapping<string>()
            .IsUnicode(false)
            .HasMaxLength(200);

        base.ConfigureConventions(configurationBuilder);
    }
}
