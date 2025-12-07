# Plataforma Web de Gestión y Renta de Maquinaria Pesada

**Estudiante:** Michael Armani Gonzalez Arciga
**Proyecto:** Maquinaria del Bajío
**Fecha:** 07 de Diciembre, 2025

## 1\. Descripción del Proyecto

El proyecto consiste en el desarrollo del componente Backend para una solución de software tipo Full-Stack, orientada a la administración y renta de maquinaria pesada. Su propósito principal es digitalizar y optimizar el proceso de alquiler de equipos, centralizando la gestión del inventario y automatizando la cotización de servicios.

### Funcionalidad Principal

El sistema funciona como una API RESTful que procesa la lógica de negocio y la persistencia de datos para una plataforma web. Sus funciones críticas incluyen:

  * **Gestión de Identidad:** Administración de usuarios mediante roles (Cliente y Administrador) y seguridad basada en tokens.
  * **Control de Inventario:** Permite a los administradores registrar, actualizar y eliminar maquinaria del catálogo.
  * **Motor de Procesamiento de Rentas:** Algoritmo que valida la disponibilidad de equipos en rangos de fechas específicos y calcula automáticamente los costos totales de arrendamiento, asegurando la integridad de las transacciones y evitando conflictos de agenda.

## 2\. Tecnologías Utilizadas

  * **Lenguaje y Framework:** .NET 8 (C\#) Web API.
  * **Base de Datos:** PostgreSQL (Ejecutado mediante contenedor Docker).
  * **ORM:** Entity Framework Core para la manipulación de datos.
  * **Seguridad:** Implementación de JSON Web Tokens (JWT) para autenticación y autorización.
  * **Validación:** FluentValidation para garantizar la integridad de los datos de entrada.

## 3\. Endpoints Principales de la API

La API expone diversos servicios para la operación del sistema. A continuación, se describen los 5 endpoints más relevantes por su importancia algorítmica y de negocio:

### I. Autenticación de Usuarios

  * **Método:** POST
  * **Ruta:** `/api/Auth/login`
  * **Descripción:** Recibe las credenciales del usuario (correo y contraseña), valida la información contra la base de datos utilizando hash criptográfico y retorna un Token JWT que incluye el rol y el ID del usuario para autorizar transacciones subsecuentes.

### II. Registro de Clientes

  * **Método:** POST
  * **Ruta:** `/api/Auth/register`
  * **Descripción:** Permite la creación de nuevas cuentas de usuario con el rol de cliente. El sistema valida que el correo electrónico no esté previamente registrado antes de crear la entidad.

### III. Catálogo de Maquinaria

  * **Método:** GET
  * **Ruta:** `/api/Machinery`
  * **Descripción:** Servicio público que recupera el listado completo de equipos disponibles, incluyendo sus especificaciones técnicas, precio por día e imágenes, para ser consumidos por el cliente web.

### IV. Alta de Inventario (Administrador)

  * **Método:** POST
  * **Ruta:** `/api/Machinery`
  * **Descripción:** Endpoint protegido exclusivo para administradores. Permite registrar un nuevo equipo en la base de datos. Requiere un Token JWT válido con permisos de administrador en la cabecera de la petición.

### V. Procesamiento de Renta (Algorítmico)

  * **Método:** POST
  * **Ruta:** `/api/Rental/rent`
  * **Descripción:** Este servicio ejecuta la lógica central del negocio. Recibe el ID de la máquina y el rango de fechas solicitado. El algoritmo realiza lo siguiente:
    1.  Verifica la existencia y estado de la máquina.
    2.  Consulta en la base de datos si existen conflictos de horario con otras rentas activas para ese equipo (validación de traslape).
    3.  Calcula el monto total a pagar multiplicando los días efectivos por la tarifa diaria.
    4.  Genera el registro de renta en la base de datos con estatus activo.

## 4\. Instrucciones de Ejecución

A continuación se detallan los pasos para desplegar el proyecto en un entorno local.

### Requerimientos del Sistema

  * Sistema Operativo: Windows, macOS o Linux.
  * Docker Desktop (Instalado y en ejecución).
  * .NET 8 SDK.
  * Postman (Para pruebas de los servicios).

### Pasos de Instalación y Configuración

1.  **Clonar el repositorio:**
    Descargue el código fuente en su equipo local.

2.  **Configuración de la Base de Datos:**
    El proyecto requiere una instancia de PostgreSQL. Navegue a la carpeta `Backend` desde su terminal y ejecute el siguiente comando para levantar el contenedor:

    ```bash
    docker-compose up -d
    ```

3.  **Ejecución del Servidor (API):**

      * Abra una terminal y navegue a la carpeta del proyecto API:
        ```bash
        cd Backend/API
        ```
      * Restaure las dependencias y ejecute el proyecto:
        ```bash
        dotnet restore
        dotnet run
        ```
      * El servidor iniciará y estará escuchando peticiones en el puerto asignado (generalmente `http://localhost:5093`).

> **Nota Importante:** Al iniciar la aplicación por primera vez, el sistema ejecutará automáticamente las migraciones pendientes para crear la estructura de la base de datos y generará un usuario administrador por defecto.

### Consideraciones Adicionales

  * **Colección de Postman Automatizada:**
    En la raíz de este repositorio se incluye el archivo `Maquinaria_API.postman_collection.json`. Esta colección está configurada con variables de entorno (`{{baseUrl}}`) y scripts de prueba que capturan automáticamente el Token JWT al iniciar sesión, facilitando la prueba de los endpoints protegidos sin necesidad de copiar y pegar el token manualmente.

  * **Credenciales de Administrador por defecto:**

      * Correo: admin@renta.com
      * Contraseña: Admin132

**Enlace al Video Demostrativo:**
[PEGAR AQUI EL ENLACE DE YOUTUBE]
