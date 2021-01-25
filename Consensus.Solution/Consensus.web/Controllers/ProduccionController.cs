using Consensus.Repository.Repositories;
using Consensus.Repository.Entities;
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

        public ProduccionController(ILogger<ProduccionController> logger)
        {
            _logger = logger;
        }

        public IActionResult Carga()
        {
            GetFiguras();
            ViewBag.Detalle = new List<ProduccionDetalleModel>();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void GetFiguras()
        {
            FiguraRepository repository = new FiguraRepository();
            List<Figura> lista = repository.GetAll().Result;
            /*
            ViewBag.Figuras = lista.Select(x => new SelectListItem
                {
                    Value = x.IdFigura.ToString() ,
                    Text = x.Nombre + " (" + String.Format("{ 0:0.00 }" + ")", x.Costo)
            }
            ).ToList();
            */
        }
    }
}
