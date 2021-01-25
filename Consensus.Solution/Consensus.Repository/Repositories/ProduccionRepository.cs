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
    public class ProduccionRepository : IProduccion
    {
        public async Task<List<ProduccionDiaria>> GetAll()
        {
            List<ProduccionDiaria> retValue = new List<ProduccionDiaria>();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from p in dbContext.ProduccionesDiaria
                            join f in dbContext.Figuras on p.IdFigura equals f.IdFigura
                            orderby p.IdProduccion descending
                            select new ProduccionDiaria
                            {
                                IdProduccion = p.IdProduccion,
                                IdFigura = p.IdFigura,
                                Figura = f.Nombre,
                                Fecha = p.Fecha,
                                CantidadSets = p.CantidadSets,
                                Combinacion = p.Combinacion,
                                CantidadTotal = p.CantidadTotal,
                                PrecioSet = p.PrecioSet,
                                PrecioTotal = p.PrecioTotal
                            }).ToList();
            }
            return retValue;
        }

        public async Task<ProduccionDiaria> GetById(int IdProduccion)
        {
            ProduccionDiaria retValue = new ProduccionDiaria();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from p in dbContext.ProduccionesDiaria
                            join f in dbContext.Figuras on p.IdFigura equals f.IdFigura
                            where p.IdProduccion == IdProduccion
                            orderby p.IdProduccion descending
                            select new ProduccionDiaria
                            {
                                IdProduccion = p.IdProduccion,
                                IdFigura = p.IdFigura,
                                Figura = f.Nombre,
                                Fecha = p.Fecha,
                                CantidadSets = p.CantidadSets,
                                Combinacion = p.Combinacion,
                                CantidadTotal = p.CantidadTotal,
                                PrecioSet = p.PrecioSet,
                                PrecioTotal = p.PrecioTotal
                            }).FirstOrDefault();
            }
            return retValue;
        }

        public async Task<ProduccionDiaria> GetByFecha(DateTime Fecha)
        {
            ProduccionDiaria retValue = new ProduccionDiaria();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from p in dbContext.ProduccionesDiaria
                            join f in dbContext.Figuras on p.IdFigura equals f.IdFigura
                            where p.Fecha == Fecha
                            select new ProduccionDiaria
                            {
                                IdProduccion = p.IdProduccion,
                                IdFigura = p.IdFigura,
                                Figura = f.Nombre,
                                Fecha = p.Fecha,
                                CantidadSets = p.CantidadSets,
                                Combinacion = p.Combinacion,
                                CantidadTotal = p.CantidadTotal,
                                PrecioSet = p.PrecioSet,
                                PrecioTotal = p.PrecioTotal
                            }).FirstOrDefault(); 
            }
            return retValue;
        }

        public async Task<List<ProduccionDiaria>> GetByFecha(DateTime Desde, DateTime Hasta)
        {
            List<ProduccionDiaria> retValue = new List<ProduccionDiaria>();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from p in dbContext.ProduccionesDiaria
                            join f in dbContext.Figuras on p.IdFigura equals f.IdFigura
                            where p.Fecha >= Desde && p.Fecha <= Hasta
                            orderby p.IdProduccion descending
                            select new ProduccionDiaria
                            {
                                IdProduccion = p.IdProduccion,
                                IdFigura = p.IdFigura,
                                Figura = f.Nombre,
                                Fecha = p.Fecha,
                                CantidadSets = p.CantidadSets,
                                Combinacion = p.Combinacion,
                                CantidadTotal = p.CantidadTotal,
                                PrecioSet = p.PrecioSet,
                                PrecioTotal = p.PrecioTotal
                            }).ToList();
            }
            return retValue;
        }

        public async Task<int> AddProduccionDiaria(ProduccionDiaria prod)
        {
            int retValue = 0;
            if (prod != null)
            {
                using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
                {
                    DAL.Entities.ProduccionDiaria p = new DAL.Entities.ProduccionDiaria();  

                    p.IdProduccion = prod.IdProduccion;
                    p.IdFigura = prod.IdFigura;
                    p.Fecha = prod.Fecha;
                    p.CantidadSets = prod.CantidadSets;
                    p.Combinacion = prod.Combinacion;
                    p.CantidadTotal = prod.CantidadTotal;
                    p.PrecioSet = prod.PrecioSet;
                    p.PrecioTotal = prod.PrecioTotal;

                    dbContext.Add(p);
                    dbContext.SaveChanges();
                    retValue = p.IdProduccion;
                }
            }
            return retValue;
        }
    }
}
