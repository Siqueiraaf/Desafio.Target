using Desafio.Target.ControleEstoque.DTOs;
using Desafio.Target.ControleEstoque.Services.Interfaces;

namespace Desafio.Target.ControleEstoque.Services;

public class EstoqueService : IEstoqueService
{
    private int _idMovimentacao = 1;

    public ResultadoMovimentacaoDto Movimentar(
        DadosEstoqueDto dadosEstoque,
        MovimentacaoEstoqueDto movimentacao)
    {
        var produto = dadosEstoque.Estoque.FirstOrDefault(
            produto => produto.CodigoProduto == movimentacao.CodigoProduto)
            ?? throw new Exception("Produto não encontrado.");

        if (movimentacao.Quantidade <= 0)
            throw new Exception("A quantidade deve ser maior que zero.");

        if (movimentacao.Descricao.Equals(
                "Saída",
                StringComparison.OrdinalIgnoreCase))
        {
            if (movimentacao.Quantidade > produto.Estoque)
                throw new Exception(
                    $"Estoque insuficiente. Estoque disponível: {produto.Estoque}.");

            produto.Estoque -= movimentacao.Quantidade;
        }
        else if (movimentacao.Descricao.Equals(
                     "Entrada",
                     StringComparison.OrdinalIgnoreCase))
        {
            produto.Estoque += movimentacao.Quantidade;
        }
        else
        {
            throw new Exception(
                "Tipo de movimentação inválido. Use Entrada ou Saída.");
        }

        var resultado = new ResultadoMovimentacaoDto
        {
            Id = _idMovimentacao,
            Produto = produto.DescricaoProduto,
            TipoMovimentacao = movimentacao.Descricao,
            QuantidadeMovimentada = movimentacao.Quantidade,
            EstoqueFinal = produto.Estoque
        };

        _idMovimentacao++;

        return resultado;
    }
}