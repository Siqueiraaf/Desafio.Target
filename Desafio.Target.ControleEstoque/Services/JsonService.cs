using Desafio.Target.ControleEstoque.DTOs;
using Desafio.Target.ControleEstoque.Services.Interfaces;
using System.Text.Json;

namespace Desafio.Target.ControleEstoque.Services;

public class JsonService : IJsonService
{
    public DadosEstoqueDto LerArquivo(string caminho)
    {
        var json = File.ReadAllText(caminho);

        var opcoes = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<DadosEstoqueDto>(json, opcoes) ?? new DadosEstoqueDto();
    }
}
