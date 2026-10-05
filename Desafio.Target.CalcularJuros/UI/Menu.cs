using Desafio.Target.CalcularJuros.DTOs;
using Desafio.Target.CalcularJuros.Services.Interfaces;
using System.Globalization;

namespace Desafio.Target.CalcularJuros.UI;

public class Menu(IJurosService jurosService)
{
    private readonly IJurosService _jurosService = jurosService;

    public void Executar()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();

            continuar = Consultar();

            if (!continuar)
                break;

            Console.WriteLine("\n================================");
            Console.WriteLine("Deseja realizar outra consulta?\n");
            Console.WriteLine("Digite: 1 - Para realizar outra consulta");
            Console.WriteLine("Digite: 0 - Para sair\n");
            Console.Write("Escolha uma opção: ");

            string? opcao = Console.ReadLine();

            continuar = opcao == "1";
        }

        Console.ResetColor();
        Console.Clear();

        Console.WriteLine("Programa encerrado.");
    }

    private bool Consultar()
    {
        Console.WriteLine("=== Cálculo de Juros por Atraso ===\n");
        Console.Write("Digite o valor da dívida: R$ ");

        if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Number,
            CultureInfo.GetCultureInfo("pt-BR"), out decimal valor))
        {
            Console.WriteLine("Valor inválido.");
            return true;
        }

        DateTime dataVencimento;

        while (true)
        {
            Console.Write("Digite a data de vencimento (exemplo: 11/01/2001 ou 11012001): ");

            string entradaData = Console.ReadLine()!;

            string dataFormatada = FormatarData(entradaData);

            if (DateTime.TryParseExact(dataFormatada, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out dataVencimento))
            {
                break;
            }

            Console.WriteLine("\nData inválida!\n");
            Console.WriteLine("Digite: 1 - Para inserir uma data valida");
            Console.WriteLine("Digite: 0 - Para sair do programa");
            Console.Write("\nEscolha uma opção: ");

            string? opcao = Console.ReadLine();

            if (opcao == "0")
                return false;
        }

        DadosJurosDto dados = new()
        {
            Valor = valor,
            DataVencimento = dataVencimento
        };

        ResultadoJurosDto resultado = _jurosService.Calcular(dados);

        ExibirResultado(resultado);

        return true;
    }

    private static string FormatarData(string entrada)
    {
        entrada = entrada.Replace("/", "").Replace("-", "");

        if (entrada.Length == 8)
        {
            return $"{entrada[..2]}/{entrada[2..4]}/{entrada[4..]}";
        }

        return entrada;
    }

    private static void ExibirResultado(ResultadoJurosDto resultado)
    {
        Console.WriteLine("\n=== RESULTADO ===");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"Valor original:    R$ {resultado.ValorOriginal:N2}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Vencimento:        {resultado.DataVencimento:dd/MM/yyyy}");
        Console.ResetColor();

        Console.WriteLine($"Data atual:        {resultado.DataAtual:dd/MM/yyyy}");
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Dias de atraso:    {resultado.DiasAtraso}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\n=== JUROS ===");
        Console.WriteLine($"Juros:             R$ {resultado.Juros:N2}");
        Console.WriteLine($"Total:             R$ {resultado.ValorAtualizado:N2}");

        Console.ResetColor();
    }
}