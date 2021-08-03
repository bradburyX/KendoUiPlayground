using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KendoUiPlayground.Models;
using KendoUiPlayground.Repository;
using KendoUiPlayground.Repository.Model;
using Mapster;

namespace KendoUiPlayground.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController()
        {
            _context = new Context();
        }
        public IActionResult Index()
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
