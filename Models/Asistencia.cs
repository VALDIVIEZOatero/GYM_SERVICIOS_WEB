using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGimnasio.Models
{
    [Table("Asistencias",Schema ="dbo")]
    public class Asistencia
    {
        [Key]
        [Column("AsistenciaId")]
        public int asistencia_id{get;set;}

        [Column("SocioId")]
        public int socio_id{get;set;}

        [Column("FechaHoraEntrada")]
        public DateTime fecha_entrada{get;set;}

        [Column("FechaHoraSalida")]
        public DateTime? fecha_salida{get;set;}

        [Column("Observaciones")]
        public string? observacion {get;set;}

        [Column("RegistradaPorUserId")]
        public int? registrado_id{get;set;}


    }
}