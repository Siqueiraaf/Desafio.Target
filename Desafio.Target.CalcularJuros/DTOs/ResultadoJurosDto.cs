namespace Desafio.Target.CalcularJuros.DTOs;

public class ResultadoJurosDto
{
    public decimal ValorOriginal { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime DataAtual { get; set; }
    public int DiasAtraso { get; set; }
    public decimal Juros { get; set; }
    public decimal ValorAtualizado { get; set; }
}