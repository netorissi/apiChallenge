# apiChallenge

## * Projeto desafio API RESTful stateless sem autenticação

Projeto desenvolvido em C# .NETCore e MySQL que consiste em um simples CRUD de enquetes.

Você pode executar com Docker ou caso não seja com Docker, você terá que fazer algumas alterações.

## Executar COM Docker

**Atenção: Tenha o Docker instalado em sua máquina.**

*Caso não tenha, procure pelo download [AQUI](https://www.docker.com/)*

1. Baixe o projeto, abra o console ou terminal, acesse a pasta raiz do projeto e execute a seguinte linha:

```docker-compose up```

*O banco será iniciado e já será criado as estruturas de tabelas*

Serão criados 3 containers:
- MySQL versão 8 => Banco de dados
- PhpMyAdmin versão 4.8 => Para facilitar o acesso ao banco (user: root, password: secret)
- Aplicação versão 1.0 => Api .NET rodando na porta 5000

2. Agora com a API no ar, basta direcionar seu projeto para os ENDPOINTS, também pode utilizar o [Postman](https://www.getpostman.com/downloads/), [Insomnia](https://insomnia.rest/download/), ou outro de sua preferência:

*Todos os endpoints deverão	ser	com	Content-Type: application/json.*

- Inserir uma enquete:

**POST** ```http://localhost:5000/api/v1/poll```

- Corpo da requisição:
```
{
    "poll_description": "This is the question",
    "options": [
        "First Option",
        "Second Option",
        "Third Option"
    ]
}
```

- Consultar uma enquete: *Params: {id} da enquete*

**GET** ```http://localhost:5000/api/v1/poll/{id}```

- Inserir um voto em uma enquete: *Params: {id} da enquete*

**POST** ```http://localhost:5000/api/v1/poll/{id}/vote```

- Corpo da requisição deve conter a opção a ser votada:
```
{
    "option_id": 1
}
```

- Consultar estatísticas de uma enquete: *Params: {id} da enquete*

**GET** ```http://localhost:5000/api/v1/poll/{id}/stats```

- Consultar todas as enquetes:

**GET** ```http://localhost:5000/api/v1/poll```

*Você pode acessar o phpmyadmin na porta 3010 caso seja necessário.*

## Executar SEM Docker

**Atenção: Tenha o dotnetSDK2.2 instalado em sua máquina.**

1. Baixe o projeto e execute um servidor com um banco MySql utilizando o arquivo sql disponível em **./schema/init.sql**

2. Vá até o arquivo *appsettings.json* que está dentro da pasta *Poll_Challenge_Api* e altere a seguinte linha de código:

```"PollDatabase": "Server=api_db;Port=3306;Database=poll_challenge;Uid=root;Pwd=secret;"```

Para: **Atenção: Altere os campos PORTADOSEUBANCO, SEUUSER e SEUPWD contendo seus dados do banco.**

```"PollDatabase": "Server=localhost;Port=PORTADOSEUBANCO;Database=poll_challenge;Uid=SEUUSER;Pwd=SEUPWD;"```

3. No console ou terminal, acesse a pasta raiz do projeto e execute o seguinte comando:

```dotnet publish -o ./dist```

4. Após gerar o .dll, execute os comandos:

```
cd dist
dotnet Poll_Challenge_Api.dll
```

5. Pronto. Acesse os ENDPOINTS citados acima.