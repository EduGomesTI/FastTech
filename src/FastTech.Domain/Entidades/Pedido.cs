using FastTech.Domain.Enums;

namespace FastTech.Domain.Entidades;

internal class Pedido : Entity
{
    #region Propriedades
    private readonly List<PedidoItem>? _pedidoItens;

    public DateTime Date { get; private set; }
    public decimal ValorTotal { get; private set; }
    public StatusPedido Status { get; private set; }
    public IReadOnlyCollection<PedidoItem>? PedidoItens => (IReadOnlyCollection<PedidoItem>?)_pedidoItens;

    #endregion

    #region Construtores

    public Pedido()
    {
        _pedidoItens = new List<PedidoItem>();
        Date = DateTime.UtcNow;
        Status = StatusPedido.Novo;
    }

    #endregion

    public void AdicionarItemNoPedido(PedidoItem pedidoItem)
    {
        var item = pedidoItem;

        if (ExistePedidoItem(pedidoItem) is var itemEncontrado && itemEncontrado is not null) //Matching Pattern
        {
            item = itemEncontrado;
            item.AdicionarQuantidade(pedidoItem.Quantidade);
        }
        else
        {
            _pedidoItens?.Add(item);
        }

        item.CalcularValor();

        CalcularValorTotal();
    }

    public void RemoverItem(PedidoItem pedidoItem)
    {
        if (ExistePedidoItem(pedidoItem) is var itemEncontrado && itemEncontrado is null)
        {
            throw new ArgumentNullException("Item de pedido não encontrado.");
        }
        _pedidoItens?.Remove(pedidoItem);

        CalcularValorTotal();
    }

    public void CalcularValorTotal()
    {
        if (_pedidoItens != null) ValorTotal = _pedidoItens.Sum(x => x.CalcularValor());
    }

    private PedidoItem? ExistePedidoItem(PedidoItem pedidoItem) =>
        _pedidoItens?.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId);

}
