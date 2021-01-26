using Consensus.DAL.Entities;
using Consensus.Repository.Interfaces;
using Consensus.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consensus.BR.Services
{
    public class InformesService
    {
        public async Task<ProduccionDiaria> GetProduccionDiaria(DateTime fecha)
        {
            IProduccion produccion = new ProduccionRepository();
            return await produccion.GetByFecha(fecha);
        }
    }
}
