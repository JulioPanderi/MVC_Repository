using Consensus.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consensus.Repository.Interfaces
{
    public interface IOrdenesPedido
    {
        Task<long> AddOrdenPedido(int IdFigura, int IdCliente, DateTime Fecha, int Cantidad, int Combinacion);
        Task<List<OrdenPedido>> GetAll();
        Task<List<OrdenPedido>> GetByCliente(int IdCliente);
        Task<List<OrdenPedido>> GetByFecha(DateTime fecha);
        Task<OrdenPedido> GetById(int Id);
    }
}