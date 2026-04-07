using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ApiGimnasio.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiGimnasio.Models
{
    [Table("RutinaEjercicios",Schema ="dbo")]
    public class RutinaEjercicio
    {
        [Key, Column("RutinaId" , Order =0)]
        public int rutina_id{get;set;}

        [Key ,Column("EjercicioId", Order =1)]
        public int ejercicio_id{get;set;}

        [Column("Orden")]
        public int orden{get;set;}
        [Column("Series")]
        public int? serie{get;set;}
        [Column("Repeticiones")]
        public int? repeticiones{get;set;}

        [Column("PesoObjetivoKg")]
        [Precision(6,2)]
        public decimal? peso_objetivo_kg{get;set;}
        [Column("DuracionSegundos")]
        public int? duracion_seg{get;set;}
        [Column("DescansoSegundos")]
        public int? descanso_seg{get;set;}

        [Column("Notas")]
        public string? nota{get;set;}

        [ForeignKey("rutina_id")]
        [JsonIgnore]
        public Rutina? rutina{get;set;}

        [ForeignKey("ejercicio_id")]
        [JsonIgnore]
        public Ejercicio? ejercicio{get;set;}
    }
}