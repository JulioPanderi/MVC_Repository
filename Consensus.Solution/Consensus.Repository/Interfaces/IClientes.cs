using Consensus.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consensus.Repository.Interfaces
{
    public interface IClientes
    {
        Task<List<Cliente>> Find(string nombre);
        Task<List<Cliente>> GetAll();
        Task<Cliente> GetById(int Id);
    }
}