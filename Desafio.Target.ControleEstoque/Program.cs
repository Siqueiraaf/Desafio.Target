using Desafio.Target.ControleEstoque.Services;
using Desafio.Target.ControleEstoque.Services.Interfaces;
using Desafio.Target.ControleEstoque.UI;

IJsonService jsonService = new JsonService();
IEstoqueService estoqueService = new EstoqueService();

var dadosEstoque = jsonService.LerArquivo("Data/estoque.json");
var menu = new Menu(dadosEstoque, estoqueService);

menu.Executar();