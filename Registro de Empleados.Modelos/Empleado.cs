namespace Registro_de_Empleados_Modelos
{
    public class Empleado
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public decimal Salario { get; set; }

    }
}
