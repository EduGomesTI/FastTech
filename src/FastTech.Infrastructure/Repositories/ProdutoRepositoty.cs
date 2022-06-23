using FastTech.Domain.Entities;
using FastTech.Domain.Interfaces.Repositories;

namespace FastTech.Infrastructure.Repositories;

public class ProdutoRepositoty : IProdutoRepository
{
    public ProdutoRepositoty()
    {
    }

    public async Task<IEnumerable<Produto>> BuscarTodos()
    {
        return await Task.FromResult(new List<Produto>());
    }
}
