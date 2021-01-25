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
    public class ProduccionRepository : IProduccion
    {
        public async Task<List<ProduccionDiaria>> GetAll()
        {
            List<ProduccionDiaria> retValue = new List<ProduccionDiaria>();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from p in dbContext.ProduccionesDiaria
                            join det in dbContext.ProduccionesDiariaDetalle on p.IdProduccion equals det.IdProduccion
                            join f in dbContext.Figuras on det.IdFigura equals f.IdFigura
                            orderby p.IdProduccion descending
                            select new ProduccionDiaria
                            {
                                IdProduccion = p.IdProduccion,
                                IdFigura = det.IdFigura,
                                Figura = f.Nombre,
                                Fecha = p.Fecha,
                                Cantidad = det.Cantidad
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
                            join det in dbContext.ProduccionesDiariaDetalle on p.IdProduccion equals det.IdProduccion
                            join f in dbContext.Figuras on det.IdFigura equals f.IdFigura
                            where p.IdProduccion == IdProduccion
                            select new ProduccionDiaria
                            {
                                IdProduccion = p.IdProduccion,
                                IdFigura = det.IdFigura,
                                Figura = f.Nombre,
                                Fecha = p.Fecha,
                                Cantidad = det.Cantidad
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
                            join det in dbContext.ProduccionesDiariaDetalle on p.IdProduccion equals det.IdProduccion
                            join f in dbContext.Figuras on det.IdFigura equals f.IdFigura
                            where p.Fecha == Fecha
                            select new ProduccionDiaria
                            {
                                IdProduccion = p.IdProduccion,
                                IdFigura = det.IdFigura,
                                Figura = f.Nombre,
                                Fecha = p.Fecha,
                                Cantidad = det.Cantidad
                            }).FirstOrDefault();

            }
            return retValue;
        }

        public async Task<ProduccionDiaria> GetByFecha(DateTime Desde, DateTime Hasta)
        {
            ProduccionDiaria retValue = new ProduccionDiaria();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from p in dbContext.ProduccionesDiaria
                            join det in dbContext.ProduccionesDiariaDetalle on p.IdProduccion equals det.IdProduccion
                            join f in dbContext.Figuras on det.IdFigura equals f.IdFigura
                            where p.Fecha >= Desde && p.Fecha <= Hasta
                            select new ProduccionDiaria
                            {
                                IdProduccion = p.IdProduccion,
                                IdFigura = det.IdFigura,
                                Figura = f.Nombre,
                                Fecha = p.Fecha,
                                Cantidad = det.Cantidad
                            }).FirstOrDefault();

            }
            return retValue;
        }

        /// <summary>
        /// Returns IdProduccion
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        private int AddProduccionDiaria(DatabaseContext dbContext, DateTime Fecha)
        {
            DAL.Entities.ProduccionDiaria p = new DAL.Entities.ProduccionDiaria();
            dbContext.ProduccionesDiaria.Add(p);
            dbContext.SaveChanges();
            return p.IdProduccion;
        }

        /// <summary>
        /// Returns IdProduccion
        /// </summary>
        /// <param name="prod">Lista de figuras producidas</param>
        /// <param name="Fecha">Fecha de la produccion</param>
        /// <returns></returns>
        public async Task<int> AddProduccionDiaria(List<ProduccionDiaria> prod, DateTime Fecha)
        {
            int retValue = 0;
            if (prod != null)
            {
                using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
                {
                    retValue = AddProduccionDiaria(dbContext, Fecha);
                    for (int i = 0; i < prod.Count; i++)
                    {
                        DAL.Entities.ProduccionDiariaDetalle d = new DAL.Entities.ProduccionDiariaDetalle();
                        ProduccionDiaria p = prod[i];

                        d.IdProduccion = retValue;
                        d.IdFigura = p.IdFigura;
                        d.Cantidad = p.Cantidad;
                        d.Costo = 0;
                    }
                    dbContext.SaveChanges();
                }
            }
            return retValue;
        }
    }
}
