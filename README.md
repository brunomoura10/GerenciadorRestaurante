# Sistema de Reservas Online para Restaurantes

# Integrantes do grupo
#### Bruno Moura - RM 350846
#### Marcos André - RM 351923
#### Tiago Vazzoller - RM 351733
#### Victor Hugo - RM 351315

# Apresentação
(https://youtu.be/JbS5SPhR3dI)

## Introdução

Este documento descreve a arquitetura e a implementação de um sistema de reservas online para restaurantes. O sistema permite que os usuários façam reservas, visualizem pratos e gerenciem mesas e cardápios de restaurantes.

## Caso

Como parte de sua constante evolução e compromisso com a excelência no gerenciamento de informações relacionadas a reservas e administração de restaurantes, a Confederação de Restaurantes do Brasil (CRB) reconheceu a necessidade de desenvolver uma API (Interface de Programação de Aplicativos) robusta e eficiente.

Esta iniciativa visa simplificar e aprimorar a forma como os dados essenciais dos restaurantes brasileiros são acessados, gerenciados e compartilhados. Com a crescente complexidade das operações envolvendo reservas, gerenciamento de mesas, pratos e usuários, a CRB reconhece a importância de estabelecer um sistema tecnologicamente avançado que promova a transparência, precisão e acessibilidade aos dados relacionados ao setor de restaurantes.

## Requisitos do Sistema

### Funcionais
- Cadastro de restaurantes
- Cadastro de pratos
- Gerenciamento de mesas
- Criação de reservas
- Visualização de pratos disponíveis em cada restaurante

### Não Funcionais
- O sistema deve ser escalável e de fácil manutenção.
- A aplicação deve ser desenvolvida com base nos princípios de Arquitetura Limpa.
- A persistência dos dados deve ser feita em um banco de dados relacional.

## Arquitetura do Sistema

O sistema é projetado com base nos princípios da Arquitetura Limpa, separando claramente as camadas de domínio, aplicação, infraestrutura e apresentação/UI.

### Camadas:
- **Domínio**: Contém as entidades e interfaces principais do sistema.
- **Aplicação**: Contém a lógica de aplicação e serviços.
- **Infraestrutura**: Contém a implementação dos repositórios, contexto do banco de dados e configurações.
- **Apresentação/UI**: Contém os controladores da API e modelos de entrada/saída.

## Testes

### Testes Unitários
- Foi utilizado o framework de testes NUnit para criar testes unitários para as lógicas de negócio.
- Foi criado mocks das dependências usando Moq.

## Endpoints da API

### Restaurante Endpoint

- **Cadastrar Restaurante**
  - Endpoint: `POST /api/restaurante/cadastrar-restaurante`
  - Descrição: Cadastra um novo restaurante.
  - Requisição: Corpo contendo os detalhes do restaurante.
  - Resposta: 
    - 200 OK: Restaurante cadastrado com sucesso.
    - 400 Bad Request: Erro ao cadastrar o restaurante.

- **Atualizar Restaurante**
  - Endpoint: `PUT /api/restaurante/atualizar-restaurante/{id}`
  - Descrição: Atualiza os dados de um restaurante específico.
  - Parâmetros: ID do restaurante a ser atualizado.
  - Requisição: Corpo contendo os detalhes atualizados do restaurante.
  - Resposta: 
    - 200 OK: Restaurante atualizado com sucesso.
    - 400 Bad Request: Erro ao atualizar o restaurante.

- **Excluir Restaurante**
  - Endpoint: `DELETE /api/restaurante/excluir-restaurante/{id}`
  - Descrição: Exclui (desativa) um restaurante específico.
  - Parâmetros: ID do restaurante a ser excluído.
  - Resposta: 
    - 200 OK: Restaurante excluído com sucesso.
    - 400 Bad Request: Erro ao excluir o restaurante.

- **Obter Todos os Restaurantes**
  - Endpoint: `GET /api/restaurante/obter-todos`
  - Descrição: Retorna uma lista de todos os restaurantes cadastrados.
  - Resposta: 
    - 200 OK: Lista de restaurantes.
    - 400 Bad Request: Erro ao obter os restaurantes.

- **Obter Restaurante por ID**
  - Endpoint: `GET /api/restaurante/obter-por-id/{id}`
  - Descrição: Retorna os detalhes de um restaurante específico pelo ID.
  - Parâmetros: ID do restaurante a ser obtido.
  - Resposta: 
    - 200 OK: Detalhes do restaurante.
    - 400 Bad Request: Erro ao obter o restaurante.

- **Obter Restaurante com Reservas por Data**
  - Endpoint: `GET /api/restaurante/obter-restaurante-com-reserva-por-data/{id}/{data}`
  - Descrição: Retorna os detalhes de um restaurante específico e suas reservas em uma data específica.
  - Parâmetros: ID do restaurante, Data das reservas.
  - Resposta: 
    - 200 OK: Detalhes do restaurante com reservas na data especificada.
    - 400 Bad Request: Erro ao obter o restaurante e reservas.

### RestaurantePrato Endpoint

- **Cadastrar Prato para Restaurante**
  - Endpoint: `POST /api/restauranteprato/cadastrar-restaurante-prato`
  - Descrição: Cadastra um novo prato para um restaurante específico.
  - Requisição: Corpo contendo os detalhes do prato e o ID do restaurante.
  - Resposta: 
    - 200 OK: Prato cadastrado com sucesso.
    - 400 Bad Request: Erro ao cadastrar o prato.

- **Obter Prato de Restaurante por ID**
  - Endpoint: `GET /api/restauranteprato/obter-restaurante-prato/{id}`
  - Descrição: Retorna os detalhes de um prato específico pelo ID.
  - Parâmetros: ID do prato a ser obtido.
  - Resposta: 
    - 200 OK: Detalhes do prato.
    - 400 Bad Request: Erro ao obter o prato.

- **Obter Todos os Pratos de Restaurantes**
  - Endpoint: `GET /api/restauranteprato/obter-todos-restaurante-prato`
  - Descrição: Retorna uma lista de todos os pratos cadastrados para todos os restaurantes.
  - Resposta: 
    - 200 OK: Lista de pratos.
    - 400 Bad Request: Erro ao obter os pratos.

- **Atualizar Prato de Restaurante**
  - Endpoint: `PUT /api/restauranteprato/atualizar-restaurante-prato/{id}`
  - Descrição: Atualiza os dados de um prato específico.
  - Parâmetros: ID do prato a ser atualizado.
  - Requisição: Corpo contendo os detalhes atualizados do prato.
  - Resposta: 
    - 200 OK: Prato atualizado com sucesso.
    - 400 Bad Request: Erro ao atualizar o prato.

### Reserva Endpoint

- **Cadastrar Reserva**
  - Endpoint: `POST /api/reserva/cadastrar-reserva`
  - Descrição: Cadastra uma nova reserva.
  - Requisição: Corpo contendo os detalhes da reserva.
  - Resposta: 
    - 200 OK: Reserva cadastrada com sucesso.
    - 400 Bad Request: Erro ao cadastrar a reserva.

- **Consultar Reserva por ID**
  - Endpoint: `GET /api/reserva/consultar-reserva/{id}`
  - Descrição: Retorna os detalhes de uma reserva específica pelo ID.
  - Parâmetros: ID da reserva a ser consultada.
  - Resposta: 
    - 200 OK: Detalhes da reserva.
    - 404 Not Found: Reserva não encontrada.
    - 400 Bad Request: Erro ao consultar a reserva.

- **Consultar Todas as Reservas**
  - Endpoint: `GET /api/reserva/consultar-reservas`
  - Descrição: Retorna uma lista de todas as reservas cadastradas.
  - Resposta: 
    - 200 OK: Lista de reservas.
    - 400 Bad Request: Erro ao consultar as reservas.

- **Deletar Reserva**
  - Endpoint: `DELETE /api/reserva/deletar-reserva/{id}`
  - Descrição: Deleta (cancela) uma reserva específica pelo ID.
  - Parâmetros: ID da reserva a ser deletada.
  - Resposta: 
    - 204 No Content: Reserva deletada com sucesso.
    - 400 Bad Request: Erro ao deletar a reserva.

- **Atualizar Reserva**
  - Endpoint: `PUT /api/reserva/atualizar-reserva/{id}`
  - Descrição: Atualiza os dados de uma reserva específica.
  - Parâmetros: ID da reserva a ser atualizada.
  - Requisição: Corpo contendo os detalhes atualizados da reserva.
  - Resposta: 
    - 200 OK: Reserva atualizada com sucesso.
    - 400 Bad Request: Erro ao atualizar a reserva.

### Mesa Endpoint

- **Cadastrar Mesa**
  - Endpoint: `POST /api/mesa/cadastrar-mesa`
  - Descrição: Cadastra uma nova mesa.
  - Requisição: Corpo contendo os detalhes da mesa.
  - Resposta: 
    - 200 OK: Mesa cadastrada com sucesso.
    - 400 Bad Request: Erro ao cadastrar a mesa.

- **Atualizar Mesa**
  - Endpoint: `PUT /api/mesa/atualizar-mesa/{id}`
  - Descrição: Atualiza os dados de uma mesa específica.
  - Parâmetros: ID da mesa a ser atualizada.
  - Requisição: Corpo contendo os detalhes atualizados da mesa.
  - Resposta: 
    - 200 OK: Mesa atualizada com sucesso.
    - 400 Bad Request: Erro ao atualizar a mesa.

- **Excluir Mesa**
  - Endpoint: `DELETE /api/mesa/excluir-mesa/{id}`
  - Descrição: Exclui (desativa) uma mesa específica.
  - Parâmetros: ID da mesa a ser excluída.
  - Resposta: 
    - 200 OK: Mesa excluída com sucesso.
    - 400 Bad Request: Erro ao excluir a mesa.

- **Obter Mesas de um Restaurante**
  - Endpoint: `GET /api/mesa/obter-mesas/{idRestaurante}`
  - Descrição: Retorna uma lista de todas as mesas de um restaurante específico.
  - Parâmetros: ID do restaurante.
  - Resposta: 
    - 200 OK: Lista de mesas.
    - 400 Bad Request: Erro ao obter as mesas.

### Testes

#### Objetivo
- Testar o comportamento e as funcionalidades da aplicação conforme os requisitos.
- Garantir que a aplicação atende aos critérios de aceitação definidos.

#### Metodologia
- Foram implementados testes unitários, de integração e de aceitação para validar a aplicação.
- Frameworks utilizados: NUnit, Moq.

## Para rodar o projeto

### Clone o Projeto
Clone o projeto usando Visual Studio 2022 ou Visual Studio Code.

### Instale o .Net 7.0
Caso não tenha o .Net 7.0 instalado, faça o download no link abaixo:
[.Net 7.0 Download](https://dotnet.microsoft.com/pt-br/download/dotnet/7.0)

### Configuração do Banco de Dados
Este projeto está usando o SQL Server. Você pode usar a instância do SQL Server instalada em sua máquina ou via Docker.

#### Via Docker
Execute o seguinte comando para rodar o SQL Server no Docker:
```sh docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest```

#### Configuração do appsettings
Em appsettings.Development.json, coloque a string de conexão com seus dados:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;"
  }
}

## Considerações Finais

Este projeto visa fornecer uma solução eficiente e escalável para o gerenciamento de reservas em restaurantes, com uma arquitetura bem definida e aderente às melhores práticas de desenvolvimento de software.
