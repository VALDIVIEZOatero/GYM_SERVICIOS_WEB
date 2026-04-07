using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGimnasio.Models
{
    [Table("Entrenadores",Schema ="dbo")]
    public class Entrenador
    {
        [Key]
        [Column("EntrenadorId")]
        public int entrenador_id{get;set;}

        [Column("UserId")]
        public int user_id{get;set;}

        [Column("Especialidad")]
        public string? especialidad{get;set;}

        [Column("Certificaciones")]
        public string? certificacion{get;set;}

        [Column("FechaIngreso")]
        public DateTime fecha_ingreso{get;set;}

        [Column("IsActive")]
        public bool isActive{get;set;}
        public ICollection<SocioEntrenador> socio_entrenador{get;set;} = new List<SocioEntrenador>();

    }
}