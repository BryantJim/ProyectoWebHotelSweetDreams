using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SweetDreams.Cliente.Models;

namespace SweetDreams.Cliente.DAL
{
    public class Contexto : DbContext
    {  
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Reservaciones> Reservaciones { get; set; }
        public DbSet<Habitacion> Habitacion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlite("@Server:./SqlExpress; Database = ./Data/StudioEF.db; Trusted_Connection = True; ");
        }
    }
}
