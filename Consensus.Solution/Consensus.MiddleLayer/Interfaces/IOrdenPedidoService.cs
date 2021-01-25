using System;
using System.Collections.Generic;
using Consensus.Repository.Entities;
using Consensus.Repository.Repositories;
using System.Threading.Tasks;

namespace Consensus.BR.Contracts
{
    public interface IOrdenPedidoService
    {
        public Task<List<OrdenPedido>> GetOrdenesPedido();
        public Task<OrdenPedido> GetOrdenPedido(int IdOrdenPedido);
    }
}
