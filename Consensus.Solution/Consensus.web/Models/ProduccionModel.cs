using Consensus.Repository.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consensus.WEB.Models
{
    public class ProduccionModel
    {
        public DateTime Fecha { get; set; }
        public List<ProduccionDetalleModel> Detalle { get; set; }
        public int IdFigura { get; set; }
        public string Figura { get; set; }
        public int Combinacion { get; set; }
        public int CantidadCom { get; set; }
        public int Cantidad
        {
            get
            {
                return Combinacion * CantidadCom;
            }
        }
        public int TotalCantidad
        {
            get
            {
                return Detalle.Sum(det => det.Cantidad);
            }
        }
        public Decimal TotalPrecio
        {
            get
            {
                return Detalle.Sum(det => det.PrecioTotal);
            }
        }
        public IEnumerable<SelectListItem> ListaFiguras
        {
            get
            {
                var retValue = Figuras.Select(x => new SelectListItem
                {
                    Value = x.IdFigura.ToString(),
                    Text = x.Nombre + " (" + String.Format("{ 0:0.00 }" + ")", x.Costo)
                }
                ).ToList();
                return retValue;
                //return Detalle.Sum(det => det.PrecioTotal);
            }
        }

        public List<FiguraModel> Figuras { get; set; }
    }
}
