# Desafios da Target Sistemas

Repositório com os três desafios desenvolvidos em C# e .NET, com foco em lógica de programação, regras de negócio e organização do código.

## Desafios

### 1 - Comissão de Vendas

Calcula a comissão dos vendedores com base no valor das vendas.

**Regras:**

* Abaixo de R$ 100,00 → 0%
* De R$ 100,00 até R$ 499,99 → 1%
* A partir de R$ 500,00 → 5%

Os dados das vendas são lidos de um arquivo JSON com os dados que foram disponibilizados.

---

### 2 - Controle de Estoque

Permite lançar movimentações de estoque dos produtos informados no arquivo JSON, realizando entradas ou saídas de mercadorias, funcionando em tempo de execução.

Cada movimentação possui:

* Um número identificador único
* Uma descrição para identificar o tipo da movimentação realizada
* A quantidade movimentada

Ao final de cada movimentação, o programa retorna a quantidade final em estoque do produto movimentado.

---

### 3 - Cálculo de Juros por Atraso

Calcula o valor dos juros de uma dívida a partir do valor informado e da data de vencimento.

**Regra:**

* Multa de **2,5% ao dia** sobre o valor da dívida em atraso.

O cálculo considera a quantidade de dias entre a data de vencimento e a data atual.

O projeto utiliza `decimal` para trabalhar com valores monetários e realiza validações dos dados informados pelo usuário.

---

## Tecnologias e boas praticas que utilizei

* C#
* .NET
* LINQ
* JSON
* DTOs
* Interfaces
* Services
* Programação Orientada a Objetos

## Como executar

Clone o repositório:

```bash
git clone https://github.com/Siqueiraaf/Desafio.Target
```

Entre na pasta do desafio desejado e execute:

```bash
dotnet run
```
## Observação

Os projetos foram mantidos de forma simples e objetiva, de acordo com a proposta dos desafios.

Não utilizei Docker, pois os requisitos apresentados não indicavam a necessidade de containerização. A minha intenção foi manter os projetos com uma estrutura enxuta, facilitando a execução, entendimento e avaliação das soluções.
