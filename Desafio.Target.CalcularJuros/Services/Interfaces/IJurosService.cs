using Desafio.Target.CalcularJuros.DTOs;

namespace Desafio.Target.CalcularJuros.Services.Interfaces;

public interface IJurosService
{
    ResultadoJurosDto Calcular(DadosJurosDto dados);
}
