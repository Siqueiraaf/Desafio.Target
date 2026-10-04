namespace Desafio.Target.ControleEstoque.DTOs;

public class ResultadoMovimentacaoDto
{
    public int NumeroMovimentacao { get; set; }
    public string Produto { get; set; } = string.Empty;
    public string TipoMovimentacao { get; set; } = string.Empty;
    public int QuantidadeMovimentada { get; set; }
    public int EstoqueFinal { get; set; }
}
