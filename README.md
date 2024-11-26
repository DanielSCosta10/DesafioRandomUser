# webApi

## Descrição

Esta é uma API desenvolvida em .NET com o objetivo de consumir a API pública [Random User Generator](https://randomuser.me/documentation) e fornecer endpoints que facilitam a manipulação e armazenamento dos dados de usuários gerados. O projeto faz parte de um desafio técnico para demonstrar habilidades em backend, integração com banco de dados PostgreSQL e criação de uma interface básica em JavaScript.

## Funcionalidades

- **Consumo da API Random User Generator**: Conexão com a API para obter dados de usuários aleatórios.
- **Integração com PostgreSQL**: Armazenamento dos dados gerados em um banco de dados relacional.
- **Endpoints para Manipulação de Dados**:
  - Listar todos os usuários armazenados.
  - Editar os dados de um usuário.
- **Relatórios de Usuários**: Geração de relatórios baseados nos dados armazenados.

## Tecnologias Utilizadas

- **.NET Core** - Framework principal para o desenvolvimento da API.
- **PostgreSQL** - Banco de dados relacional para armazenamento dos dados.
- **Entity Framework Core** - ORM para integração com o banco de dados.

## Estrutura do Projeto

- **Controllers**: Gerencia as requisições HTTP e executa as operações nos dados.
- **Models**: Define a estrutura dos dados dos usuários.
- **Services**: Camada intermediária para lógica de negócio e integração com a API externa.
- **Data**: Configuração e migração do banco de dados PostgreSQL.

## Como Executar

### Pré-requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download) instalado.
- PostgreSQL configurado e rodando localmente.
- Visual Studio ou VS Code para desenvolvimento.

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/DanielSCosta10/DesafioRandomUser.git

2. Configure a string de conexão com o banco de dados PostgreSQL no arquivo appsettings.json:
   ```bash
    "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Database=RandomUserDB;Username=seu_usuario;Password=sua_senha"
    }

3. Execute as migrations para criar o banco de dados:
   ```bash
   dotnet ef database update
  
4. Inicie a aplicação:
   ```bash
   dotnet run

5. A API estará disponível no endereço:
   ```bash
   http://localhost:5073