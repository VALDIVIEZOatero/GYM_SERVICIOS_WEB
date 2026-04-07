using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiGimnasio.Models
{
    [Table("UserRoles", Schema = "dbo")]
    public class UserRole
    {
        
        [Key , Column("UserId" , Order =0)]
        public int user_id { get; set; }
        
        [Key,Column("RoleId" , Order =1)]
        public int rol_id { get; set; }

        [Column("AssignedAt")]
        public DateTime assignedAt { get; set; }

        // Relaciones de navegación
        [ForeignKey("user_id")]
        [JsonIgnore] // Evita ciclos al serializar
        public Usuario? usuarios { get; set; }

        [ForeignKey("rol_id")]
        [JsonIgnore] // Evita ciclos al serializar
        public Rol? rols { get; set; }
    }
}