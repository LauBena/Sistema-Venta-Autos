using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EzpLaura2024.Models;

namespace EzpLaura2024.Models
{
    public class EjercicioFisico
    {
        [Key]
        public int EjercicioFisicoID { get; set; }
        public int TipoEjercicioID { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public EstadoEmocional EstadoEmocionalInicio { get; set; }
        public EstadoEmocional EstadoEmocionalFin { get; set; }
        public string? Observaciones { get; set; }

        //RECIBE LA CONECCION CON TIPO DE EJERCICIOS
        public virtual TipoEjercicio TipoEjercicio { get; set; }
    }

    public enum EstadoEmocional
    {
        Feliz = 1,
        Triste,
        Enojado,
        Ansioso,
        Estresado,
        Relajado,
        Aburrido,
        Emocionado,
        Agobiado,
        Confundido,
        Optimista,
        Pesimista,
        Motivado,
        Cansado,
        Eufórico,
        Agitado,
        Satisfecho,
        Desanimado
    }

    public class VistaEjercicios
    {
        public int EjercicioFisicoID { get; set; }
        public int TipoEjercicioID { get; set; }
        public string? EjercicioNombre { get; set; }
        public string? InicioString { get; set; }
        public string? FinString { get; set; }
        public string? EstadoInicio { get; set; }
        public string? EstadoFin { get; set; }
        public string? Observaciones { get; set; }
    }


}