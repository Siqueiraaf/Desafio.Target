using Desafio.Target.CalcularJuros.Services;
using Desafio.Target.CalcularJuros.Services.Interfaces;
using Desafio.Target.CalcularJuros.UI;

IJurosService jurosService = new JurosService();

Menu menu = new(jurosService);
menu.Executar();