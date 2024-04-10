# locadora_Test

Tecnologias utilizadas:
Visual Studio 2019
.Net Cote 3.1
Sql Server

Packages utilizados:
FluentValidator
Dapper
Swagger
JWT

*Procedimentos para rodar a app:
=> Criar o database e as tabelas utilizando o script localizado no projeto de Infra, na pasta ScriptSql
=> Alterar a Connection String no arquivo appsettings.json apontando para sua máquina.
=> A app será aberta direto na pagina do Swagger
=> Todos os end-points estão fechados, exceto o de usuário. Crie um usuário, faça login e utilize o token gerado para enviar 
as requisições aos end-points desejados
