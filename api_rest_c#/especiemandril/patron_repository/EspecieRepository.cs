using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using especiemandril.Dot;
using especiemandril.models;
using especiemandril.patron_repository;

namespace especiemandril.patron_repository
{
    public class EspecieRepository : IEspeciesRepository
    {
         private readonly _Dbcontext _db;

        public EspecieRepository(_Dbcontext db){
            _db = db;
        }

        public async Task<Especie> Postasync(Especie especieeW){
            _db.Especie.Add(especieeW);
            await _db.SaveChangesAsync();
            return especieeW;
        }


        public async Task<bool> DeleteIdasync(int id){
            var especieeW = await _db.Especie.FindAsync(id);
            if (especieeW == null){
                return false;
            }
            
            _db.Especie.Remove(especieeW);
            await _db.SaveChangesAsync();
            return true;
        }
         public async Task<IEnumerable<especieeW>> Getasync(){
             return await _db.especieeW.Include(m => m.Habilidades).ToListAsync();
        }
         
         public async Task<especieeW?> GetespecieeWAsync(int id){
            return await _db.especieeW
            .Include(m=> m.Habilidades)
            .FirstOrDefaultAsync(m => m.Id == id);
        }
        public Task<especieeW> PutIdasync(int id, especieeW especieeW){
            throw new NotImplementedException();
        }

        public Task<especieeW> GetIdasync(int id){
            throw new NotImplementedException();
        }
        public async Task<especieeW> UpdateAsync(especieeW especieeW){
            var nuevo_especieeW = await _db.especieeW
            .Include(h => h.Habilidades)
            .FirstOrDefaultAsync(h => h.Id == especieeW.Id);
            
            if (nuevo_especieeW == null) return null;
            nuevo_especieeW.Nombre = especieeW.Nombre;
            nuevo_especieeW.Apellido = especieeW.Apellido;
            nuevo_especieeW.Habilidades = especieeW.Habilidades;
            await _db.SaveChangesAsync();
            return nuevo_especieeW;
        }

        Task<IEnumerable<Especie>> IEspeciesRepository.Getasync()
        {
            throw new NotImplementedException();
        }

        Task<Especie> IEspeciesRepository.GetIdasync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Especie> Postasync(Especie especie)
        {
            throw new NotImplementedException();
        }

        public Task<Especie> PutIdasync(int id, Especie especie)
        {
            throw new NotImplementedException();
        }
    }
}