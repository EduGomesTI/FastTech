using FastTech.Domain.Entities;
using FastTech.Domain.Interfaces.Repositories;
using FastTech.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FastTech.Infrastructure.Repositories;

public class ProdutoRepositoty : IProdutoRepository
{
    private readonly SqlServerDbContext _sqlServerDbContext;

    public ProdutoRepositoty(SqlServerDbContext sqlServerDbContext)
    {
        _sqlServerDbContext = sqlServerDbContext;
    }

    public async Task<IEnumerable<Produto>> BuscarTodosAsync()
    {
        return await _sqlServerDbContext.Produtos
                        .ToListAsync();
    }
}
