using System;
using System.Collections.Generic;
using Consensus.Entidades;
using Consensus.Repository.Repositories;
using System.Threading.Tasks;

namespace Consensus.BR.Interfaces
{
    public interface IOrdenPedidoService
    {
        Task<List<OrdenPedido>> GetOrdenesPedido();
        Task<OrdenPedido> GetOrdenPedido(int IdOrdenPedido);
    }
}
