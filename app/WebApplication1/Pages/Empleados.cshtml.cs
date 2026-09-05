using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class EmpleadosModel : PageModel
    {
        private readonly EmpleadoService _empleadoService;

        public List<Empleado> Empleados { get; set; } = new();

        public EmpleadosModel(EmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        public void OnGet()
        {
            Empleados = _empleadoService.ObtenerEmpleados();
        }
    }
}