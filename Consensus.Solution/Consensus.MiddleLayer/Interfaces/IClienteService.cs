using System;
using System.Collections.Generic;
using System.Text;
using Consensus.Repository.Entities;
using Consensus.Repository.Repositories;
using Consensus.Repository.Interfaces;
using System.Threading.Tasks;
using Consensus.BR.Interfaces;

namespace Consensus.BR.Interfaces
{
    public interface IClienteService
    {
        public Task<List<Cliente>> GetClientes();
        public Task<Cliente> GetCliente(int IdCliente);
    }
}
