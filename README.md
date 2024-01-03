# TektonLabs Prueba.Net 

Repositorio que resuelve prueba técnica.

## Requerimientos para correr en tu ambiente
- [.NET 8](https://dotnet.microsoft.com/download/dotnet)
- [Sql Server 2019](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/community/) o [Visual Studio Code](https://code.visualstudio.com/)


## Tecnologías  utlizadas en el proyecto

- .NET 8
- ASP.NET CORE WEB API 
- Swagger/Swagger UI
- MediatR
- AutoMapper
- Entity Framework Core
- SQL SERVER
- Lazy Caché
- Logging

**Unit Tests / Integration Tests**

- XUnit
- Moq
- AutoFixture

## Arquitecturas

- Clean Architecture 
- SOLID
- Fluent Validation 

## Patrones de diseño

- Mediator
- Dependency Injection
- Inversion of control
- Repository
- CQRS (Command Query Responsability Segregation)

## Estrategias

- Domain Driven Design (DDD)
- Test Driven Development (TDD)
- Command Query Responsability Segregation (CQRS)  
- Entity Framework Code First
- Linq / Lambda expressions

## Despues de ejecutar

**URLS**

- Swagger UI: https://localhost:7292/swagger/index.html

# Migración de la Base de Datos
- Configurar cadena de conexión en el archivo appsettings.json 
 
- Ejecutar en la consola: 
```bash
  update-database
```
## PROYECTOS DE LA SOLUCIÓN
 

| Proyecto                 | Tipo       | Descripción                |
| :----------------------- | :--------- | :------------------------- |
| `Tekton.Api`             | `Wep Api`  | Proyecto principal API REST|
| `Tekton.Infraestructure` | `Librería` | Proyecto infraestructura   |
| `Tekton.Dominio`         | `Librería` | Proyecto de dominio        |
| `Tekton.Application`     | `Librería` | Proyecto de aplicación     |

## Consumo de Api Externa en https://mockapi.io/
```bash
https://659424861493b011606a000f.mockapi.io/api/v1/ApiDiscount/1
```

## Autor

- [@alanhuanca](https://www.github.com/alanhuanca)




