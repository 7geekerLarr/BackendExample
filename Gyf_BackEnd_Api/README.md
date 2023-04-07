# Documentaci�n de desarrollo para Web API de .NET 7

Esta Web API de .NET 7 es una prueba de concepto que utiliza las �ltimas tecnolog�as para grabar logs en Grafana Loki a trav�s de Serilog.

## Tecnolog�as utilizadas

- .NET 7
- Serilog
- Grafana Loki

## Requisitos previos

- .NET 7 SDK
- Grafana Loki
- VS 2022 ya posee todos los requisitos

## Configuraci�n del entorno

1. Descargar e instalar el .NET 7 SDK.
2. Descargar e instalar Grafana Loki.
3. Configurar la conexi�n con Grafana Loki en la aplicaci�n a trav�s de la configuraci�n de Serilog.

## Instalaci�n

1. Clonar o descargar el repositorio de la aplicaci�n.
2. Ejecutar "dotnet run" para compilar y ejecutar la aplicaci�n.

## Estructura del proyecto

El proyecto sigue la estructura convencional de una aplicaci�n de .NET 7. Las carpetas principales son: Controllers, Models, Services, y Properties.

## Arquitectura

La aplicaci�n sigue una arquitectura MVC (Modelo-Vista-Controlador).

## Base de datos

No se utiliza una base de datos en la aplicaci�n.

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

## Autenticaci�n y autorizaci�n

No se implementa autenticaci�n o autorizaci�n en la aplicaci�n.

## Mejoras futuras

Algunas mejoras futuras que se desean implementar son: a�adir autenticaci�n y autorizaci�n, implementar pruebas de rendimiento, y agregar m�s endpoints.

## Contribuci�n

Si deseas contribuir al proyecto, puedes hacer un fork del repositorio, hacer tus cambios y enviar una solicitud de extracci�n.

## Licencia

La aplicaci�n utiliza la licencia MIT.

## Contacto

Puedes contactar al equipo de desarrollo a trav�s del correo electr�nico lramirez@gyf.com.ar 
