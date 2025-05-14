using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using especiemandril.models;
using Microsoft.EntityFrameworkCore;

namespace especiemandril.Dot
{
    public class _Dbcontext : DbContext
    {
        public _Dbcontext(DbContextOptions<_Dbcontext> options) 
        : base (options)
        {}
        public DbSet <Especie> Especie {get ; set; }
        
    }
}