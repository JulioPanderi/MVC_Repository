using System;
using System.Collections.Generic;
using System.Text;
using Consensus.Repository.Entities;
using Consensus.Repository.Repositories;
using Consensus.Repository.Interfaces;
using System.Threading.Tasks;

namespace Consensus.BR.Services
{
    public class FiguraService
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
