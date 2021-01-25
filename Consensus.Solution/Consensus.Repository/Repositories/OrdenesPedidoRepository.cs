using Consensus.Entidades;
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
    public class OrdenPedidoRepository : IOrdenesPedido
    {
        public async Task<List<OrdenPedido>> GetAll()
        {
            List<OrdenPedido> retValue = new List<OrdenPedido>();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from op in dbContext.OrdenesPedido
                            join f in dbContext.Figuras on op.IdFigura equals f.IdFigura
                            orderby op.IdPedido
                            select new OrdenPedido
                            {
                                IdPedido = op.IdPedido,
                                IdFigura = op.IdFigura,
                                IdCliente = op.IdCliente,
                                Fecha = op.Fecha,
                                Cantidad = op.Cantidad,
                                Combinacion = op.Combinacion,
                                Total = op.Total,
                                Figura = f.Nombre
                            }).ToList();

            }
            return retValue;
        }

        public async Task<OrdenPedido> GetById(int Id)
        {
            OrdenPedido retValue = new OrdenPedido();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from op in dbContext.OrdenesPedido
                            join f in dbContext.Figuras on op.IdFigura equals f.IdFigura
                            orderby op.IdPedido
                            select new OrdenPedido
                            {
                                IdPedido = op.IdPedido,
                                IdFigura = op.IdFigura,
                                IdCliente = op.IdCliente,
                                Fecha = op.Fecha,
                                Cantidad = op.Cantidad,
                                Combinacion = op.Combinacion,
                                Total = op.Total,
                                Figura = f.Nombre
                            }).FirstOrDefault();

            }
            return retValue;
        }

        public async Task<List<OrdenPedido>> GetByCliente(int IdCliente)
        {
            List<OrdenPedido> retValue = new List<OrdenPedido>();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from op in dbContext.OrdenesPedido
                            join f in dbContext.Figuras on op.IdFigura equals f.IdFigura
                            where op.IdCliente == IdCliente
                            orderby op.IdPedido
                            select new OrdenPedido
                            {
                                IdPedido = op.IdPedido,
                                IdFigura = op.IdFigura,
                                IdCliente = op.IdCliente,
                                Fecha = op.Fecha,
                                Cantidad = op.Cantidad,
                                Combinacion = op.Combinacion,
                                Total = op.Total,
                                Figura = f.Nombre
                            }).ToList();

            }
            return retValue;
        }

        public async Task<List<OrdenPedido>> GetByFecha(DateTime fecha)
        {
            List<OrdenPedido> retValue = new List<OrdenPedido>();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from op in dbContext.OrdenesPedido
                            join f in dbContext.Figuras on op.IdFigura equals f.IdFigura
                            where op.Fecha == fecha
                            orderby op.IdPedido
                            select new OrdenPedido
                            {
                                IdPedido = op.IdPedido,
                                IdFigura = op.IdFigura,
                                IdCliente = op.IdCliente,
                                Fecha = op.Fecha,
                                Cantidad = op.Cantidad,
                                Combinacion = op.Combinacion,
                                Total = op.Total,
                                Figura = f.Nombre
                            }).ToList();

            }
            return retValue;
        }

        public async Task<List<OrdenPedido>> GetByFecha(DateTime desde, DateTime hasta)
        {
            List<OrdenPedido> retValue = new List<OrdenPedido>();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from op in dbContext.OrdenesPedido
                            join f in dbContext.Figuras on op.IdFigura equals f.IdFigura
                            where op.Fecha >= desde && op.Fecha <= hasta
                            orderby op.IdPedido
                            select new OrdenPedido
                            {
                                IdPedido = op.IdPedido,
                                IdFigura = op.IdFigura,
                                IdCliente = op.IdCliente,
                                Fecha = op.Fecha,
                                Cantidad = op.Cantidad,
                                Combinacion = op.Combinacion,
                                Total = op.Total,
                                Figura = f.Nombre
                            }).ToList();

            }
            return retValue;
        }

        public async Task<long> AddOrdenPedido(int IdFigura, int IdCliente, DateTime Fecha, int Cantidad, int Combinacion)
        {
            long retValue = 0;
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                DAL.Entities.OrdenPedido op = new DAL.Entities.OrdenPedido();
                op.IdFigura = IdFigura;
                op.IdCliente = IdCliente;
                op.Fecha = Fecha;
                op.Cantidad = Cantidad;
                op.Combinacion = Combinacion;
                op.Total = Cantidad * Combinacion;

                dbContext.OrdenesPedido.Add(op);
                dbContext.SaveChanges();
                retValue = op.IdPedido;
            }
            return retValue;
        }
    }
}
