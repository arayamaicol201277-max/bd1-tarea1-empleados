# Registro de Empleados — Primera Tarea Programada (Bases de Datos 1)

Prueba de concepto que conecta una base de datos SQL Server con una aplicación web sencilla (ASP.NET Core Razor Pages), permitiendo consultar e insertar empleados a través de procedimientos almacenados.

## Integrantes

- Maicol Araya Urbina
- Jean Franco Quirós Jiménez

## Descripción

La aplicación permite:
- Ver el listado de empleados (id, Nombre, Salario), ordenado alfabéticamente por nombre.
- Insertar un nuevo empleado mediante un formulario, con validación de campos en la capa de presentación y validación de nombres duplicados en la base de datos.

Toda la lógica de acceso a datos se implementa exclusivamente mediante **procedimientos almacenados**; no hay sentencias SQL incrustadas en la capa lógica.

## Stack tecnológico

| Componente | Tecnología |
|---|---|
| Motor de base de datos | SQL Server 2022 Express |
| Servidor de base de datos | Máquina virtual (VM) en Microsoft Azure |
| Backend / capa lógica | ASP.NET Core (C#), .NET 10.0, Razor Pages |
| Acceso a datos | Microsoft.Data.SqlClient (sin ORM) |
| Cliente de administración de BD | SQL Server Management Studio (SSMS) |
| Control de versiones | GitHub |
| Bitácora del proyecto | Blogger |

## Estructura del repositorio

```
/app        → Código fuente de la aplicación web (WebApplication1)
/db         → Scripts SQL: creación de base de datos, tabla, datos de prueba y procedimientos almacenados
/Docs       → Documentación del proyecto (Análisis de Resultados)
README.md   → Este archivo
```

### Scripts en /db (ejecutar en este orden)

1. `01_Tablas.sql` — Creación de la tabla Empleado.
2. `02_seeding.sql` — Carga de 40 filas de datos de prueba.
3. `03_sp_ObtenerEmpleados.sql` — Procedimiento almacenado para consultar el listado de empleados.
4. `04_sp_InsertarEmpleado.sql` — Procedimiento almacenado para insertar un empleado, con validación programática de duplicados.

## Cómo ejecutar el proyecto

1. Crear la base de datos `Tarea1BD` en una instancia de SQL Server (2016 o superior).
2. Ejecutar los scripts de `/db` en orden desde SSMS.
3. Abrir la solución dentro de `/app/WebApplication1` en Visual Studio.
4. Configurar la cadena de conexión en `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "BDEmpleados": "Data Source=<IP_DEL_SERVIDOR>;Initial Catalog=Tarea1BD;User ID=<usuario>;Password=<contraseña>;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;"
   }
   ```
5. Ejecutar el proyecto con F5. La aplicación abrirá directamente en el listado de empleados.

## Documentación

- **Bitácora del proyecto:** No hay link, se necesita correo.
- **Documento de Análisis de Resultados:** disponible en la carpeta `/Docs`

## Reglas del proyecto

- Todo el código de acceso a base de datos debe ser un procedimiento almacenado; no se permite SQL incrustado en la capa lógica.
- Motor de base de datos: MS SQL Server, versión superior a 2014.