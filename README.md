# 👨‍💻 Rick & Morty API

Este proyecto es un backend desarrollado en ASP.NET Core que funciona como capa intermedia
entre un frontend y la API pública de Rick & Morty.

El objetivo principal es demostrar el consumo de una API externa, el manejo de datos
persistidos en MySQL y la aplicación de una arquitectura limpia y escalable.

## Contexto

Esta API fue desarrollada como parte de una actividad técnica enfocada en:

- Integración con servicios externos
- Diseño de APIs REST
- Persistencia de datos
- Separación por capas
- Buenas prácticas en .NET

El backend no consume directamente la API pública desde el frontend,
sino que actúa como intermediario, permitiendo control, cache y escalabilidad.

## Arquitectura

El proyecto está organizado siguiendo el enfoque de Clean Architecture:

RickMorty.Api → Capa de presentación (Controllers, Middleware)
RickMorty.Application → Lógica de negocio, DTOs, Servicios
RickMorty.Domain → Entidades del dominio
RickMorty.Infrastructure → Persistencia, EF Core, API externa

Esta separación permite:

- Reducir el acoplamiento
- Facilitar mantenimiento
- Escalar funcionalidades
- Mejorar testabilidad

## Tecnologías

- .NET 8 +
- ASP.NET Core Web API
- Entity Framework Core
- MySQL 8 +
- HttpClient
- Swagger
- Pomelo MySQL Provider

## Requerimientos

Antes de ejecutar el proyecto se requiere:

- .NET SDK 8 o superior
- MySQL Server 8+
- Git
- Navegador web

##  Configuración

### 1. Clonar el repositorio

```Bash
git clone https://github.com/dany56col/rickmorty-backend
cd rickMorty
