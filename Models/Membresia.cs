
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ApiGimnasio.Models
{
    [Table("Membresias",Schema ="dbo")]
    public class Membresia
    {
        [Key]
        [Column("MembresiaId")]
        public int membresia_id{get;set;}

        [Column("Nombre")]
        public string nombre{get;set;}="";

        [Column("Descripcion")]
        public string? descripcion{get;set;}

        [Column("DuracionDias")]
        public int duracion_dia{get;set;}

        [Column("Precio")]
        [Precision(10,2)]
        public decimal precio{get;set;}

        [Column("EsRenovable")]
        public bool esRenovable{get;set;}

        [Column("IsActive")]
        public bool isActive{get;set;}

        [Column("CreatedAt")]
        public DateTime createdAt{get;set;}

        [JsonIgnore]
        public ICollection<SocioMembresia> socio_membresia{get;set;} = new List<SocioMembresia>();

    }
}