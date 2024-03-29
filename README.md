# Aplicação Biblioteca Back End

## Descrição do Projeto
A aplicação Biblioteca é um sistema de gerenciamento de livros que permite aos usuários listar, adicionar, atualizar e excluir livros em uma biblioteca. Ela é desenvolvida em conformidade com os princípios do Domain-Driven Design (DDD) e utiliza o .NET 6.0, Entity Framework Core para persistência de dados e segue as melhores práticas de design de APIs Web da Microsoft.

## Objetivo
O objetivo principal deste projeto é demonstrar boas práticas de desenvolvimento de software, incluindo o uso de DDD, Entity Framework Core, documentação de API com Swagger/OpenAPI e conformidade com o Modelo de Maturidade de Richardson para APIs RESTful. Este projeto serve como um exemplo educacional e prático de como criar uma aplicação moderna em C#/.NET.

## Instruções de Construção e Execução
Para construir e executar a aplicação Biblioteca, siga estas instruções:

### Pré-requisitos:
- [.NET 6.0 LTS](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio](https://visualstudio.microsoft.com/), [Visual Studio Code](https://code.visualstudio.com/), ou qualquer IDE de sua preferência.
- Banco de dados relacional (SQLite e SQL Server são suportados).

### Clonar o Repositório:
- Use o comando `git clone https://github.com/noelfelipe/Biblioteca` para clonar o repositório do projeto localmente.

### Construção:
- Abra a solução do projeto no Visual Studio ou em outra IDE.
- Construa a solução para baixar todas as dependências necessárias.

### Execução:
- Execute a aplicação utilizando o comando `dotnet run` no diretório do projeto da API.
- Acesse `http://localhost:5000/swagger` para visualizar e interagir com a documentação da API Swagger.

## Exemplos de Uso da API via Swagger
Para adicionar um novo livro, você pode usar o seguinte exemplo de JSON no endpoint `/api/Livros` com o método `POST`:

```json
{
  "titulo": "O Nome do Vento",
  "autor": "Patrick Rothfuss",
  "dataPublicacao": "2007-03-27T00:00:00",
  "isbn": "978-0-123456-47-2"
}

```
```json
{
  "titulo": "O Nome do Vento",
  "autor": "Patrick Rothfuss",
  "dataPublicacao": "2007-03-27T00:00:00",
  "isbn": "978-0-123456-47-2"
}
```
```json
{
  "titulo": "Sapiens: Uma Breve História da Humanidade",
  "autor": "Yuval Noah Harari",
  "dataPublicacao": "2011-01-01T00:00:00",
  "isbn": "978-1-234567-89-7"
}
```
Nota: Certifique-se de ajustar as datas de publicação e os números ISBN para valores reais e válidos conforme necessário.

# Aplicação Biblioteca Front End

# AngularApp

This project generated by [Angular CLI](https://github.com/angular/angular-cli)

## Requeriments
NPM `9.6.7` 

Node `18.16.0` `https://nodejs.org/dist/v18.12.0/node-v18.12.0-x64.msi`

Angular `13.2.3` `npm install -g @angular/cli`

## Development server

Open terminal

Open main folder

Run `npm install`

Run `ng serve` or `npm start`

Navegar até `http://localhost:4200/`



Contato
Para mais informações, entre em contato com Noel Felipe pelo email noelgnn@gmail.com.

