using System;
using System.Collections.Generic;
using System.Text;
using Consensus.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Consensus.DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            #region Constructor
            public OptionsBuild()
            {
                Settings = new AppConfiguration();
                OpsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                OpsBuilder.UseSqlServer(Settings.SQLConnectionString);
                DbOptions = OpsBuilder.Options;

            }
            #endregion 
            public DbContextOptionsBuilder<DatabaseContext> OpsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> DbOptions { get; set; }
            private AppConfiguration Settings { get; set; }            
        }

        public static OptionsBuild ops = new OptionsBuild();
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        #region DbSets
        public DbSet<Figura> Figuras { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<OrdenPedido> OrdenesPedido { get; set; }
        public DbSet<ProduccionDiaria> ProduccionesDiaria { get; set; }
       
        #endregion
    }
}
