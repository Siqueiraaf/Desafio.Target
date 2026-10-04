using Desafio.Target.ControleEstoque.DTOs;
using Desafio.Target.ControleEstoque.Services.Interfaces;

namespace Desafio.Target.ControleEstoque.UI;

public class Menu(DadosEstoqueDto dadosEstoque, IEstoqueService estoqueService)
{
    private readonly DadosEstoqueDto _dadosEstoque = dadosEstoque;
    private readonly IEstoqueService _estoqueService = estoqueService;

    public void Executar()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("======= CONTROLE DE ESTOQUE =======\n");
            Console.WriteLine("1 - Realizar movimentação\n" + "2 - Listar produtos\n" + "0 - Sair\n");
            Console.Write("Escolha uma opção: ");

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    RealizarMovimentacao();
                    break;

                case "2":
                    ListarProdutos();
                    break;

                case "0":
                    EncerrarPrograma();
                    return;

                default:
                    Console.WriteLine("\nOpção inválida.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void RealizarMovimentacao()
    {
        Console.Clear();
        Console.WriteLine("========= MOVIMENTAÇÃO DE ESTOQUE =========\n");

        Console.Write("Digite o código do produto: ");
        var codigoProduto = int.Parse(Console.ReadLine()!);

        var produto = _dadosEstoque.Estoque.FirstOrDefault(p => p.CodigoProduto == codigoProduto);

        if (produto == null)
        {
            Console.WriteLine("\nProduto não encontrado.");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            return;
        }

        Console.Write("\nCódigo selecionado: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(produto.CodigoProduto);
        Console.ResetColor();

        Console.Write(" - Produto: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"{ produto.DescricaoProduto}\n");
        Console.ResetColor();


        Console.Write("\nEscolha o tipo de movimentação:\n");

        Console.Write("Digite: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("1 - para efetuar uma Entrada\n");
        Console.ResetColor();

        Console.Write("Digite: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("2 - para efetuar uma Saída\n");
        Console.ResetColor();

        Console.Write("\nOpção: ");
        var opcaoMovimentacao = Console.ReadLine();

        string descricao;

        switch (opcaoMovimentacao)
        {
            case "1":
                descricao = "Entrada";
                break;

            case "2":
                descricao = "Saída";
                break;

            default:
                Console.WriteLine(
                    "\nOpção de movimentação inválida.\n" +
                    "Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
        }

        Console.Write("Quantidade: ");
        var quantidade = int.Parse(Console.ReadLine()!);

        var movimentacao = new MovimentacaoEstoqueDto
        {
            CodigoProduto = codigoProduto,
            Descricao = descricao,
            Quantidade = quantidade
        };

        try
        {
            var resultado = _estoqueService.Movimentar(_dadosEstoque, movimentacao);

            Console.WriteLine("\n=========== MOVIMENTAÇÃO REALIZADA ===========\n" +
                $"Número: {resultado.Id}\n" +
                $"Produto: {resultado.Produto}\n" +
                $"Tipo: {resultado.TipoMovimentacao}\n" +
                $"Quantidade: {resultado.QuantidadeMovimentada}\n" +
                $"Estoque final: {resultado.EstoqueFinal}\n" +
                "==================================");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro: {ex.Message}");
        }

        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    private void ListarProdutos()
    {
        Console.Clear();
        Console.WriteLine("========= ESTOQUE =========\n");

        foreach (var produto in _dadosEstoque.Estoque)
        {
            Console.WriteLine(
                $"{produto.CodigoProduto} - " +
                $"{produto.DescricaoProduto} - " +
                $"Estoque: {produto.Estoque}");
        }
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    private static void EncerrarPrograma()
    {
        Console.WriteLine("\nPrograma encerrado.");
        Console.WriteLine("Pressione ENTER para fechar...\n");
        Console.ReadLine();
    }
}