using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvProjeKamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator validationRules = new ContactValidator();
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            var contactValues = contactManager.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetById(id);
            return View(contactValues);
        }
        public PartialViewResult MessageListMenu()
        {
            var contactValues = contactManager.GetList().Count();
            ViewBag.iletisim = contactValues;
            ViewBag.Giden = messageManager.GetListSendbox().Count();
            ViewBag.Gelen = messageManager.GetListInbox().Count();
            return PartialView();
        }

    }
}