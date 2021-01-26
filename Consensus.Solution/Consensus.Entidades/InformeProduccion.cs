using System;
using System.Collections.Generic;
using System.Text;

namespace Consensus.Entidades
{
    public class InformeProduccion 
    {
        public int IdFigura { get; set; }
        public string Figura { get; set; }
        public DateTime Fecha { get; set; }
        public long CantidadTotal { get; set; }
        public decimal CostoPieza { get; set; }
        public decimal CostoFinal { get; set; }
    }
}
