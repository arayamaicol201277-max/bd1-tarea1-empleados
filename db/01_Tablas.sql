USE Tarea1BD;
GO

IF OBJECT_ID('dbo.Empleado', 'U') IS NOT NULL
    DROP TABLE dbo.Empleado;
GO

CREATE TABLE dbo.Empleado
(
    id       INT IDENTITY (1, 1) PRIMARY KEY
    , Nombre VARCHAR(128) NOT NULL
    , Salario MONEY NOT NULL
);
GO
