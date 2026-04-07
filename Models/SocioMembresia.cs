using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ApiGimnasio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGimnasio.Models
{
    [Table("SocioMembresia",Schema ="dbo")]
    public class SocioMembresia
    {
        [Key]
        [Column("SocioMembresiaId")]
        public int socio_membresia_id{get;set;}

        [Column("SocioId")]
        public int socio_id{get;set;}

        [Column("MembresiaId")]
        public int membresia_id{get;set;}

        [Column("FechaInicio")]
        public DateTime fecha_ingreso{get;set;}

        [Column("FechaFin")]
        public DateTime fecha_fin{get;set;}

        [Column("Estado")]
        public string estado{get;set;}="";

        [Column("MontoPagado")]
        [Precision(10,2)]
        public decimal monto_pago{get;set;}

        [Column("Notas")]
        public string? notas{get;set;}

        [Column("CreatedAt")]
        public DateTime createdAt{get;set;}

        [ForeignKey("socio_id")]
        [JsonIgnore]
        public Socio? socio{get;set;}

        [ForeignKey("membresia_id")]
        [JsonIgnore]
        public Membresia? membresia{get;set;}
    }
}