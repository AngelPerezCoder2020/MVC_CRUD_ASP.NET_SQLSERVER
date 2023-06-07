using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticasCRUD.Models;
using PracticasCRUD.SqlConnector;

namespace PracticasCRUD.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            List<Category> items = ConnectorDB.getCategories();
            return View(items);
        }
        public ActionResult Borrar(int id) {
            return ConnectorDB.borrarCategory(id)?RedirectToAction("Index","Category"):null;
        }

        [HttpPost]
        public ActionResult Editar2(Category c)
        {
            return ConnectorDB.editarCategory(c)?RedirectToAction("Index", "Category"):null;
        }
        public ActionResult Editar(Category c)
        {
            return View(c);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo2(Category c)
        {
            return ConnectorDB.crearCategory(c)?RedirectToAction("Index", "Category"):null;
        }
    }
}