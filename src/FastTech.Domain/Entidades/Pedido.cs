using FastTech.Domain.Enums;

namespace FastTech.Domain.Entidades;

internal class Pedido : Entity
{
    private IEnumerable<PedidoItem>? _pedidoItens;

    public DateTime Date { get; private set; }
    public decimal ValorTotal { get; private set; }
    public StatusPedido Status { get; private set; }
    public IReadOnlyCollection<PedidoItem>? PedidoItens => (IReadOnlyCollection<PedidoItem>?)_pedidoItens;
}
