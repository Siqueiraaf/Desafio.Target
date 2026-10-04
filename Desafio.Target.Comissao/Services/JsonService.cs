using System.Text.Json;
using Desafio.Target.Comissao.Entities;
using Desafio.Target.Comissao.Services.Interfaces;

namespace Desafio.Target.Comissao.Services;

public class JsonService : IJsonService
{
    public DadosVendas LerArquivo(string caminho)
    {
        var json = File.ReadAllText(caminho);

        var opcoes = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<DadosVendas>(json, opcoes) ?? new DadosVendas();
    }
}