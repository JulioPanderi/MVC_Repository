using Consensus.BR.Services;
using Consensus.Entidades;
using Consensus.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Consensus.WEB.Controllers
{
    public class ProduccionController : Controller
    {
        private readonly ILogger<ProduccionController> _logger;
        //private readonly BR.Interfaces.IProduccionService produccionService;
        private readonly BR.Interfaces.IProduccionService produccionService = new ProduccionService();

        public ProduccionController(ILogger<ProduccionController> logger)
        {
            _logger = logger;
        }

        public IActionResult Carga()
        {
            ProduccionModel model = new ProduccionModel();
            model.Figuras = GetFiguras();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IEnumerable<SelectListItem> GetFiguras()
        {
            List<Figura> lista = produccionService.GetFiguras().Result;
            return (from f in lista
                    select new SelectListItem
                    {
                        Value = f.IdFigura.ToString(),
                        Text = f.Nombre 
                    }).ToList();
        }
        
        public IActionResult Carga(ProduccionModel model)
        {
            Entidades.ProduccionDiaria prod = new ProduccionDiaria();
            decimal costo = produccionService.GetFigura(model.IdFigura).Result.Costo;
            
            prod.IdFigura = model.IdFigura;
            prod.CantidadSets = model.CantidadSets;
            prod.Combinacion = model.Combinacion;
            prod.Fecha = model.Fecha;
            prod.PrecioSet = 1;
            prod.PrecioTotal = (prod.CantidadSets * prod.Combinacion) * costo;
            
            produccionService.GuardarProducion(prod);
            return View(model);
        }
    }
}
