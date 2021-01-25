using System;
using System.Collections.Generic;
using System.Text;
using Consensus.Entidades;
using Consensus.Repository.Repositories;
using Consensus.Repository.Interfaces;
using System.Threading.Tasks;
using Consensus.BR.Interfaces;

namespace Consensus.BR.Services
{
    public class FiguraService : IFiguraService
    {
        public async Task<List<Figura>> GetFiguras()
        {
            IFiguras figuras = new FiguraRepository();
            return await figuras.GetAll();
        }

        public async Task<Figura> GetFigura(int IdFigura)
        {
            IFiguras figuras = new FiguraRepository();
            return await figuras.GetById(IdFigura);
        }
    }
}
