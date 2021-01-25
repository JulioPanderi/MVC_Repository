using Consensus.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Consensus.DAL.DataContext;
using Consensus.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Consensus.Repository.Interfaces;

namespace Consensus.Repository.Repositories
{
    public class ClienteRepository : IClientes
    {
        public async Task<List<Cliente>> GetAll()
        {
            List<Cliente> retValue = new List<Cliente>();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from c in dbContext.Clientes
                            orderby c.Nombre
                            select new Cliente
                            {
                                IdCliente = c.IdCliente,
                                Nombre = c.Nombre
                            }).ToList();

            }
            return retValue;
        }

        public async Task<Cliente> GetById(int Id)
        {
            Cliente retValue = new Cliente();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from c in dbContext.Clientes
                            where c.IdCliente == Id
                            select new Cliente
                            {
                                IdCliente = c.IdCliente,
                                Nombre = c.Nombre
                            }).FirstOrDefault();

            }
            return retValue;
        }

        public async Task<List<Cliente>> Find(string nombre)
        {
            List<Cliente> retValue = new List<Cliente>();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from c in dbContext.Clientes
                            where c.Nombre.Contains(nombre)
                            select new Cliente
                            {
                                IdCliente = c.IdCliente,
                                Nombre = c.Nombre
                            }).ToList();

            }
            return retValue;
        }
    }
}
