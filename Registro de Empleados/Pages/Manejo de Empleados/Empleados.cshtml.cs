using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Registro_de_Empleados.Pages
{
    public class EmpleadosModel : PageModel
    {
        SqlConnection conexión = new SqlConnection("Data Source = 4.150.200.255; User ID = TP1; Password=********;Connect Timeout = 30; Encrypt=True;Trust Server Certificate=True;Application Intent = ReadWrite; Multi Subnet Failover=False");
        public void OnGet()
        {
            //Prueba de conexión a la base de datos
            //Pendiente de implementar la lógica para obtener los empleados desde la base de datos

            /*conexión.Open();
            SqlCommand comando = new SqlCommand("dbo.sp_ObtenerEmpleados", conexión);*/
        }
    }
}
