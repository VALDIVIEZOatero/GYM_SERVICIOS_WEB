
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiGimnasio.Models
{

    [Table("Ejercicios",Schema ="dbo")]
    public class Ejercicio
    {
        [Key]
        [Column("EjercicioId")]
        public int ejercicio_id{get;set;}

        [Column("Nombre")]
        public string nombre{get;set;}="";

        [Column("Descripcion")]
        public string? descripcion{get;set;}

        [Column("GrupoMuscular")]
        public string? grupo_muscular{get;set;}

        [Column("IsActive")]
        public bool is_active{get;set;}

        [JsonIgnore]
        public ICollection<RutinaEjercicio> rutina_ejercicio = new List<RutinaEjercicio>();
    }
}