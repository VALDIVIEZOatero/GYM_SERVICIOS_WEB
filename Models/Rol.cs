using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace ApiGimnasio.Models{
    [Table("Roles", Schema = "dbo")]
    public class Rol
    {

        [Key]
        [Column("RoleId")]
        public int rol_id{get;set;}
        [Column("Name")]
        [Required(ErrorMessage ="INGRESAR EL NOMBRE !!")]
        [StringLength(50)]
        public string name{get;set;}="";

        [Column("NormalizedName")]
        [StringLength(50)]
        [Required(ErrorMessage ="INGRESAR EL NOMBRE NORMALIZADO!!")]
        public string? nombre_normal{get;set;}="";
        [Column("IsActive")]
        [Required(ErrorMessage ="INGRESAR EL ESTADO DEL ROL!")]
        public bool isactive{get;set;}

        [Column("CreatedAt")]
        [Required(ErrorMessage ="INGRESAR LA FECHA DE CREACION!!")]
        public DateTime createdAt{get;set;}

        [JsonIgnore]
        public ICollection<UserRole> user_roles{get;set;} = new List<UserRole>();
    }
}