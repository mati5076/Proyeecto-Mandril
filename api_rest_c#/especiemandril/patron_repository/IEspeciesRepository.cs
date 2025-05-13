using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using especiemandril.models;

namespace especiemandril.patron_repository
{
    public interface IEspeciesRepository
    {
        Task<IEnumerable<Especie>> Getasync();
        
        Task<Especie> GetIdasync(int id);
        
        Task<Especie> Postasync(Especie especie);
        
        Task<Especie> PutIdasync(int id, Especie especie);

        Task<bool> DeleteIdasync(int id);
    }
}