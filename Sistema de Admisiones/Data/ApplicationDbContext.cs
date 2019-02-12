using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Admisiones.Models;

namespace Sistema_de_Admisiones.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Solicitud_Admisiones> Solicitud_Admisiones { get; set; }
        public DbSet<Procesos> Procesos { get; set; }
        public DbSet<Evaluaciones> Evaluaciones { get; set; }
        public DbSet<Notificaciones> Notificaciones { get; set; }
        public DbSet<Aulas> Aulas { get; set; }
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Nivel> Nivel { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Periodo> Periodo { get; set; }
        public DbSet<proceso> proceso { get; set; }
        public DbSet<Usuarios> UsuariosAdmin { get; set; }
        //public DbSet<>

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
