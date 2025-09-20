using Microsoft.AspNetCore.Mvc;
using CotizacionWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace CotizacionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<DressViewModel> _dresses = new List<DressViewModel>
        {
    new DressViewModel { Id = 1, Name = "Vestido de Quincea�era Princesa Rosa", Price = 400, ImageUrl = "/imagen/vestido1.jpg", Description = "Vestido estilo princesa color rosa pastel, con pedrer�a y falda amplia." },
    new DressViewModel { Id = 2, Name = "Vestido Durazno Rom�ntico", Price = 450, ImageUrl = "/imagen/vestido1.jpg", Description = "Vestido en tono durazno claro, falda vaporosa y detalles en pedrer�a." },
    new DressViewModel { Id = 3, Name = "Vestido Lila de Ensue�o", Price = 500, ImageUrl = "/imagen/vestido1.jpg", Description = "Vestido lila suave con falda amplia, corset ajustado y aplicaciones brillantes." },
    new DressViewModel { Id = 4, Name = "Vestido Azul Elegante", Price = 480, ImageUrl = "/imagen/vestido1.jpg", Description = "Vestido azul con corte elegante y detalles en encaje." },
    new DressViewModel { Id = 5, Name = "Vestido Verde Primavera", Price = 470, ImageUrl = "/imagen/vestido1.jpg", Description = "Vestido verde menta suave, ligero y fresco." },
    new DressViewModel { Id = 6, Name = "Vestido Rojo Pasi�n", Price = 520, ImageUrl = "/imagen/vestido1.jpg", Description = "Vestido rojo intenso con falda amplia y escote elegante." },
    new DressViewModel { Id = 7, Name = "Vestido Rosa Chic", Price = 460, ImageUrl = "/imagen/vestido1.jpg", Description = "Vestido rosa pastel con detalles de pedrer�a en el corset." },
    new DressViewModel { Id = 8, Name = "Vestido Champ�n Sofisticado", Price = 500, ImageUrl = "/imagen/vestido1.jpg", Description = "Vestido color champ�n con corte recto y elegante." },
    new DressViewModel { Id = 9, Name = "Vestido Lila Brillante", Price = 490, ImageUrl = "/imagen/vestido1.jpg", Description = "Vestido lila con falda vaporosa y aplicaciones brillantes." },
    new DressViewModel { Id = 10, Name = "Vestido Noche Estelar", Price = 530, ImageUrl = "/imagen/vestido1.jpg", Description = "Vestido negro con detalles en pedrer�a simulando estrellas." }
};
        public IActionResult Index()
        {
            return View(_dresses);
        }

        public IActionResult Details(int id)
        {
            var dress = _dresses.FirstOrDefault(d => d.Id == id);
            if (dress == null)
            {
                return NotFound();
            }
            return View(dress);
        }
    }
}