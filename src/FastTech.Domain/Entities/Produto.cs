﻿using FastTech.Domain.Common;
using FastTech.Domain.Enums;

namespace FastTech.Domain.Entities;

internal class Produto : Entity
{
    public string? Nome { get; private set; }
    public string? Descricao { get; private set; }
    public bool Ativo { get; private set; }
    public decimal Valor { get; private set; }
    public DateTime Cadastro { get; private set; }
    public TipoProduto Tipo { get; private set; }
    public int QuantidadeEstoque { get; private set; }

    public Produto()
    {

    }

    public Produto(string? nome, string descricao, decimal valor,
        TipoProduto tipo, int quantidadeEstoque)
    {
        Nome = nome;
        Descricao = descricao;
        Ativo = true;
        Valor = valor;
        Cadastro = DateTime.UtcNow;
        Tipo = tipo;
        QuantidadeEstoque = quantidadeEstoque;
    }

    public void AlterarNome(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome))
        {
            throw new DomainException("Nome inválida.");
        }

        Nome = novoNome;
    }

    public void Ativar() => Ativo = true;

    public void Desativar() => Ativo = false;

    public void AlterarTipo(TipoProduto novoTipo) => Tipo = novoTipo;

    public void AlterarDescricao(string novaDescricao)
    {
        if (string.IsNullOrWhiteSpace(novaDescricao))
        {
            throw new DomainException("Descrição inválida.");
        }

        Descricao = novaDescricao;
    }

    public void DebitarEstoque(int quantidade)
    {
        if (quantidade < 0)
        {
            throw new DomainException("Quantidade inválida.");
        }

        if (!PossuiEstoque(quantidade))
        {
            throw new DomainException("Quantidade em estoque insuficiente.");
        }

        QuantidadeEstoque -= quantidade;

    }

    public bool PossuiEstoque(int quantidade) => QuantidadeEstoque >= quantidade;

    public void AdicionarEstoque(int quantidade)
    {
        if (quantidade < 0)
        {
            throw new DomainException("Quantidade não pode ser negativa.");
        }
        QuantidadeEstoque += quantidade;
    }

}