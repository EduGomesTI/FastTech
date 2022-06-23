using FastTech.Domain.Common;
using FastTech.Domain.Enums;

namespace FastTech.Domain.Entities;

public class Pedido : Entity
{
    #region Propriedades
    private readonly List<PedidoItem>? _pedidoItens;

    public DateTime Cadastro { get; private set; }
    public decimal ValorTotal { get; private set; }
    public StatusPedido Status { get; private set; }
    public IReadOnlyCollection<PedidoItem>? PedidoItens => (IReadOnlyCollection<PedidoItem>?)_pedidoItens;

    #endregion

    #region Construtores

    public Pedido()
    {
        _pedidoItens = new List<PedidoItem>();
        Cadastro = DateTime.UtcNow;
        Status = StatusPedido.Novo;
    }

    #endregion

    public void AdicionarItemNoPedido(PedidoItem pedidoItem)
    {
        var item = pedidoItem;

        item.VincularPedido(Id);

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
            throw new DomainException("Item de pedido não encontrado.");
        }
        _pedidoItens?.Remove(itemEncontrado);

        CalcularValorTotal();
    }

    public void AtualizarQuantidadeItem(PedidoItem pedidoItem, int novaQuantidade)
    {
        if (ExistePedidoItem(pedidoItem) is var itemEncontrado && itemEncontrado is null)
        {
            throw new DomainException("Item de pedido não encontrado.");
        }

        itemEncontrado.AtualizarQuantidade(novaQuantidade);

        CalcularValorTotal();
    }

    public void AguardarPagamento()
    {
        Status = StatusPedido.AguardandoPagamento;
    }

    public void ConcluirPedido()
    {
        Status = StatusPedido.Concluido;
    }

    public void CalcularValorTotal()
    {
        if (_pedidoItens != null) ValorTotal = _pedidoItens.Sum(x => x.CalcularValor());
    }

    private PedidoItem? ExistePedidoItem(PedidoItem pedidoItem) =>
        _pedidoItens?.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId);

    protected override void Validar()
    {
        if (Cadastro < DateTime.UtcNow)
        {
            throw new DomainException("Data de cadastro inválida");
        }
    }
}
