using System;
using System.Collections.Generic;
using System.Text;
using Consensus.Repository.Entities;
using Consensus.Repository.Repositories;
using Consensus.Repository.Interfaces;
using Consensus.BR.Interfaces;
using System.Threading.Tasks;

namespace Consensus.BR.Services
{
    public class ClienteService : IClienteService
    {
        public async Task<List<Cliente>> GetClientes()
        {
            IClientes clientes = new ClienteRepository();
            return clientes.GetAll().Result;
        }

        public async Task<Cliente> GetCliente(int IdCliente)
        {
            IClientes clientes = new ClienteRepository();
            return clientes.GetById(IdCliente).Result;
        }
    }
}
