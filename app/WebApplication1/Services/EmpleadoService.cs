using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplication1.Services
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Salario { get; set; }
    }

    public class ResultadoInsercion
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; } = string.Empty;
    }

    public class EmpleadoService
    {
        private readonly string _connectionString;

        public EmpleadoService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BDEmpleados")
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'BDEmpleados'.");
        }

        public List<Empleado> ObtenerEmpleados()
        {
            var empleados = new List<Empleado>();

            using var conexion = new SqlConnection(_connectionString);
            using var comando = new SqlCommand("dbo.sp_ObtenerEmpleados", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                empleados.Add(new Empleado
                {
                    Id = lector.GetInt32(lector.GetOrdinal("id")),
                    Nombre = lector.GetString(lector.GetOrdinal("Nombre")),
                    Salario = lector.GetDecimal(lector.GetOrdinal("Salario"))
                });
            }

            return empleados;
        }

        public ResultadoInsercion InsertarEmpleado(string nombre, decimal salario)
        {
            using var conexion = new SqlConnection(_connectionString);
            using var comando = new SqlCommand("dbo.sp_InsertarEmpleado", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 128) { Value = nombre });
            comando.Parameters.Add(new SqlParameter("@Salario", SqlDbType.Money) { Value = salario });

            var paramCodigo = new SqlParameter("@Codigo", SqlDbType.Int) { Direction = ParameterDirection.Output };
            var paramMensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
            comando.Parameters.Add(paramCodigo);
            comando.Parameters.Add(paramMensaje);

            conexion.Open();
            comando.ExecuteNonQuery();

            return new ResultadoInsercion
            {
                Codigo = (int)paramCodigo.Value,
                Mensaje = paramMensaje.Value?.ToString() ?? string.Empty
            };
        }
    }
}