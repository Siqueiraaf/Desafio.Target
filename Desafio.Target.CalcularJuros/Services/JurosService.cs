using Desafio.Target.CalcularJuros.DTOs;
using Desafio.Target.CalcularJuros.Services.Interfaces;

namespace Desafio.Target.CalcularJuros.Services;

public class JurosService : IJurosService
{
    private const decimal TaxaJurosDiaria = 0.025m;

    public ResultadoJurosDto Calcular(DadosJurosDto dados)
    {
        DateTime hoje = DateTime.Today;

        int diasAtraso = dados.DataVencimento < hoje ? (hoje - dados.DataVencimento).Days : 0;
        decimal juros = dados.Valor * TaxaJurosDiaria * diasAtraso;
        decimal valorAtualizado = dados.Valor + juros;

        return new ResultadoJurosDto
        {
            ValorOriginal = dados.Valor,
            DataVencimento = dados.DataVencimento,
            DataAtual = hoje,
            DiasAtraso = diasAtraso,
            Juros = juros,
            ValorAtualizado = valorAtualizado
        };
    }
}