Plataforma Web de Gestión y Renta de Maquinaria Pesada (Backend)

Estudiante: Michael Armani Gonzalez Arciga Proyecto: Maquinaria del Bajío Fecha: 07 de Diciembre, 2025
1. Descripción del Proyecto

El proyecto consiste en el desarrollo del componente Backend para una solución de software tipo Full-Stack, orientada a la administración y renta de maquinaria pesada. Su propósito principal es digitalizar y optimizar el proceso de alquiler de equipos, centralizando la gestión del inventario y automatizando la cotización de servicios.
Funcionalidad Principal

El sistema funciona como una API RESTful que procesa la lógica de negocio y la persistencia de datos para una plataforma web. Sus funciones críticas incluyen:

    Gestión de Identidad: Administración de usuarios mediante roles (Cliente y Administrador) y seguridad basada en tokens.

    Control de Inventario: Permite a los administradores registrar, actualizar y eliminar maquinaria del catálogo.

    Motor de Procesamiento de Rentas: Algoritmo que valida la disponibilidad de equipos en rangos de fechas específicos y calcula automáticamente los costos totales de arrendamiento, asegurando la integridad de las transacciones y evitando conflictos de agenda.

2. Tecnologías Utilizadas

    Lenguaje y Framework: .NET 8 (C#) Web API.

    Base de Datos: PostgreSQL (Ejecutado mediante contenedor Docker).

    ORM: Entity Framework Core para la manipulación de datos.

    Seguridad: Implementación de JSON Web Tokens (JWT) para autenticación y autorización.

    Validación: FluentValidation para garantizar la integridad de los datos de entrada.

3. Documentación de la API (Endpoints)

La API expone diversos servicios organizados por módulos funcionales. A continuación, se describen los endpoints implementados más relevantes:
Módulo I: Autenticación y Usuarios

    Inicio de Sesión

        Método: POST

        Ruta: /api/Auth/login

        Descripción: Recibe las credenciales del usuario, valida la información contra la base de datos utilizando hash criptográfico y retorna un Token JWT.

    Registro de Clientes

        Método: POST

        Ruta: /api/Auth/register

        Descripción: Permite la creación de nuevas cuentas de usuario con el rol de cliente.

    Cambio de Contraseña

        Método: POST

        Ruta: /api/Auth/change-password

        Descripción: Permite a un usuario autenticado actualizar su contraseña, validando previamente la contraseña actual.

Módulo II: Gestión de Maquinaria

    Obtener Catálogo

        Método: GET

        Ruta: /api/Machinery

        Descripción: Servicio público que recupera el listado completo de equipos disponibles.

    Alta de Inventario

        Método: POST

        Ruta: /api/Machinery

        Descripción: Endpoint protegido para administradores. Permite registrar un nuevo equipo.

    Eliminar Maquinaria

        Método: DELETE

        Ruta: /api/Machinery/{id}

        Descripción: Endpoint protegido para administradores. Elimina un registro del catálogo.

Módulo III: Procesamiento de Rentas

    Crear Renta (Algorítmico)

        Método: POST

        Ruta: /api/Rental/rent

        Descripción: Ejecuta la lógica central del negocio. Recibe el ID de la máquina y el rango de fechas. El algoritmo verifica disponibilidad, calcula el costo total y genera el registro.

    Historial de Rentas

        Método: GET

        Ruta: /api/Rental/my-rentals

        Descripción: Devuelve el listado de rentas asociadas al usuario autenticado.

    Devolución de Equipo

        Método: POST

        Ruta: /api/Rental/return/{id}

        Descripción: Finaliza un contrato de renta activo.

4. Instrucciones de Ejecución
Requerimientos

    Docker Desktop.

    .NET 8 SDK.

    Postman.

Pasos de Instalación

    Base de Datos: Navegue a la carpeta raíz del repositorio y ejecute el siguiente comando para levantar el contenedor de PostgreSQL:
    Bash

docker-compose up -d

Ejecución del Servidor: Abra una terminal, navegue a la carpeta API y ejecute:
Bash

    dotnet restore
    dotnet run

    El servidor iniciará en el puerto 5093 (http://localhost:5093).

Credenciales de Administrador

Para probar los endpoints protegidos, utilice la cuenta predeterminada creada por el sembrador de datos (DbInitializer):

    Correo: admin@renta.com

    Contraseña: admin132

5. Colección de Postman y Automatización

En la raíz de este repositorio se incluye el archivo Maquinaria_API.postman_collection.json. Esta colección ha sido configurada con scripts de automatización para facilitar las pruebas del API sin intervención manual constante.
Características de la Automatización:

    Variable de Entorno (baseUrl): Todas las peticiones utilizan la variable {{baseUrl}} (configurada como http://localhost:5093), lo que permite cambiar el entorno de despliegue sin modificar cada endpoint individualmente.

    Captura Automática de Token (Script): El endpoint de Login contiene un script de prueba (Tests) que intercepta la respuesta del servidor. Al recibir un inicio de sesión exitoso, el script extrae el Token JWT y lo asigna automáticamente a la variable de colección token.

    Código del Script implementado:
    JavaScript

    var jsonData = pm.response.json();
    if (jsonData.token) {
        pm.collectionVariables.set("token", jsonData.token);
    }

    Autorización Heredada: Todos los endpoints protegidos (como "Alta de Inventario" o "Crear Renta") están configurados para heredar la autorización de la colección principal. Esto significa que utilizan automáticamente el token capturado por el script de Login, eliminando la necesidad de copiar y pegar el token manualmente en cada petición.

6. Video Demostrativo

A continuación, se presenta la evidencia visual del funcionamiento de los endpoints, la lógica de negocio y la automatización descrita anteriormente:

[PEGAR AQUI TU ENLACE DE YOUTUBE]
