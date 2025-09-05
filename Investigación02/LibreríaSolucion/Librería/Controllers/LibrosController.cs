using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Librería.Models;

namespace Librería.Controllers
{
    public class LibrosController : Controller
    {
        private static List<Libros> libros =
        [
            new() { Id = 1, NameBook = "Cien años de soledad", NameAuthor = "Gabriel García Márquez", anioPubli = 1967 },
            new() { Id = 2, NameBook = "1984", NameAuthor = "George Orwell", anioPubli = 1949 },
            new() { Id = 3, NameBook = "Orgullo y prejuicio (Pride and Prejudice)", NameAuthor = "Jane Austen", anioPubli = 1813 },
            new() { Id = 4, NameBook = "El Señor de los Anillos: La Comunidad del Anillo (The Fellowship of the Ring)", NameAuthor = "J.R.R. Tolkien", anioPubli = 1954 }, 
            new() { Id = 5, NameBook = "La casa de los espíritus", NameAuthor = "Isabel Allende", anioPubli = 1982}
        ];

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
