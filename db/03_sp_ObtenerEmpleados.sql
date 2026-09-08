IF OBJECT_ID('dbo.sp_ObtenerEmpleados', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_ObtenerEmpleados; -- Elimina el sp si ya existe.
GO

CREATE PROCEDURE dbo.sp_ObtenerEmpleados
AS
BEGIN
    SET NOCOUNT ON;

    -- Se usa alias "e" para la tabla Empleado, siguiendo el
    -- estándar de nombrar tablas mediante alias en el SELECT.
    SELECT
        e.id,
        e.Nombre,
        e.Salario
    FROM dbo.Empleado AS e
    ORDER BY e.Nombre ASC;

    SET NOCOUNT OFF;
END
GO

-- Prueba manual:
-- EXEC dbo.sp_ObtenerEmpleados;