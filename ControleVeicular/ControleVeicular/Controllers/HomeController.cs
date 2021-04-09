using ControleVeicular.Models;
using ControleVeicular.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVeicular.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMarcaRepository marcaRepository;

        public HomeController(IMarcaRepository marcaRepository)
        {
            this.marcaRepository = marcaRepository;
        }

        public IActionResult Index()
        {
            return View(marcaRepository.GetMarcas());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
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
