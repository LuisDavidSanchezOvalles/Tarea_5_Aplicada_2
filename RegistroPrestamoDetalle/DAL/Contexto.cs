using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroPrestamoDetalle.Models;

namespace RegistroPrestamoDetalle.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Moras> Moras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\luisd\OneDrive\Escritorio\Universidad\Programacion Aplicada 2\Base_de_Datos_de_Blazor\PrestamosMorasDB\PrestamosMoras.db");
        }
    }
}
