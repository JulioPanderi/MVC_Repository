using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Consensus.DAL.DataContext;
using Consensus.Repository.Interfaces;
using Consensus.Entidades;

namespace Consensus.Repository.Repositories
{
    public class InformesRepository
    {
        public async Task<List<InformePedidos>> GetPedidos(DateTime fecha)
        {
            //List<InformePedidos> retValue = new List<InformePedidos>();
            IOrdenesPedido repoPedidos = new OrdenPedidoRepository();
            List<InformePedidos> retValue = repoPedidos.GetByFecha(fecha);


            return retValue;
        }
    }
}
