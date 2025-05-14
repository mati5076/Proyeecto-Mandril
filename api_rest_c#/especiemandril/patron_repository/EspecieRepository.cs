using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using especiemandril.Dot;
using especiemandril.models;
using especiemandril.patron_repository;
using Microsoft.EntityFrameworkCore;

namespace especieEspecie.patron_repository
{
    public class EspecieRepository : IEspeciesRepository
    {
        private readonly DbContext _db;

        public EspecieRepository(DbContext db){
            _db = db;
        }

        public async Task<Especie> Postasync(Especie Especie){
            _db.Especie.Add(Especie);
            await _db.SaveChangesAsync();
            return Especie;
        }


        public async Task<bool> DeleteIdasync(int id){
            var Especie = await _db.Especie.FindAsync(id);
            if (Especie == null){
                return false;
            }
            
            _db.Especie.Remove(Especie);
            await _db.SaveChangesAsync();
            return true;
        }
         public async Task<IEnumerable<Especie>> Getasync(){
             return await _db.Especie.Include(m => m.Habilidades).ToListAsync();
        }
         
         public async Task<Especie?> GetEspecieAsync(int id){
            return await _db.Especie
            .Include(m=> m.Habilidades)
            .FirstOrDefaultAsync(m => m.Id == id);
        }
        public Task<Especie> PutIdasync(int id, Especie Especie){
            throw new NotImplementedException();
        }

        public Task<Especie> GetIdasync(int id){
            throw new NotImplementedException();
        }
        public async Task<Especie> UpdateAsync(Especie Especie){
            var nuevo_Especie = await _db.Especie
            .Include(h => h.Habilidades)
            .FirstOrDefaultAsync(h => h.Id == Especie.Id);
            
            if (nuevo_Especie == null) return null;
            nuevo_Especie.Nombre_especie = Especie.Nombre_especie;
            nuevo_Especie.sub_especie = Especie.sub_especie;
            nuevo_Especie.cantidad_especie = Especie.cantidad_especie;
            await _db.SaveChangesAsync();
            return nuevo_Especie;
        }
    }
}