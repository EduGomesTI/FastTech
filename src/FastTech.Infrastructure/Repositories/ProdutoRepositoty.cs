namespace FastTech.Infrastructure.Repositories;

public class ProdutoRepositoty : IProdutoRepository
{
    public async Task<IEnumerable<Produto>> BuscarTodos()
    {
        return await Task.FromResult(new List<Produto>());
    }
}
{

}
