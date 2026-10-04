using Desafio.Target.ControleEstoque.DTOs;

namespace Desafio.Target.ControleEstoque.Services.Interfaces;

public interface IEstoqueService
{
    ResultadoMovimentacaoDto Movimentar(DadosEstoqueDto dadosEstoque, MovimentacaoEstoqueDto movimentacao);
}
