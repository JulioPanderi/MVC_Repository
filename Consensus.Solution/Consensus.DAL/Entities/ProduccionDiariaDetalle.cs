using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consensus.DAL.Entities
{
    public class ProduccionDiariaDetalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdProduccionDetalle { get; set; }

        [Required]
        public int IdProduccion { get; set; }

        [Required]
        public int IdFigura { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public int Costo { get; set; }
    }
}
