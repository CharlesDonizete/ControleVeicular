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
        private readonly IAnuncioRepository anuncioRepository;

        public HomeController(IAnuncioRepository anuncioRepository)
        {
            this.anuncioRepository = anuncioRepository;
        }

        public IActionResult Index()
        {
            return View(anuncioRepository.GetAnuncios());
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
