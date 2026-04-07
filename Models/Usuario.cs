
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiGimnasio.Models
{

    [Table("Users",Schema ="dbo")]
    public class Usuario
    {
        [Key]
        [Column("UserId")]
        public int user_id{get;set;}

        [Column("UserName")]
        [Required(ErrorMessage ="INGRESAR EL NOMBRE DE USUARIO!!")]
        [StringLength(100)]
        public string user_name{get;set;}="";

        [Column("NormalizedUserName")]
        [Required(ErrorMessage ="INGRESAR EL NOMBRE DE USUARIO OTRA VEZ!")]
        [StringLength(100)]
        public string nombreUser_normal{get;set;}="";

        [Column("Email")]
        [EmailAddress(ErrorMessage ="INGRESAR EL CORREO DEL USUARIO!")]
        public string correo{get;set;}="";

        [Column("NormalizedEmail")]
        [EmailAddress(ErrorMessage ="INGRESAR EL CORREO OTRA VEZ!")]
        public string correo_normal{get;set;}="";

        [Column("PasswordHash")]
        [Required(ErrorMessage ="INGRESAR LA CONTRASEÑA!!")]
        public string password_user{get;set;}="";

        [Column("PhoneNumber")]
        [Phone(ErrorMessage ="INGRESAR EL NUMERO TELEFONICO!!")]
        public string? telefono{get;set;}

        [Column("IsActive")]
        [Required(ErrorMessage ="")]
        public bool isactive{get;set;}=true;

        [Column("LastLoginAt")]
        
        public DateTime? last_loginAt{get;set;}

        [Column("CreatedAt")]
        public DateTime createdAt{get;set;}

        [Column("UpdatedAt")]
        public DateTime? updateAt{get;set;}

        [JsonIgnore]
        public ICollection<UserRole> user_roles{get;set;}= new List<UserRole>();
    }
}