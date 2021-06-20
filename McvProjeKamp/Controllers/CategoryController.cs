using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvProjeKamp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryManager categoryManager = new CategoryManager();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllCategory()
        {
            var categories = categoryManager.getAll();
            return View(categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            categoryManager.CategoryAdd(category);
            return RedirectToAction("GetAllCategory");
        }
    }
}
