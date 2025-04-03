using Microsoft.AspNetCore.Mvc;
using CrudProdutos.Data;
using CrudProdutos.Models;
using System.Linq;

namespace CrudProdutos.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var produtos = _context.Produtos.ToList();
            return View(produtos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }


        public IActionResult Edit(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null) return NotFound();
            return View(produto);
        }

        [HttpPost]
        public IActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Update(produto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public IActionResult Delete(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null) return NotFound();
            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var produto = _context.Produtos.Find(id);
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
