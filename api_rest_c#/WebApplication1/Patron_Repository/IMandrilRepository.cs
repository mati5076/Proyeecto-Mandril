using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.models;

namespace WebApplication1.Patron_Repository
{
    public interface IMandrilRepository
    {
        Task<IEnumerable<Mandril>> Getasync();

        Task<Mandril> GetIdasync(int id);

        Task<Mandril> Postasync(Mandril mandril);

        Task<Mandril> PutIdasync(int id, Mandril mandril);

        Task<bool> DeleteIdasync(int id);
    }
}