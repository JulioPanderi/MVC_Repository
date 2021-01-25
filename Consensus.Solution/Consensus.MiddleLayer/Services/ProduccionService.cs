using System;
using System.Collections.Generic;
using Consensus.Repository.Entities;
using Consensus.Repository.Repositories;
using Consensus.Repository.Interfaces;
using Consensus.BR.Interfaces;
using System.Threading.Tasks;

namespace Consensus.BR.Services
{
    public class ProduccionService
    {
        public async Task<List<ProduccionDiaria>> GetProduccionesDiarias()
        {
            IProduccion produccion = new ProduccionRepository();
            return await produccion.GetAll();
        }

        public async Task<ProduccionDiaria> GetProduccionDiaria(int IdProduccion)
        {
            IProduccion produccion = new ProduccionRepository();
            return await produccion.GetById(IdProduccion);
        }

        public async Task<ProduccionDiaria> GetProduccionDiaria(DateTime fecha)
        {
            IProduccion produccion = new ProduccionRepository();
            return await produccion.GetByFecha(fecha);
        }

        public async Task<ProduccionDiaria> GetProduccionDiaria(DateTime desde, DateTime hasta)
        {
            IProduccion produccion = new ProduccionRepository();
            return await produccion.GetByFecha(desde, hasta);
        }

        public async Task<int> GuardarProducion(List<ProduccionDiaria> produccionDiaria, DateTime fecha)
        {
            IProduccion produccion = new ProduccionRepository();
            return await produccion.AddProduccionDiaria(produccionDiaria, fecha);
        }
    }
}
