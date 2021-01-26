using System;

namespace Consensus.DAL.Entities
{
    public class vResumenDiarioProduccion
    {
        public int IdFigura { get; set; }
        public string Figura { get; set; }
        public DateTime Fecha { get; set; }
        public long CantidadTotal { get; set; }
        public decimal CostoPieza { get; set; }
        public decimal CostoFinal { get; set; }
    }
}
