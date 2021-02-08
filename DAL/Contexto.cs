using Microsoft.EntityFrameworkCore;
using Parcial1_ap1_2018_0553.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_ap1_2018_0553.DAL
{
    class Contexto : DbContext
    {

        public DbSet<Ciudad> Ciudad { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = datosCiudades.Db");
        }
    }
}
