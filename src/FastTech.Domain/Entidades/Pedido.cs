﻿using FastTech.Domain.Enums;

namespace FastTech.Domain.Entidades;

internal class Pedido : Entity
{
    private readonly IEnumerable<PedidoItem>? _pedidoItens;    

    public DateTime Date { get; private set; }
    public decimal ValorTotal { get; private set; }
    public StatusPedido Status { get; private set; }
    public IReadOnlyCollection<PedidoItem>? PedidoItens => (IReadOnlyCollection<PedidoItem>?)_pedidoItens;

    public Pedido()
    {
        _pedidoItens = new List<PedidoItem>();
        Date = DateTime.UtcNow;        
        Status = StatusPedido.Novo;
    }


    public void CalcularValorTotal() => ValorTotal = _pedidoItens.Sum(x => x.CalcularValor());
  
    public bool PedidoItemExistente()
    {

    }


}
