using Consensus.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Consensus.WEB.Controllers
{
    public class InformesController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public InformesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Pedidos()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
