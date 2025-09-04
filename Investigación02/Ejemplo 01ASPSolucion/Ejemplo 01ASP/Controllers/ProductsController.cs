using Ejemplo_01ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Ejemplo_01ASP.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m },
            new Product { Id = 2, Name = "Smarthphone", Price = 499.99m },
            new Product { Id = 3, Name = "SmartWatch", Price = 65.99m }, 
            new Product { Id = 4, Name = "Tablet", Price = 325.54m }
        };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = products.Count + 1;
                products.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
