using Registro_de_Empleados_Modelos;

namespace Registro_de_Empleados_Servicios
{
    public interface IRepoEmpleado
    {
        IEnumerable<Empleado> GetEmpleados();
    }
}

