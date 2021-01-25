using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consensus.DAL.Entities
{
    public class ProduccionDiaria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduccion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int IdFigura { get; set; }

        [Required]
        public int Combinacion { get; set; }

        [Required]
        public int CantidadSets { get; set; }

        [Required]
        public int CantidadTotal{ get; set; }

        [Required]
        public decimal PrecioSet { get; set; }

        [Required]
        public decimal PrecioTotal { get; set; }
    }
}
