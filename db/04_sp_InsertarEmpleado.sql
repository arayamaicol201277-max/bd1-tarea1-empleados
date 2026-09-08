IF OBJECT_ID('dbo.sp_InsertarEmpleado', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_InsertarEmpleado; -- Elimina el sp si ya existe.
GO

CREATE PROCEDURE dbo.sp_InsertarEmpleado
    @Nombre   VARCHAR(128),
    @Salario  MONEY,
    @Codigo   INT           OUTPUT,
    @Mensaje  VARCHAR(200)  OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación programática de duplicado: se usa alias "e"
    -- para la tabla Empleado, consistente con el resto de
    -- los procedimientos del proyecto.
    IF EXISTS (
        SELECT 1
        FROM dbo.Empleado AS e
        WHERE e.Nombre = @Nombre
    )
    BEGIN
        SET @Codigo  = 1;
        SET @Mensaje = 'Nombre de Empleado ya existe.';
        SET NOCOUNT OFF;
        RETURN;
    END

    -- Si no existe duplicado, se procede con la inserción.
    INSERT INTO dbo.Empleado (Nombre, Salario)
    VALUES (@Nombre, @Salario);

    SET @Codigo  = 0;
    SET @Mensaje = 'Inserción exitosa.';
    SET NOCOUNT OFF;
END
GO

-- Prueba manual:
-- DECLARE @Codigo INT, @Mensaje VARCHAR(200);
-- EXEC dbo.sp_InsertarEmpleado 'Prueba Testing', 123456.00, @Codigo OUTPUT, @Mensaje OUTPUT;
-- SELECT @Codigo AS Codigo, @Mensaje AS Mensaje;