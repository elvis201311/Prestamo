using Microsoft.EntityFrameworkCore;
using Prestamo.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestamo.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<rCliente> rCliente { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\PrestamoCliente.db");
        }
    }
}