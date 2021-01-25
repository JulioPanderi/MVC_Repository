using Consensus.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consensus.BR.Interfaces
{
    public interface IProduccionService
    {
        Task<ProduccionDiaria> GetProduccionDiaria(DateTime fecha);
        Task<List<ProduccionDiaria>> GetProduccionDiaria(DateTime desde, DateTime hasta);
        Task<ProduccionDiaria> GetProduccionDiaria(int IdProduccion);
        Task<List<ProduccionDiaria>> GetProduccionesDiarias();
        Task<int> GuardarProducion(ProduccionDiaria produccionDiaria);
        Task<List<Figura>> GetFiguras();
        Task<Figura> GetFigura(int IdFigura);
    }
}