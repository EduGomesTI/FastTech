using FastTech.Domain.Entities;

namespace FastTech.Domain.Interfaces.Repositories;

internal interface IProdutoRepository
{
    Task<IEnumerable<Produto>> BuscarTodos();
}
