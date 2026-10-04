using Desafio.Target.Comissao.DTOs;
using Desafio.Target.Comissao.Entities;
using Desafio.Target.Comissao.Services.Interfaces;

namespace Desafio.Target.Comissao.Services;

public class ComissaoService : IComissaoService
{
    public List<ResultadoComissaoDto> CalcularComissoes(List<Venda> vendas)
    {
        return vendas.GroupBy(venda => venda.Vendedor).Select(grupo => 
        new ResultadoComissaoDto
        {
            Vendedor = grupo.Key,
            Comissao = grupo.Sum(venda => CalcularComissao(venda.Valor))
        }).ToList();
    }

    private static decimal CalcularComissao(decimal valor)
    {
        decimal opcao1 = 0.01m;
        decimal opcao2 = 0.05m;

        if (valor < 100) return 0;
        if (valor < 500) return valor * opcao1;

        return valor * opcao2;
    }
}
