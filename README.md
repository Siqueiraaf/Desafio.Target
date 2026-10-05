# Desafios da Target Sistemas

Repositório com os três desafios desenvolvidos em C# e .NET, com foco em lógica de programação, regras de negócio, organização e boas práticas de código.

## Desafios

### 1 - Comissão de Vendas

Calcula a comissão dos vendedores com base no valor das vendas.

**Regras:**

* Abaixo de R$ 100,00 → 0%
* De R$ 100,00 até R$ 499,99 → 1%
* A partir de R$ 500,00 → 5%

Os dados das vendas são lidos de um arquivo JSON com os dados disponibilizados para o desafio.

---

### 2 - Controle de Estoque

Permite lançar movimentações de estoque dos produtos informados no arquivo JSON, realizando entradas ou saídas de mercadorias, armazenando e retornando os dados em tempo de execução.

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

## Tecnologias e boas práticas utilizadas

* C#
* .NET
* LINQ
* JSON
* DTOs
* Interfaces
* Services
* Programação Orientada a Objetos
* Separação de responsabilidades
* Validação de dados

## Estrutura dos projetos

Os desafios foram separados em projetos independentes:

```text
Desafio.Target
│
├── Desafio.Target.Comissao
├── Desafio.Target.ControleEstoque
└── Desafio.Target.CalcularJuros
```

Cada projeto possui sua própria implementação e pode ser executado de forma independente.

## Como executar

Clone o repositório:

```bash
git clone https://github.com/Siqueiraaf/Desafio.Target
```

Entre na pasta do desafio desejado e execute:

```bash
dotnet run
```

Exemplo:

```bash
cd Desafio.Target.Comissao
dotnet run
```

## Decisões técnicas

Os projetos foram desenvolvidos como aplicações de console, mantendo uma estrutura simples e objetiva de acordo com a proposta dos desafios.

Foram utilizados DTOs, interfaces e services para organizar o código e separar as responsabilidades, mantendo as regras de negócio isoladas das demais partes da aplicação.

Não utilizei Docker, pois os requisitos apresentados não indicavam a necessidade de containerização. A intenção foi manter os projetos com uma estrutura enxuta, facilitando a execução, o entendimento e a avaliação das soluções.
