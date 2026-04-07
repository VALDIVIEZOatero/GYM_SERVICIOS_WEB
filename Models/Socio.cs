
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using ApiGimnasio.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGimnasio.Data
{
    [Table("Socios",Schema ="dbo")]
    public class Socio
    {

        [Key]
        [Column("SocioId")]
        public int socio_id{get;set;}

        [Column("UserId")]
        public int user_id{get;set;}

        [Column("FechaNacimiento")]
        public DateTime? fecha_nacimiento{get;set;}

        [Column("Genero")]
        public char genero{get;set;}

        [Column("AlturaCm")]
        [Precision(5,2)]
        public decimal alturacm{get;set;}

        [Column("PesoKg")]
        [Precision(6,2)]
        public decimal peso{get;set;}
        [Column("EmergenciaNombre")]
        public string? emergencia_nombre{get;set;}="";

        [Column("EmergenciaTelefono")]
        public string? emergencia_telefono{get;set;}="";

        [Column("FechaRegistro")]
        public DateTime fecha_registro{get;set;}

        [Column("IsActive")]
        public bool isActive{get;set;}

        [JsonIgnore]
        public ICollection<SocioEntrenador> socio_entrenador{get;set;} = new List<SocioEntrenador>();
        [JsonIgnore]
        public ICollection<SocioMembresia> socio_membresia{get;set;} = new List<SocioMembresia>();


    }
}