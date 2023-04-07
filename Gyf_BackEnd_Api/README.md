# Documentación de desarrollo para Web API de .NET 7

Esta Web API de .NET 7 es una prueba de concepto que utiliza las últimas tecnologías para grabar logs en Grafana Loki a través de Serilog.

## Tecnologías utilizadas

- .NET 7
- Serilog
- Grafana Loki

## Requisitos previos

- .NET 7 SDK
- Grafana Loki
- VS 2022 ya posee todos los requisitos

## Configuración del entorno

1. Descargar e instalar el .NET 7 SDK.
2. Descargar e instalar Grafana Loki.
3. Configurar la conexión con Grafana Loki en la aplicación a través de la configuración de Serilog.

## Instalación

1. Clonar o descargar el repositorio de la aplicación.
2. Ejecutar "dotnet run" para compilar y ejecutar la aplicación.

## Estructura del proyecto

El proyecto sigue la estructura convencional de una aplicación de .NET 7. Las carpetas principales son: Controllers, Models, Services, y Properties.

## Arquitectura

La aplicación sigue una arquitectura MVC (Modelo-Vista-Controlador).

## Base de datos

No se utiliza una base de datos en la aplicación.

## Endpoints

La API tiene los siguientes endpoints:

- GET  http://localhost:5041/api/Gyf/
- GET  http://localhost:5041/api/Gyf/id?id=28
- POST http://localhost:5041/api/Gyf/
	{
	  "nombre": "Sistema de Prueba",
	  "descripcion": "Sistema desde postman",
	  "usuario": "LOYS",
	  "tipoLicencia": "anual"
	}
- PUT http://localhost:5041/api/Gyf/
	{
	  "Id":10, 
	  "nombre": "Sistema de Prueba",
	  "descripcion": "Sistema desde postman",
	  "usuario": "LOYS",
	  "tipoLicencia": "anual"
	}
- DELETE http://localhost:5041/api/Gyf/1

## Autenticación y autorización

No se implementa autenticación o autorización en la aplicación.

## Mejoras futuras

Algunas mejoras futuras que se desean implementar son: añadir autenticación y autorización, implementar pruebas de rendimiento, y agregar más endpoints.

## Contribución

Si deseas contribuir al proyecto, puedes hacer un fork del repositorio, hacer tus cambios y enviar una solicitud de extracción.

## Licencia

La aplicación utiliza la licencia MIT.

## Contacto

Puedes contactar al equipo de desarrollo a través del correo electrónico lramirez@gyf.com.ar 
