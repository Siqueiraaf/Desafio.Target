using Desafio.Target.ControleEstoque.DTOs;

namespace Desafio.Target.ControleEstoque.Services.Interfaces;

interface IJsonService
{
    DadosEstoqueDto LerArquivo(string caminho);
}
