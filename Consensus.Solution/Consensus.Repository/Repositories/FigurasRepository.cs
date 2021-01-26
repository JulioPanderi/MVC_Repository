using Consensus.Entidades;
using System;
using System.Collections.Generic;
using Consensus.DAL.DataContext;
using Consensus.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Consensus.Repository.Interfaces;

namespace Consensus.Repository.Repositories
{
    public class FiguraRepository : IFiguras
    {
        public async Task<List<Figura>> GetAll()
        {
            List<Figura> retValue = new List<Figura>();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from c in dbContext.Figuras
                            orderby c.Nombre
                            select new Figura
                            {
                                IdFigura = c.IdFigura,
                                Nombre = c.Nombre,
                                Costo = c.Costo
                            }).ToList();

            }
            return retValue;
        }

        public async Task<Figura> GetById(int Id)
        {
            Figura retValue = new Figura();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from c in dbContext.Figuras
                            where c.IdFigura == Id
                            select new Figura
                            {
                                IdFigura = c.IdFigura,
                                Nombre = c.Nombre,
                                Costo = c.Costo
                            }).FirstOrDefault();

            }
            return retValue;
        }

        public async Task<List<Figura>> Find(string nombre)
        {
            List<Figura> retValue = new List<Figura>();
            using (DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                retValue = (from c in dbContext.Figuras
                            where c.Nombre.Contains(nombre)
                            select new Figura
                            {
                                IdFigura = c.IdFigura,
                                Nombre = c.Nombre,
                                Costo = c.Costo
                            }).ToList();
            }
            return retValue;
        }
    }
}
