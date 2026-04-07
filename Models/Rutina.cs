using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiGimnasio.Models
{
    [Table("Rutinas",Schema ="dbo")]
    public class Rutina
    {
        [Key]
        [Column("RutinaId")]
        public int rutina_id{get;set;}

        [Column("SocioId")]
        public int socio_id{get;set;}

        [Column("EntrenadorId")]
        public int? entrenador_id{get;set;}

        [Column("Nombre")]
        public string nombre{get;set;}="";

        [Column("Objetivo")]
        public string? objetivo{get;set;}

        [Column("FechaInicio")]
        public DateTime fecha_inicio{get;set;}

        [Column("FechaFin")]
        public DateTime? fecha_fin{get;set;}

        [Column("Activa")]
        public bool activa{get;set;}
        [Column("CreatedAt")]
        public DateTime createdAt{get;set;}

        [JsonIgnore]
        public ICollection<RutinaEjercicio> rutina_ejercicio = new List<RutinaEjercicio>();
    }
}