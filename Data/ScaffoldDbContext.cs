using Microsoft.EntityFrameworkCore;
using ApiGimnasio.Models;
using System.Security.Cryptography;
using Microsoft.Net.Http.Headers;
namespace ApiGimnasio.Data
{
    public class ScaffoldDbContext : DbContext
    {
        public ScaffoldDbContext(DbContextOptions<ScaffoldDbContext> options) : base(options)
        {
            
        }
        public DbSet<Rol> Roles {get;set;}

        //AuthController
        public DbSet<Usuario> Usuarios{get;set;}
        public DbSet<UserRole> UserRoles{get;set;}
        public DbSet<Entrenador> Entrenadores{get;set;}
        public DbSet<Socio> Socios{get;set;}

        public DbSet<SocioEntrenador> SocioEntrenadores{get;set;}
        public DbSet<Membresia> Membresias{get;set;}

        public DbSet<SocioMembresia> SocioMembresias{get;set;}

        public DbSet<Asistencia> Asistencias{get;set;}

        public DbSet<Ejercicio> Ejercicios{get;set;}

        public DbSet<Rutina> Rutinas{get;set;}

        public DbSet<RutinaEjercicio> RutinaEjercicios{get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>().
            HasKey(ur => new {ur.user_id , ur.rol_id});

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.usuarios)
                .WithMany(u => u.user_roles)
                .HasForeignKey(ur => ur.user_id);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.rols)
                .WithMany(r => r.user_roles)
                .HasForeignKey(ur => ur.rol_id);

            modelBuilder.Entity<SocioEntrenador>().
            HasKey(se => new {se.socio_id , se.entrenador_id});

            modelBuilder.Entity<SocioEntrenador>()
                .HasOne(se => se.socios)
                .WithMany(u =>u.socio_entrenador )
                .HasForeignKey(ur => ur.socio_id);

            modelBuilder.Entity<SocioEntrenador>()
                .HasOne(ur => ur.entrenadores)
                .WithMany(r => r.socio_entrenador)
                .HasForeignKey(ur => ur.entrenador_id);
            
            modelBuilder.Entity<RutinaEjercicio>().
            HasKey(re => new {re.rutina_id ,re.ejercicio_id});

            modelBuilder.Entity<RutinaEjercicio>()
                .HasOne(re => re.rutina)
                .WithMany(re =>re.rutina_ejercicio)
                .HasForeignKey(re => re.rutina_id);

            modelBuilder.Entity<RutinaEjercicio>()
                .HasOne(re => re.ejercicio)
                .WithMany(re => re.rutina_ejercicio)
                .HasForeignKey(re =>re.ejercicio_id );
            
        }
    }
}

