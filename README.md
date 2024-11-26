# webApi

## Descri��o

Esta � uma API desenvolvida em .NET com o objetivo de consumir a API p�blica [Random User Generator](https://randomuser.me/documentation) e fornecer endpoints que facilitam a manipula��o e armazenamento dos dados de usu�rios gerados. O projeto faz parte de um desafio t�cnico para demonstrar habilidades em backend, integra��o com banco de dados PostgreSQL e cria��o de uma interface b�sica em JavaScript.

## Funcionalidades

- **Consumo da API Random User Generator**: Conex�o com a API para obter dados de usu�rios aleat�rios.
- **Integra��o com PostgreSQL**: Armazenamento dos dados gerados em um banco de dados relacional.
- **Endpoints para Manipula��o de Dados**:
  - Listar todos os usu�rios armazenados.
  - Editar os dados de um usu�rio.
- **Relat�rios de Usu�rios**: Gera��o de relat�rios baseados nos dados armazenados.

## Tecnologias Utilizadas

- **.NET Core** - Framework principal para o desenvolvimento da API.
- **PostgreSQL** - Banco de dados relacional para armazenamento dos dados.
- **Entity Framework Core** - ORM para integra��o com o banco de dados.

## Estrutura do Projeto

- **Controllers**: Gerencia as requisi��es HTTP e executa as opera��es nos dados.
- **Models**: Define a estrutura dos dados dos usu�rios.
- **Services**: Camada intermedi�ria para l�gica de neg�cio e integra��o com a API externa.
- **Data**: Configura��o e migra��o do banco de dados PostgreSQL.

## Como Executar

### Pr�-requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download) instalado.
- PostgreSQL configurado e rodando localmente.
- Visual Studio ou VS Code para desenvolvimento.

### Passos

1. Clone o reposit�rio:
   ```bash
   git clone https://github.com/DanielSCosta10/DesafioRandomUser.git

2. Configure a string de conex�o com o banco de dados PostgreSQL no arquivo appsettings.json:
   ```bash
    "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Database=RandomUserDB;Username=seu_usuario;Password=sua_senha"
    }

3. Execute as migrations para criar o banco de dados:
   ```bash
   dotnet ef database update
  
4. Inicie a aplica��o:
   ```bash
   dotnet run

5. A API estar� dispon�vel no endere�o:
   ```bash
   http://localhost:5073