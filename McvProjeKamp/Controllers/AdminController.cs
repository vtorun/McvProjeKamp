using BusinessLayer.Concrete;
using BusinessLayer.Hashing;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvProjeKamp.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllAdmin()
        {
            var admins = adminManager.GetAll();
            return View(admins);
        }
        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(Admin admin)
        {
            adminManager.AdminAdd(admin);
            return RedirectToAction("AdminAdd");
        }
    }
}