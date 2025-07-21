# Contador de Valores - Sistema Web Full-Stack

Este projeto é uma aplicação web full-stack desenvolvida para fins acadêmicos, com o objetivo de demonstrar a comunicação entre um frontend e um backend. A aplicação permite o envio de valores (textos ou números) pelo frontend e contabiliza, no backend, quantas vezes cada valor foi recebido.

## Estrutura do Projeto

Diferente de uma abordagem com repositórios separados, este projeto adota uma arquitetura integrada, onde o backend é responsável por servir a aplicação frontend.

* **Backend (C# + ASP.NET Core)** - Lógica principal do servidor, localizada nos arquivos `.cs` do projeto.
* **Frontend (HTML, CSS, JavaScript)** - Arquivos de interface do usuário, localizados na pasta `wwwroot/`.

---

### 1. Funcionalidades do Backend

O backend foi construído com C# e o framework ASP.NET Core, criando uma API RESTful leve e de alto desempenho.

* **Contador de Valores:** Utiliza uma estrutura de dados em memória (`ConcurrentDictionary`) para contar, de forma segura entre requisições, quantas vezes cada valor foi recebido desde a inicialização do servidor.
* **API RESTful Completa:** Expõe um conjunto de endpoints para interagir com os dados de contagem.

#### Endpoints da API

A base da URL da API é `/api/contador`.

| Método HTTP | URL                      | Corpo da Requisição (Exemplo)   | Descrição                                                                        |
| :---------- | :----------------------- | :------------------------------ | :------------------------------------------------------------------------------- |
| `POST`      | `/api/contador`          | `{ "valor": "123" }`            | Incrementa a contagem para o valor enviado e retorna a nova contagem.            |
| `GET`       | `/api/contador`          | -                               | Retorna um objeto JSON com todos os valores e suas respectivas contagens.        |
| `GET`       | `/api/contador/{valor}`  | -                               | Retorna a contagem atual para um valor específico, sem incrementá-la.            |
| `PUT`       | `/api/contador/{valor}`  | `{ "novaContagem": 50 }`        | Define ou atualiza a contagem de um valor para um número específico.             |
| `DELETE`    | `/api/contador/{valor}`  | -                               | Remove um valor e sua contagem do armazenamento em memória.                      |

#### Principais Arquivos do Backend

* `Program.cs`: Classe principal de inicialização e configuração do servidor ASP.NET Core, incluindo os middlewares para servir os arquivos do frontend.
* `ContadorController.cs`: Controlador REST que expõe os endpoints HTTP listados acima.
* `ContadorService.cs`: Serviço que contém a lógica de negócio e gerencia o dicionário de contagens (padrão Singleton).
* `Properties/launchSettings.json`: Arquivo de configuração que define como o Visual Studio deve iniciar a aplicação.

---

### 2. Funcionalidades do Frontend

O frontend é uma aplicação de página única (SPA) simples, desenvolvida com HTML5, CSS3 e JavaScript puro (Vanilla JS), sem a necessidade de frameworks externos.

* Permite que o usuário digite um valor e o envie para o backend.
* Exibe o resultado da última submissão.
* Exibe uma lista com o histórico completo de todos os valores e suas contagens, atualizada em tempo real.
* Consome os endpoints REST do backend de forma assíncrona utilizando a `Fetch API`.

#### Principal Arquivo do Frontend

* `wwwroot/index.html`: Arquivo único que contém a estrutura (HTML), a estilização (CSS) e toda a lógica de interação (JavaScript) da interface do usuário.

---

### 3. Como Executar o Projeto

A arquitetura integrada simplifica muito a execução do projeto.

#### Pré-requisitos
* **.NET SDK** (versão 8 ou superior).
* **Visual Studio 2022** ou **Visual Studio Code** (com a extensão C# Dev Kit).

#### Execução via Visual Studio (Recomendado)
1.  Abra o arquivo da solução (`.sln`) no Visual Studio.
2.  Pressione a tecla **F5** ou clique no botão de "Play" verde na barra de ferramentas.
3.  O Visual Studio irá compilar o projeto, iniciar o servidor e abrir o seu navegador padrão diretamente na aplicação.

#### Execução via Linha de Comando
1.  Abra um terminal na pasta raiz do projeto.
2.  Execute o comando:
    ```sh
    dotnet run
    ```
3.  O terminal mostrará a URL onde a aplicação está rodando (ex: `https://localhost:7123`).
4.  Acesse essa URL em seu navegador.

---

### 4. Observações Finais

* Projeto desenvolvido para fins acadêmicos, cumprindo os requisitos da avaliação.
* Excelente para aprender sobre o desenvolvimento full-stack com a pilha .NET, comunicação cliente-servidor, APIs RESTful e a simplicidade de servir um frontend a partir do backend.
* Apesar de simples, o sistema foi construído com uma arquitetura modular e clara separação de responsabilidades entre Controller e Service no backend.