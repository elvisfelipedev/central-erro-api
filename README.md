<h1 align="center">Codenation em parceria com a Stone - AceleraDev C#</h1>
<br/>
<br/>
<p align="center">
<img style="align-self: center;" src="https://media-exp1.licdn.com/dms/image/C4E0BAQH4L-Uv5VraWA/company-logo_200_200/0?e=2159024400&v=beta&t=Q2t2-l71tzpVk1zKpFUGRDnq4VtCbFe-5QqNxQEoVJw" />
</p>
<br/>
<br/>

<h2 align="center">API Central de Erros</h2>

## Objetivo

Em projetos modernos é cada vez mais comum o uso de arquiteturas baseadas em serviços ou microsserviços. Nestes ambientes complexos, erros podem surgir em diferentes camadas da aplicação (backend, frontend, mobile, desktop) e mesmo em serviços distintos. Desta forma, é muito importante que os desenvolvedores possam centralizar todos os registros de erros em um local, de onde podem monitorar e tomar decisões mais acertadas. Neste projeto vamos implementar um sistema para centralizar registros de erros de aplicações.

A arquitetura do projeto é formada por:

## Backend - API

-   criar _endpoints_ para serem usados pelo frontend da aplicação
-   criar um _endpoint_ que será usado para gravar os logs de erro em um banco de dados relacional
-   a API deve ser segura, permitindo acesso apenas com um token de autenticação válido

## Informações adicionais

### Tecnologias

* .NET Core 3.1
* Entity Framework Core 3.1
* AutoMapper 
* Swagger
* JSON Web Tokens (JWT)
* Docker
* Heroku	

### Boas práticas

* Clean Architecture
* Clean Code
	
## Deploy (porém sem a integração com um banco de dados)

[Backend Heroku](https://stone-centralerroapi.herokuapp.com/swagger/index.html)

## Vídeo de demonstração

(https://www.youtube.com/watch?v=xdbQW63IHkk&feature=youtu.be)
