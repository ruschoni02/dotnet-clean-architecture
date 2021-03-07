# Dotnet Clean Architecture

Projeto exemplo de utilização de Clean Architecture com Dotnet

Nesse projeto teremos uma API de Distribuição de Lucros, utilizando a Clean Architecture para implementação da mesma.

## Rodando o projeto

Para rodar o projeto, podemos utilizar o proprio build da IDE ou podemos utilizar o docker.

Para utilização do docker, precisamos rodar o seguinte comando:

```
docker-compose up --build
```

## Testes unitários

Os testes unitários estão cobrindo nosso caso de uso para garantir nossas regras de negócio.

Para rodar os testes:

```
dotnet test
```

## Makefile

O projeto conta com suporte de Makefile. Nele temos os seguintes comandos:

- `make up`: Para subir a api utilizando o docker
- `make test`: Para rodar os testes unitários
- `make coverage`: Para rodar os testes com análise de cobertura
