using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using especiemandril.Dot;
using especiemandril.models;
using especiemandril.patron_repository;
using Microsoft.EntityFrameworkCore;


namespace especiemandril.patron_repository
{
    public class EspecieRepository : IEspeciesRepository{
        private readonly _Dbcontext _db;

        public EspecieRepository(_Dbcontext db)
        {
            _db = db;
        }

        public async Task<Especie> Postasync(Especie especie)
        {
            _db.Especie.Add(especie);
            await _db.SaveChangesAsync();
            return especie;
        }

        public async Task<bool> DeleteIdasync(int id)
        {
            var especie = await _db.Especie.FindAsync(id);
            if (especie == null)
                return false;

            _db.Especie.Remove(especie);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Especie>> Getasync(){
            return await _db.Especie.ToListAsync();
        }
        public async Task<Especie> GetIdasync(int id){
            var especie = await _db.Especie.FirstOrDefaultAsync(e => e.Id == id);
            if (especie == null){
                throw new Exception($"Especie with id {id} not found.");
            }
            return especie;
        }
        public async Task<Especie> PutIdasync(int id, Especie especie){
            var especieExistente = await _db.Especie.FirstOrDefaultAsync(h => h.Id == id);

            if (especieExistente == null)
                throw new KeyNotFoundException($"Especie with id {id} not found.");

            especieExistente.Nombre_especie = especie.Nombre_especie;
            especieExistente.sub_especie = especie.sub_especie;
            especieExistente.cantidad_especie = especie.cantidad_especie;

            await _db.SaveChangesAsync();
            return especieExistente;
        }

    }
}