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
    }
}
