using System;
using System.Collections.Generic;
using Consensus.Entidades;
using Consensus.Repository.Repositories;
using Consensus.Repository.Interfaces;
using System.Threading.Tasks;
using Consensus.BR.Interfaces;

namespace Consensus.BR.Services
{
    public class OrdenPedidoService : IOrdenPedidoService
    {
        public async Task<List<OrdenPedido>> GetOrdenesPedido()
        {
            IOrdenesPedido ordenesPedido = new OrdenPedidoRepository();
            return await ordenesPedido.GetAll();
        }

        public async Task<OrdenPedido> GetOrdenPedido(int IdOrdenPedido)
        {
            IOrdenesPedido ordenesPedido = new OrdenPedidoRepository();
            return await ordenesPedido.GetById(IdOrdenPedido);
        }
    }
}
