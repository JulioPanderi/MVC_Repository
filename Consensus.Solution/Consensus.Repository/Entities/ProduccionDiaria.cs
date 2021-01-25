using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consensus.Repository.Entities
{
    public class ProduccionDiaria
    {
        public int IdProduccion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdFigura { get; set; }
        public string Figura { get; set; }
        /// <summary>
        /// Cantidad de figuras
        /// </summary>
        public int Cantidad { get; set; }
    }
}
