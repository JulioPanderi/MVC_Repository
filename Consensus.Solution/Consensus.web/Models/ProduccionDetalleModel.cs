using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consensus.WEB.Models
{
    public class ProduccionDetalleModel
    {
        public int IdFigura { get; set; }
        public string Figura { get; set; }
        public int Combinacion { get; set; }
        public int CantidadComb { get; set; }
        public int Cantidad
        {
            get
            {
                return Combinacion * CantidadComb;
            }
        }
        public decimal PrecioSet { get; set; }
        public decimal PrecioTotal
        {
            get
            {
                return PrecioSet * CantidadComb;
            }
        }
    }
}
