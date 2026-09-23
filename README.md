# ProdutosCodeFirst API

Projeto desenvolvido em **C# com ASP.NET Core 8**, utilizando **Entity Framework Core**, **SQL Server** e **Code First**.

A API foi desenvolvida para cadastro e gerenciamento de produtos, utilizando Repository Pattern e Dependency Injection.

## Tecnologias

* C#
* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger
* Docker

## Estrutura

```text
Contexts/
    ProdutoContext.cs

Controllers/
    ProdutosController.cs

Interfaces/
    IProdutoRepository.cs

Models/
    Produto.cs

Repositories/
    ProdutoRepository.cs

Services/
    ProdutoService.cs

Migrations/
```

## Banco de dados

Banco utilizado:

```text
SistemaProdutosDB
```

Tabela principal:

```text
Produtos
```

A criação e atualização do banco são feitas através do Entity Framework Core e suas migrations.

### Observação sobre o ambiente

O projeto foi desenvolvido em **Linux (Fedora)**. Como o ambiente utilizado em aula para o SQL Server não estava disponível no Linux, o SQL Server foi executado através de **Docker**.

A aplicação continua utilizando **Microsoft SQL Server normalmente**, sendo o Docker apenas a forma encontrada para executar o banco no ambiente Linux.

## Configuração

A Connection String foi configurada utilizando **User Secrets**, para não deixar a senha do banco no código ou no GitHub.

Para configurar:

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "SUA_CONNECTION_STRING"
```

## Executando o projeto

Restaurar os pacotes:

```bash
dotnet restore
```

Aplicar as migrations:

```bash
dotnet ef database update
```

Executar a API:

```bash
dotnet run
```

O Swagger pode ser acessado pelo endereço mostrado no terminal, adicionando:

```text
/swagger
```

## Endpoints

| Método | Rota                 | Função              |
| ------ | -------------------- | ------------------- |
| GET    | `/api/produtos`      | Lista os produtos   |
| GET    | `/api/produtos/{id}` | Busca um produto    |
| POST   | `/api/produtos`      | Cadastra um produto |
| PUT    | `/api/produtos/{id}` | Atualiza um produto |
| DELETE | `/api/produtos/{id}` | Exclui um produto   |

## Exemplo de produto

```json
{
  "nome": "Notebook",
  "marca": "Dell",
  "preco": 4500.50,
  "quantidadeEstoque": 10,
  "ativo": true
}
```

## Migrations

Migration inicial:

```text
InitialCreate
```

Para aplicar ao banco:

```bash
dotnet ef database update
```

## Repositório

https://github.com/marioti-01/ProdutosCodeFirst
