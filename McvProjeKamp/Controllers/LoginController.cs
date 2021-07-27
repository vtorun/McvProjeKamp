using BusinessLayer.Concrete;
using BusinessLayer.Hashing;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace McvProjeKamp.Controllers
{
    public class LoginController : Controller
    {
        AdminLoginManager adminLoginManager = new AdminLoginManager(new EfAdminLoginDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index(Admin admin)
        {
            //Context context = new Context();
            // var adminuserinfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            var adminuserinfo = adminLoginManager.GetByAdmin(admin.AdminUserName, admin.AdminPassword);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}


//Context context = new Context();
//var adminuserinfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
//if (adminuserinfo != null)
//{
//    FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
//    Session["AdminUserName"] = adminuserinfo.AdminUserName;
//    return RedirectToAction("Index", "AdminCategory");
//}
//else
//{
//    return RedirectToAction("Index");
//}
//return View();
//        }