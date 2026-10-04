using Desafio.Target.Comissao.DTOs;

namespace Desafio.Target.Comissao.UI;

public class Menu(List<ResultadoComissaoDto> resultados)
{
    private readonly List<ResultadoComissaoDto> _resultados = resultados;

    public void Executar()
    {
        bool continuar = true;

        while (continuar)
        {
            ExibirMenu();

            var opcao = Console.ReadLine();
            Console.Clear();

            continuar = ProcessarOpcao(opcao, continuar);

            if (continuar) 
                continuar = PerguntarNovaConsulta();
        }

        EncerrarPrograma();
    }

    private static void ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine("================= CÁLCULO DE COMISSÕES =================\n");
        Console.WriteLine("1 - Todos os vendedores\n" + "2 - Vendedor específico\n" + "0 - Sair\n");
        Console.Write("Escolha uma opção: ");
    }

    private bool ProcessarOpcao(string? opcao, bool continuar)
    {
        switch (opcao)
        {
            case "1":
                ExibirTodosVendedores();
                break;

            case "2":
                ExibirVendedorEspecifico();
                break;

            case "0":
                continuar = false;
                Console.WriteLine("Encerrando o programa...");
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
        return continuar;
    }

    private void ExibirTodosVendedores()
    {
        Console.WriteLine("=== TODOS OS VENDEDORES ===\n");

        foreach (var resultado in _resultados)
        {
            Console.Write($"A comissão do vendedor {resultado.Vendedor} é: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{resultado.Comissao:C}");
            Console.ResetColor();
        }
    }

    private void ExibirVendedorEspecifico()
    {
        Console.WriteLine("=== VENDEDORES ===\n");

        for (int i = 0; i < _resultados.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {_resultados[i].Vendedor}");
        }

        Console.Write("\nEscolha o vendedor: ");

        var entrada = Console.ReadLine();

        if (!int.TryParse(entrada, out int escolha))
        {
            Console.WriteLine("\nDigite um número válido.");
            return;
        }

        if (escolha < 1 || escolha > _resultados.Count)
        {
            Console.WriteLine("\nVendedor inválido.");
            return;
        }

        var vendedorSelecionado = _resultados[escolha - 1];

        Console.WriteLine("\n=== RESULTADO ===\n");

        Console.Write($"A comissão do vendedor {vendedorSelecionado.Vendedor} é: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{vendedorSelecionado.Comissao:C}");
        Console.ResetColor();
    }

    private static bool PerguntarNovaConsulta()
    {
        Console.WriteLine("\n--------------------------------");
        Console.WriteLine("Deseja realizar outra consulta?\n");
        Console.WriteLine("Digite: '1' para Realizar outra consulta.\nDigite: '0' para Encerrar.");
        Console.WriteLine("--------------------------------");

        Console.Write("\nEscolha uma opção: ");

        var opcao = Console.ReadLine();
        return opcao == "1";
    }

    private static void EncerrarPrograma()
    {
        Console.WriteLine("\nPrograma encerrado.");
        Console.WriteLine("Pressione ENTER para fechar...\n");
        Console.ReadLine();
    }
}