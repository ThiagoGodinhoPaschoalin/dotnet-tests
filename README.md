# dotnet-tests
Um projeto para centralizar todos os estudos relacionados a testes de unidades.

```
# Documentação:
https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test

# Pré-requisito:
	https://www.docker.com/
	https://dotnet.microsoft.com/download/dotnet/3.1
	https://dotnet.microsoft.com/download/dotnet/5.0
	https://docs.microsoft.com/pt-br/ef/core/cli/dotnet

///Todos os comandos em shell, são considerados que você já está na raiz do projeto!
$ cd {...}/dotnet-tests/
```



------



Criar um contêiner SqlServer no seu docker: 

```
$ cd .\docker_composes\
$ docker-compose -f ./sql_server_compose.yml up -d
```



Criar seu banco de dados já com alguns registros:

```
$ cd .\src\Ef5Domain\
$ dotnet ef database update
```



Executar todos os testes existentes na solução:

```
$ cd .\src\
$ dotnet test ./DotnetTestsSolution.sln --logger "console;verbosity=detailed"
```

