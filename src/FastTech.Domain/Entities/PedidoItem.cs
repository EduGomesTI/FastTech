using FastTech.Domain.Common;

namespace FastTech.Domain.Entities;

public class PedidoItem : Entity
{
    public Guid PedidoId { get; private set; }
    public Guid ProdutoId { get; private set; }
    public int Quantidade { get; private set; }
    public decimal ValorUnitario { get; private set; }
    public string? NomeProduto { get; private set; }
    public Pedido? Pedido { get; set; }

    public PedidoItem(Guid produtoId, string nomeProduto, int quantidade, decimal valorUnitario)
    {
        ProdutoId = produtoId;
        NomeProduto = nomeProduto;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;

        Validar();
    }

    public void VincularPedido(Guid pedidoId)
    {
        PedidoId = pedidoId;
    }

    public decimal CalcularValor()
    {
        return Quantidade * ValorUnitario;
    }

    public void AdicionarQuantidade(int quantidade)
    {
        Quantidade = +quantidade;
    }

    public void AtualizarQuantidade(int quantidade)
    {
        Quantidade = quantidade;
    }

    protected override void Validar()
    {
        if (ProdutoId == Guid.Empty)
        {
            throw new DomainException("Id do Produto inválido.");
        }

        if (Quantidade < 0)
        {
            throw new DomainException("Quantidade não pode ser menor que zero.");
        }

        if (ValorUnitario <= 0)
        {
            throw new DomainException("O valor unitário não pode ser menor ou igual a zero.");
        }

        if (string.IsNullOrWhiteSpace(NomeProduto))
        {
            throw new DomainException("Nome do Produto inválido.");
        }
    }
}
