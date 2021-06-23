using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvProjeKamp.Controllers
{
    public class IstatistikController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            ViewBag.CategoryCount = categoryManager.GetAll().Count();
            ViewBag.YazilimCount = headingManager.GetAll().Where(x => x.CategoryId == 10).Count();
            ViewBag.AInWriter = writerManager.GetAll().Where(x => x.WriterName.Contains("a") || x.WriterName.Contains("A")).Count();
            ViewBag.Sorgu1 = categoryManager.GetAll().Where(x => x.CategoryId == (headingManager.GetAll().GroupBy(h => h.CategoryId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.CategoryName).FirstOrDefault();
            ViewBag.Sorgu2 = categoryManager.GetAll().Where(x => x.CategoryStatus == true).Count() - categoryManager.GetAll().Where(x => x.CategoryStatus == false).Count();
            return View();
        }
    }
}