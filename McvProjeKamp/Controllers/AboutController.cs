using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvProjeKamp.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetList();
            return View(aboutValues);
        }
        [HttpPost]
        public ActionResult AboutAdd(About about)
        {
            aboutManager.AboutAdd(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial() {
            return PartialView();
        }
    }
}