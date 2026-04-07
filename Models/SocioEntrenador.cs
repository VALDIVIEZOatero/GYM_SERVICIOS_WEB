
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ApiGimnasio.Data;

namespace ApiGimnasio.Models
{
    [Table("SocioEntrenador",Schema ="dbo")]
    public class SocioEntrenador
    {
        [Key , Column("SocioId" , Order =0)]
        public int socio_id{get;set;}
        [Key , Column("EntrenadorId" , Order = 1)]
        public int entrenador_id{get;set;}

        [Column("FechaAsignacion")]
        public DateTime fecha_asignacion{get;set;}

        [Column("Activo")]
        public bool activo{get;set;}

        [ForeignKey("socio_id")]
        [JsonIgnore]
        public Socio? socios{get;set;}

        [ForeignKey("entrenador_id")]
        [JsonIgnore]
        public Entrenador? entrenadores{get;set;}

    }
}