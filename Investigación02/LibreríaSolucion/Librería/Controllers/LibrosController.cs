using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Librería.Models;

namespace Librería.Controllers
{
    public class LibrosController : Controller
    {
        private static List<Libros> libros = new List<Libros>
        {
            new Libros { Id = 1, NameBook = "Laptop", NameAuthor = "Hola", anioPubli = 2014 },
            new Libros { Id = 2, NameBook = "Smarthphone", NameAuthor = "Hola", anioPubli = 2010 },
            new Libros { Id = 3, NameBook = "SmartWatch", NameAuthor = "Hola", anioPubli = 1980 },
            new Libros { Id = 4, NameBook = "Tablet", NameAuthor = "Hola", anioPubli = 2013 }
        };

        public IActionResult Directorio()
        {
            return View(libros);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Detalles(int Id)
        {
            var libro = libros.FirstOrDefault(libro => libro.Id == Id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        [HttpPost]
        public IActionResult Create(Libros libro)
        {
            if (ModelState.IsValid)
            {
                libro.Id = libros.Count + 1;
                libros.Add(libro);
                return RedirectToAction("Directorio");
            }
            return View(libro);
        }
    }
}
