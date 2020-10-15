using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweetDreams.Api.Models;
using Microsoft.EntityFrameworkCore;
using SweetDreams.Api.Models.Administrador;

namespace SweetDreams.Api.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options) { }
        public DbSet<Habitacion> Habitacion { get; set; }
        public DbSet<Reservaciones> Reservaciones { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Actividades> Actividades { get; set; }

    }
}
