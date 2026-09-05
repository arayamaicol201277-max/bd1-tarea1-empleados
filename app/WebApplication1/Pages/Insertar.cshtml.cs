using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class InsertarModel : PageModel
    {
        private readonly EmpleadoService _empleadoService;

        public InsertarModel(EmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [BindProperty]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\- ]+$", ErrorMessage = "El nombre solo puede contener letras y guiones.")]
        public string Nombre { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "El salario es obligatorio.")]
        [RegularExpression(@"^\d+(\.\d{1,4})?$", ErrorMessage = "El salario debe ser un valor monetario válido.")]
        public string Salario { get; set; } = string.Empty;

        public string? MensajeError { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            decimal salarioDecimal = decimal.Parse(Salario, System.Globalization.CultureInfo.InvariantCulture);
            var resultado = _empleadoService.InsertarEmpleado(Nombre, salarioDecimal);

            if (resultado.Codigo == 0)
            {
                TempData["MensajeExito"] = resultado.Mensaje;
                return RedirectToPage("Empleados");
            }

            MensajeError = resultado.Mensaje;
            return Page();
        }
    }
}