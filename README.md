SISTEMA DE GESTIÓN Y RENTA DE MAQUINARIA PESADA

Instituto Sanmiguelense / Universidad de Guanajuato Materia: Desarrollo de Software Estudiante: Michael Armani Gonzalez Arciga Proyecto: Maquinaria del Bajío Fecha de Entrega: 07 de Diciembre, 2025
1. DESCRIPCIÓN DEL PROYECTO

El presente repositorio contiene el código fuente correspondiente al componente Backend de la plataforma "Maquinaria del Bajío". Esta solución tecnológica fue desarrollada bajo una arquitectura de API RESTful con el objetivo de digitalizar el ciclo comercial de renta de maquinaria para la industria de la construcción.

El sistema centraliza la operación del negocio, permitiendo la gestión de inventarios en tiempo real, la administración de usuarios y la automatización de cálculos de arrendamiento, sustituyendo procesos manuales propensos a errores por un flujo de trabajo validado y seguro.
Funcionalidad Principal

El sistema opera mediante una arquitectura cliente-servidor que permite:

    Gestión de Identidad: Administración de usuarios mediante roles (Cliente y Administrador) y seguridad basada en tokens cifrados.

    Control de Inventario: Permite a los administradores registrar, actualizar y eliminar maquinaria del catálogo.

    Motor de Procesamiento de Rentas: Algoritmo que valida la disponibilidad de equipos en rangos de fechas específicos y calcula automáticamente los costos totales de arrendamiento, asegurando la integridad de las transacciones y evitando conflictos de agenda.

2. ARQUITECTURA TÉCNICA

El desarrollo se fundamentó en tecnologías robustas y escalables de la plataforma .NET.
Componente	Tecnología Seleccionada	Propósito
Lenguaje	C# (C Sharp)	Lógica de programación orientada a objetos.
Framework	.NET 8 Web API	Construcción de servicios RESTful de alto rendimiento.
Base de Datos	PostgreSQL	Sistema de gestión de base de datos relacional (ejecutado en Docker).
ORM	Entity Framework Core	Abstracción y manipulación de datos.
Seguridad	JWT (JSON Web Tokens)	Autenticación y autorización basada en estándares.
Validación	FluentValidation	Reglas de negocio y validación de entrada de datos.
3. DOCUMENTACIÓN DE LA API (ENDPOINTS)

La API expone los siguientes recursos organizados por módulos funcionales.
Módulo de Autenticación
Método	Endpoint	Acceso	Descripción
POST	/api/Auth/register	Público	Registra una nueva cuenta de usuario con rol de cliente. Valida duplicidad de correos.
POST	/api/Auth/login	Público	Verifica credenciales. Retorna un Token JWT, nombre y rol del usuario.
POST	/api/Auth/change-password	Autenticado	Permite al usuario actualizar su contraseña actual por una nueva.
Módulo de Maquinaria (Inventario)
Método	Endpoint	Acceso	Descripción
GET	/api/Machinery	Público	Obtiene el listado completo del inventario disponible con sus detalles técnicos.
GET	/api/Machinery/{id}	Público	Recupera la información detallada de una unidad específica por su identificador.
POST	/api/Machinery	Admin	Registra una nueva maquinaria en la base de datos.
DELETE	/api/Machinery/{id}	Admin	Elimina una unidad del catálogo de manera permanente.
Módulo de Rentas (Operaciones)
Método	Endpoint	Acceso	Descripción
POST	/api/Rental/rent	Autenticado	Proceso Algorítmico Principal. Valida disponibilidad de fechas, calcula el costo total y registra la transacción.
GET	/api/Rental/my-rentals	Autenticado	Devuelve el historial de rentas filtrado exclusivamente para el usuario que realiza la petición.
POST	/api/Rental/return/{id}	Autenticado	Finaliza un contrato de renta activo, cambiando su estatus a "Finalizada".
4. GUÍA DE INSTALACIÓN Y EJECUCIÓN

Para desplegar el proyecto en un entorno local de desarrollo, siga los pasos descritos a continuación.
Prerrequisitos

    SDK de .NET 8.0 instalado.

    Docker Desktop instalado y en ejecución.

    Postman para pruebas de los servicios.

Paso 1: Inicialización de la Base de Datos

El proyecto incluye un archivo de orquestación docker-compose.yml en la raíz.

    Abra su terminal en la carpeta raíz Backend.

    Ejecute el comando para descargar y levantar el contenedor:
    Bash

    docker-compose up -d

Paso 2: Ejecución del Servidor

    Navegue hacia la carpeta del proyecto API:
    Bash

cd API

Restaure las dependencias y paquetes NuGet:
Bash

dotnet restore

Inicie la aplicación:
Bash

    dotnet run

El servidor iniciará y estará escuchando peticiones en: http://localhost:5093.

    Nota: Al iniciar la aplicación, se ejecutarán automáticamente las migraciones para crear las tablas necesarias y se insertará un usuario administrador por defecto.

Credenciales de Administrador (Por defecto)

    Correo: admin@renta.com

    Contraseña: admin132

5. AUTOMATIZACIÓN DE PRUEBAS (POSTMAN)

En la raíz del repositorio se encuentra el archivo Maquinaria_API.postman_collection.json. Esta colección ha sido configurada con scripts para facilitar las pruebas.
Características de la Automatización:

    Variable de Entorno Base: Se utiliza la variable {{baseUrl}} configurada al puerto 5093, permitiendo cambiar el entorno sin modificar cada petición individualmente.

    Captura Automática de Token: El endpoint de Login incluye un script de prueba (Tests) que intercepta la respuesta del servidor. Al recibir un inicio de sesión exitoso, el script extrae el Token JWT y lo asigna automáticamente a la variable de colección token.

    Código del Script implementado en Postman:
    JavaScript

    var jsonData = pm.response.json();
    if (jsonData.token) {
        pm.collectionVariables.set("token", jsonData.token);
    }

    Autorización Heredada: Todos los endpoints protegidos están configurados para heredar la autorización de la colección principal, eliminando la necesidad de copiar y pegar el token manualmente en cada petición.

6. EVIDENCIA (VIDEO DEMOSTRATIVO)

Se adjunta enlace a la demostración visual del funcionamiento de los endpoints, las validaciones de seguridad y el flujo de renta:

[INSERTAR AQUÍ EL ENLACE DE YOUTUBE]
