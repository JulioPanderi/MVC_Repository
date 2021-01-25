using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consensus.Entidades
{
    public class ProduccionDiaria
    {
        public int IdProduccion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdFigura { get; set; }
        public string Figura { get; set; }
        public int Combinacion { get; set; }
        public int CantidadSets { get; set; }
        public int CantidadTotal { get; set; }
        public decimal PrecioSet { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}
