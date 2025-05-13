using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebApplication1.models;

namespace WebApplication1.db
{
    public class Dbconnect : DbContext
    {
        public Dbconnect(DbContextOptions<Dbconnect> options) 
        : base (options)
        {}
        public DbSet <Mandril> Mandril {get ; set; }
        public DbSet <Habilidades> Habilidades {get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //es una funcion que hace que 
            // las habilidades como son llaves foraneas de mandril se borren primero
            modelBuilder.Entity<Mandril>()
            .HasMany(m => m.Habilidades)
            .WithOne(h => h.Mandril)
            .HasForeignKey(h => h.MandrilId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}