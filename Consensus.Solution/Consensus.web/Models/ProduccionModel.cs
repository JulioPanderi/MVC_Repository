using Consensus.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consensus.WEB.Models
{
    public class ProduccionModel
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
        
        //Para cargar el combo de figuras
        public IEnumerable<SelectListItem> Figuras { get; set; }
    }
}
