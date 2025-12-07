Backend - Plataforma de Renta de Maquinaria

Estudiante: Michael Armani Gonzalez Arciga Materia: Desarrollo de Software Fecha: 30 de Noviembre, 2025
Descripción del Proyecto

Este repositorio contiene el código fuente del Backend para la plataforma "Maquinaria del Bajío". Se trata de una API RESTful desarrollada en .NET 8 que sirve como el motor lógico y de datos para un sistema de renta de maquinaria pesada.

El propósito principal de este backend es centralizar la gestión del inventario y automatizar el proceso de renta, asegurando que las reglas de negocio (como la disponibilidad de fechas y el cálculo de costos) se cumplan de manera estricta y segura.
Funcionalidades Principales

    Autenticación y Seguridad: Sistema de Login y Registro protegido con JWT (JSON Web Tokens). Incluye roles de usuario (Cliente y Administrador).

    Gestión de Inventario: Permite a los administradores agregar maquinaria a la base de datos y eliminarla.

    Motor de Rentas: Lógica compleja que recibe fechas de renta, valida que la maquinaria no esté ocupada en ese rango y calcula el costo total automáticamente.

    Historial de Cliente: Permite a los usuarios consultar sus rentas activas y pasadas.

    Devolución de Equipos: Proceso para finalizar una renta y liberar la maquinaria.

🔌 Lista Completa de Endpoints

La API cuenta con los siguientes servicios distribuidos por controladores:
1. Autenticación (AuthController)
Método	Ruta	Descripción	Acceso
POST	/api/Auth/register	Registra un nuevo usuario con rol de Cliente.	Público
POST	/api/Auth/login	Autentica credenciales y devuelve Token JWT + Datos del Usuario.	Público
POST	/api/Auth/change-password	Permite al usuario autenticado cambiar su contraseña.	User/Admin
2. Maquinaria (MachineryController)
Método	Ruta	Descripción	Acceso
GET	/api/Machinery	Obtiene la lista completa de equipos disponibles.	Público
GET	/api/Machinery/{id}	Obtiene los detalles de una máquina específica por su ID.	Público
POST	/api/Machinery	Crea una nueva máquina en el inventario.	Admin
DELETE	/api/Machinery/{id}	Elimina una máquina del catálogo permanentemente.	Admin
3. Rentas (RentalController)
Método	Ruta	Descripción	Acceso
POST	/api/Rental/rent	(Algorítmico) Procesa una nueva renta, valida fechas y calcula costos.	User/Admin
GET	/api/Rental/my-rentals	Obtiene el historial de rentas del usuario logueado.	User/Admin
POST	/api/Rental/return/{id}	Marca una renta como finalizada (Devolución del equipo).	User/Admin
Instrucciones para Ejecutar el Proyecto

Sigue estos pasos para levantar el servidor y la base de datos en tu computadora.
Requerimientos del Sistema

    Docker Desktop (para la base de datos).

    .NET 8 SDK.

    Postman (para pruebas).

1. Configurar la Base de Datos

El proyecto incluye un archivo docker-compose.yml en la raíz de este repositorio.

    Abre una terminal en la carpeta raíz del proyecto.

    Ejecuta:
    Bash

    docker-compose up -d

2. Iniciar el Servidor (API)

    Ingresa a la carpeta del proyecto API:
    Bash

cd API

Restaura paquetes e inicia:
Bash

    dotnet restore
    dotnet run

    Verás un mensaje indicando que el servidor está escuchando en: http://localhost:5093.

    Nota: Al iniciar, el sistema ejecutará automáticamente las migraciones y creará el usuario administrador por defecto.

3. Credenciales de Administrador

Para acceder a las funciones de gestión, utiliza la siguiente cuenta pre-configurada:

    Correo: admin@renta.com

    Contraseña: admin132

Colección de Postman

En la raíz de este repositorio encontrarás el archivo: Maquinaria_API.postman_collection.json

Esta colección incluye:

    Variables de entorno ({{baseUrl}}) preconfiguradas.

    Scripts de automatización para capturar el Token JWT al hacer Login.

    Ejemplos de peticiones para todos los endpoints listados arriba.

Video Demostrativo

Evidencia del funcionamiento del sistema:

[PEGAR AQUI TU ENLACE DE YOUTUBE]
