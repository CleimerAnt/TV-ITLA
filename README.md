# Proyecto en Capas - CRUD de Películas

Este es un proyecto desarrollado en **.NET** utilizando una arquitectura en capas. Su objetivo principal es gestionar un **CRUD** para agregar películas, junto con su género y productora.

## Tecnologías y patrones utilizados:

- **Entity Framework Core:** Para el manejo de datos y mapeo objeto-relacional (ORM).
- **Patrón Repositorio:** Implementado para la gestión y manipulación de las entidades del proyecto.
- **Docker:** Dockericé el proyecto para facilitar su despliegue y configuración.
- **Docker Compose:** Creé un archivo `docker-compose.yml` que permite levantar:
  - Una instancia del proyecto en .NET.
  - Una instancia de **SQL Server** como base de datos, utilizando la versión **2022** de la imagen oficial.

## Características:

- **Gestión de películas:** Agregar, editar, eliminar y listar películas.
- **Asociación de datos:** Cada película incluye un género y una productora.
- **Despliegue sencillo:** Gracias a Docker Compose, puedes arrancar tanto la aplicación como la base de datos con un solo comando.

## Requisitos previos:

- **Docker** instalado en tu máquina.
- **Docker Compose** configurado correctamente.

## Instrucciones para ejecutar el proyecto:

1. Clona este repositorio en tu máquina local.
2. Navega a la carpeta raíz del proyecto.
3. Ejecuta el siguiente comando para levantar los servicios:
   ```bash
   docker-compose up

 ## Enlaces:

- [Repositorio en Docker Hub](https://hub.docker.com/r/cleimer24/tv-itla/tags)

