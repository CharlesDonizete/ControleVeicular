using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVeicular.Controllers
{
    public class AdministrativoController : Controller
    {
        public IActionResult Anuncio()
        {
            return View();
        }

        public IActionResult Modelo()
        {
            return View();
        }

        public IActionResult Marca()
        {
            return View();
        }       
    }
}
