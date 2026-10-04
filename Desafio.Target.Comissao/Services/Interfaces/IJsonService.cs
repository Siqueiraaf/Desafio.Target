using Desafio.Target.Comissao.Entities;

namespace Desafio.Target.Comissao.Services.Interfaces;

interface IJsonService
{
    DadosVendas LerArquivo(string caminho);
}
