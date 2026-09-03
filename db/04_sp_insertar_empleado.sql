IF OBJECT_ID('dbo.sp_InsertarEmpleado', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_InsertarEmpleado;
GO

CREATE PROCEDURE dbo.sp_InsertarEmpleado
    @Nombre   VARCHAR(128),
    @Salario  MONEY,
    @Codigo   INT           OUTPUT,  
    @Mensaje  VARCHAR(200)  OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    
    IF EXISTS (
        SELECT 1
        FROM dbo.Empleado
        WHERE Nombre = @Nombre
    )
    BEGIN
        SET @Codigo  = 1;
        SET @Mensaje = 'Nombre de Empleado ya existe.';
        RETURN;
    END

    INSERT INTO dbo.Empleado (Nombre, Salario)
    VALUES (@Nombre, @Salario);

    SET @Codigo  = 0;
    SET @Mensaje = 'Inserción exitosa.';
END
GO


-- Prueba manual:
-- DECLARE @Codigo INT, @Mensaje VARCHAR(200);
-- EXEC dbo.sp_InsertarEmpleado 'Prueba Testing', 123456.00, @Codigo OUTPUT, @Mensaje OUTPUT;
-- SELECT @Codigo AS Codigo, @Mensaje AS Mensaje;