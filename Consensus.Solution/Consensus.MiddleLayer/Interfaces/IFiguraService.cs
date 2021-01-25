using Consensus.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consensus.BR.Interfaces
{
    public interface IFiguraService
    {
        Task<Figura> GetFigura(int IdFigura);
        Task<List<Figura>> GetFiguras();
    }
}