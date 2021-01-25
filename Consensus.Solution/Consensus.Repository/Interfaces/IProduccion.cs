using Consensus.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consensus.Repository.Interfaces
{
    public interface IProduccion
    {
        public Task<int> AddProduccionDiaria(List<ProduccionDiaria> prod, DateTime Fecha);
        public Task<List<ProduccionDiaria>> GetAll();
        public Task<ProduccionDiaria> GetByFecha(DateTime Fecha);
        public Task<ProduccionDiaria> GetByFecha(DateTime Desde, DateTime Hasta);
        public Task<ProduccionDiaria> GetById(int IdProduccion);
    }
}