using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.db;
using WebApplication1.models;

namespace WebApplication1.Patron_Repository
{
    public class MandrilRepository : IMandrilRepository
    {
        private readonly Dbconnect _db;

        public MandrilRepository(Dbconnect db){
            _db = db;
        }

        public async Task<Mandril> Postasync(Mandril mandril){
            _db.Mandril.Add(mandril);
            await _db.SaveChangesAsync();
            return mandril;
        }


        public async Task<bool> DeleteIdasync(int id){
            var mandril = await _db.Mandril.FindAsync(id);
            if (mandril == null){
                return false;
            }
            
            _db.Mandril.Remove(mandril);
            await _db.SaveChangesAsync();
            return true;
        }
         public async Task<IEnumerable<Mandril>> Getasync(){
             return await _db.Mandril.Include(m => m.Habilidades).ToListAsync();
        }
         
         public async Task<Mandril?> GetMandrilAsync(int id){
            return await _db.Mandril
            .Include(m=> m.Habilidades)
            .FirstOrDefaultAsync(m => m.Id == id);
        }
        public Task<Mandril> PutIdasync(int id, Mandril mandril){
            throw new NotImplementedException();
        }

        public Task<Mandril> GetIdasync(int id){
            throw new NotImplementedException();
        }
        public async Task<Mandril> UpdateAsync(Mandril mandril){
            var nuevo_mandril = await _db.Mandril
            .Include(h => h.Habilidades)
            .FirstOrDefaultAsync(h => h.Id == mandril.Id);
            
            if (nuevo_mandril == null) return null;
            nuevo_mandril.Nombre = mandril.Nombre;
            nuevo_mandril.Apellido = mandril.Apellido;
            nuevo_mandril.Habilidades = mandril.Habilidades;
            await _db.SaveChangesAsync();
            return nuevo_mandril;
        }
    }
}