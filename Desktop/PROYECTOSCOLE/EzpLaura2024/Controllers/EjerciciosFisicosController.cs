using Microsoft.AspNetCore.Mvc;
using EzpLaura2024.Models;
using EzpLaura2024.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EzpLaura2024.Controllers;

[Authorize]
public class EjerciciosFisicosController : Controller
{
    private ApplicationDbContext _context;

    //CONSTRUCTOR
    public EjerciciosFisicosController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        //CREAR UNA LISTA DE SelectListItem QUE INCLUYA EL ELEMENTO ADICIONAL
        var selectListItem = new List<SelectListItem>
        {
            new SelectListItem {Value = "0", Text = "[SELECCIONE...]"}
        };

        //OBTENEMOS TODAS LAS OPCIONES DEL ENUM
        var enumValues = Enum.GetValues(typeof(EstadoEmocional)).Cast<EstadoEmocional>();

        //CONVERTIMOS LAS OPCIONES DEL ENUM EN SelectListItem
        selectListItem.AddRange(enumValues.Select(e => new SelectListItem
        {
            Value = e.GetHashCode().ToString(),
            Text = e.ToString().ToUpper()
        }));

        //PASAMOS LA LISTA DE OPCIONES PARA EL MODELO DE VISTA
        ViewBag.EstadoEmocionalInicial = selectListItem.OrderBy(t => t.Text).ToList();
        ViewBag.EstadoEmocionalFinal = selectListItem.OrderBy(t => t.Text).ToList();

        var tipoEjercicios = _context.TipoEjercicios.ToList();
        tipoEjercicios.Add(new TipoEjercicio { TipoEjercicioID = 0, Descripcion = "[SELECCIONE...]" });
        ViewBag.TipoEjercicioID = new SelectList(tipoEjercicios.OrderBy(c => c.Descripcion), "TipoEjercicioID", "Descripcion");

        return View();
    }

    public JsonResult ListadoEjercicios(int? id)
    {
        List<VistaEjercicios> EjerciciosMostrar = new List<VistaEjercicios>();

        var EjerciciosFisicos = _context.EjerciciosFisicos.ToList();

        if (id != null)
        {
            EjerciciosFisicos = EjerciciosFisicos.Where(e => e.EjercicioFisicoID == id).ToList();
        }

        var Ejercicio = _context.TipoEjercicios.ToList();

        foreach (var EjercicioFisico in EjerciciosFisicos)

        {
            var ejercicio = Ejercicio.Where(e => e.TipoEjercicioID == EjercicioFisico.TipoEjercicioID).Single();

            var EjercicioMostrar = new VistaEjercicios
            {
                IdEjercicioFisico = EjercicioFisico.EjercicioFisicoID,
                TipoEjercicioID = EjercicioFisico.TipoEjercicioID,
                //  EjercicioNombre = Ejercicio.TipoEjercicioID,
                InicioString = EjercicioFisico.Inicio.ToString("dd/MM/yyy HH:mm"),
                FinString = EjercicioFisico.Fin.ToString("dd/MM/yyy HH:mm"),
                EstadoInicio = Enum.GetName(typeof(EstadoEmocional), EjercicioFisico.EstadoEmocionalInicio),
                EstadoFin = Enum.GetName(typeof(EstadoEmocional), EjercicioFisico.EstadoEmocionalFin),
                Observaciones = EjercicioFisico.Observaciones

            };
            EjerciciosMostrar.Add(EjercicioMostrar);
        }

        return Json(EjerciciosMostrar);
    }

}