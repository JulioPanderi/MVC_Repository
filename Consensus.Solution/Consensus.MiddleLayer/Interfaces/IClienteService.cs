using System;
using System.Collections.Generic;
using System.Text;
using Consensus.Entidades;
using Consensus.Repository.Repositories;
using Consensus.Repository.Interfaces;
using System.Threading.Tasks;
using Consensus.BR.Interfaces;

namespace Consensus.BR.Interfaces
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetClientes();
        Task<Cliente> GetCliente(int IdCliente);
    }
}
