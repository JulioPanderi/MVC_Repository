using Consensus.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consensus.Repository.Interfaces
{
    public interface IProduccion
    {
        Task<int> AddProduccionDiaria(ProduccionDiaria prod);
        Task<List<ProduccionDiaria>> GetAll();
        Task<ProduccionDiaria> GetByFecha(DateTime Fecha);
        Task<List<ProduccionDiaria>> GetByFecha(DateTime Desde, DateTime Hasta);
        Task<ProduccionDiaria> GetById(int IdProduccion);
    }
}