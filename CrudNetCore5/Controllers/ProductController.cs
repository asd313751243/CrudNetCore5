using CrudNetCore5.Data;
using CrudNetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Http Get Index
        public IActionResult Index()
        {
            IEnumerable<Product> listProduct = _context.Product;
            return View(listProduct);
        }

        // Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        // Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Fecha_Modificacion = DateTime.Now;
                _context.Product.Add(product);
                _context.SaveChanges();

                TempData["message"] = "El producto se ha creado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        // Http Get Edit
        public IActionResult Edit(int? id)
        {
            var producto = _context.Product.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Fecha_Modificacion = DateTime.Now;
                _context.Product.Update(product);
                _context.SaveChanges();

                TempData["message"] = "El producto se ha actualizado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        // Http Get Edit
        public IActionResult Delete(int? id)
        {
            var producto = _context.Product.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product product)
        {
            _context.Product.Remove(product);
            _context.SaveChanges();

            TempData["message"] = "El producto se ha eliminado correctamente";
            return RedirectToAction("Index");
        }

    }
}
