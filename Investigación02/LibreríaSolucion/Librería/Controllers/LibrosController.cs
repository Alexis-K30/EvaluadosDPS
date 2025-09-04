using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Librería.Models;

namespace Librería.Controllers
{
    public class LibrosController : Controller
    {
        private static List<Libros> libros = new List<Libros>
        {
            new Libros { Id = 1, Name = "Laptop", Price = 999.99m },
            new Libros { Id = 2, Name = "Smarthphone", Price = 499.99m },
            new Libros { Id = 3, Name = "SmartWatch", Price = 65.99m },
            new Libros { Id = 4, Name = "Tablet", Price = 325.54m }
        };

        public IActionResult Index()
        {
            return View(libros);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Libros libro)
        {
            if (ModelState.IsValid)
            {
                libro.Id = libros.Count + 1;
                libros.Add(libro);
                return RedirectToAction("Index");
            }
            return View(libro);
        }
    }
}
