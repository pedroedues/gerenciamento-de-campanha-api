# Gerenciamento e Redirecionamento de Campanhas

A API foi desenvolvida em .NET 8 e usa MongoDB como banco de dados. Sua função é gerenciar campanhas, permitindo a criação, edição e execução de redirecionamentos. Cada campanha possui uma lista de URLs, com a opção de definir o número de cliques por URL. O objetivo principal é redirecionar usuários a partir de um link exclusivo da campanha, respeitando o limite de cliques por URL.

## Pré-requisitos

Certifique-se de ter as seguintes ferramentas instaladas em sua máquina:

- [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/5.0)
- [MongoDB](https://www.mongodb.com/try/download/community)

## Configuração do Banco de Dados

1. Inicie o servidor MongoDB localmente.
2. Crie um banco de dados chamado `Campanhas-MongoDB`.

## Configuração da Aplicação

1. Clone este repositório.
```bash
git clone https://github.com/pedroedues/gerenciamento-de-campanha-api.git
```

2. Abra o arquivo lauchSettings.json e atualize, se necessário, a string de conexão do MongoDB com os detalhes do seu banco de dados.
```json
{
  "MongoDbConnection": "mongodb://localhost:27017"
}
```

## Executando a Aplicação

1. Abra um terminal na pasta do projeto e execute o seguinte comando para restaurar as dependências.
```bash
dotnet restore
```

2. Execute o seguinte comando para compilar e iniciar a aplicação.
```bash
dotnet run
```

3. A aplicação estará disponível em https://localhost:7074.

4. Documentação da API (Swagger)
Acesse a documentação da API utilizando o Swagger em https://localhost:7074/swagger.

## Endpoints da API

### GET /Campanha/{id}
Retorna detalhes da campanha com o ID especificado.

### POST /Campanha
Cria uma nova campanha. Retorna o link único de acesso o Id da campanha criada

Payload de Exemplo
```json
{
  "maximoDeCliques": 100,
  "links": [
    "http://url1.com",
    "http://url2.com"
  ]
}
```

### PUT /Campanha/{id}
Atualiza os detalhes da campanha com o ID especificado.

Payload de Exemplo
```json
{
  "maximoDeCliques": 150,
  "links": [
    {
      "quantidadeCliques": 50,
      "url": "http://url1.com"
    },
    {
      "quantidadeCliques": 100,
      "url": "http://url2.com"
    }
  ]
}
```

### PUT /Campanha/Redirecionar
Redireciona para uma URL da campanha com base no link de acesso fornecido.

Payload de Exemplo
```json
{
  "linkDeAcesso": "http://linkDeAcessoDaCampanha"
}
```

## Demonstração de Funcionamento
[Vídeo da Demonstração de Funcionamento](https://drive.google.com/file/d/1QZJ9OlnymG0t8XYWhZSChqDBgRbWLpHx/view?usp=sharing)

## Testes Unitários
Testes serão realizados utilizando xUnit
🛠️ Construção em andamento 🛠️

Contato
-------

*   **Nome:** Pedro Eduardo dos Santos
*   **LinkedIn:** [Pedro Eduardo](https://www.linkedin.com/in/pedro-eduardo/)
*   **Email:** [espedrosantos@gmail.com](mailto:espedrosantos@gmail.com)
