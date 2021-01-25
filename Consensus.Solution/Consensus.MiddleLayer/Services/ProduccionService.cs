using System;
using System.Collections.Generic;
using Consensus.Entidades;
using Consensus.Repository.Repositories;
using Consensus.Repository.Interfaces;
using Consensus.BR.Interfaces;
using System.Threading.Tasks;

namespace Consensus.BR.Services
{
    public class ProduccionService : IProduccionService
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

        public async Task<List<ProduccionDiaria>> GetProduccionDiaria(DateTime desde, DateTime hasta)
        {
            IProduccion produccion = new ProduccionRepository();
            return await produccion.GetByFecha(desde, hasta);
        }

        public async Task<List<Figura>> GetFiguras()
        {
            IFiguraService figuras = new FiguraService();
            return await figuras.GetFiguras();
        }

        public async Task<Figura> GetFigura(int IdFigura)
        {
            IFiguraService figuras = new FiguraService();
            return await figuras.GetFigura(IdFigura);
        }

        public async Task<int> GuardarProducion(ProduccionDiaria produccionDiaria)
        {
            IProduccion produccion = new ProduccionRepository();
            return await produccion.AddProduccionDiaria(produccionDiaria);
        }

    }
}
