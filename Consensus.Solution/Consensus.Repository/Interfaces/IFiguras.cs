using Consensus.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consensus.Repository.Interfaces
{
    public interface IFiguras
    {
        Task<List<Figura>> Find(string nombre);
        Task<List<Figura>> GetAll();
        Task<Figura> GetById(int Id);
    }
}