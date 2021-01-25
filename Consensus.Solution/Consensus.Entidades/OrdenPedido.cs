using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consensus.Entidades
{
    public class OrdenPedido
    {
        public long IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public int IdFigura { get; set; }
        public string Figura { get; set; }
        public int Combinacion { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
    }
}
