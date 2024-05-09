using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EzpLaura2024.Models;

public class TipoEjercicio
{
    [Key]
    public int TipoEjercicioID { get; set; }
    public string? Descripcion { get; set; }
    public bool Eliminado { get; set; }

    //ICOLLECTION ES LA RELACION ENTRE ESTA TABLA TIPO DE EJERCICIOS Y LA DE EJERCICIO FISICO
    //RELACION DE UNO A MUCHOS, TIPO DE EJERCICIOS LE DA LA COLECCION DE DATOS A LA OTRA TABLA
    public virtual ICollection<EjercicioFisico> EjerciciosFisicos { get; set; }
}