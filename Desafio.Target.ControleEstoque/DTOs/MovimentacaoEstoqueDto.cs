namespace Desafio.Target.ControleEstoque.DTOs;

public class MovimentacaoEstoqueDto
{
    public int Id { get; set; }
    public int CodigoProduto { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public int Quantidade { get; set; }
}
