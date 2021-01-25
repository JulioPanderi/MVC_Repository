using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consensus.DAL.Entities
{
    public class OrdenPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdPedido { get; set; }
        
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdFigura { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public int Combinacion { get; set; }

        [Required]
        public int Total { get; set; }
    }
}
