IF OBJECT_ID('dbo.sp_ObtenerEmpleados', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_ObtenerEmpleados;
GO

CREATE PROCEDURE dbo.sp_ObtenerEmpleados
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM dbo.Empleado
    ORDER BY Nombre ASC;
END
GO


-- Prueba manual:
-- EXEC dbo.sp_ObtenerEmpleados;