using Desafio.Target.Comissao.Services;
using Desafio.Target.Comissao.Services.Interfaces;
using Desafio.Target.Comissao.UI;

IJsonService jsonService = new JsonService();
IComissaoService comissaoService = new ComissaoService();

var dados = jsonService.LerArquivo("Data/vendas.json");

var resultados = comissaoService.CalcularComissoes(dados.Vendas);

var menu = new Menu(resultados);
menu.Executar();