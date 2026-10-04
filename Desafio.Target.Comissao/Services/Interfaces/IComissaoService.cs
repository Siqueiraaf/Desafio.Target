using Desafio.Target.Comissao.DTOs;
using Desafio.Target.Comissao.Entities;

namespace Desafio.Target.Comissao.Services.Interfaces;

interface IComissaoService
{
    List<ResultadoComissaoDto> CalcularComissoes(List<Venda> vendas);
}
