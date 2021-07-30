using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvProjeKamp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        //[Authorize]
        public ActionResult Inbox()
        {
            string userEmail = Session["AdminUserName"].ToString();
            var messageList = messageManager.GetListInbox(userEmail);
            return View(messageList);
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var readMessage = messageManager.GetById(id);
            //readMessage.MessageRead = true;
            messageManager.MessageUpdate(readMessage);
            var Values = messageManager.GetById(id);
            return View(Values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var Values = messageManager.GetById(id);
            return View(Values);
        }
        public ActionResult Sendbox()
        {
            string userEmail = Session["AdminUserName"].ToString();
            var messageList = messageManager.GetListSendbox(userEmail);
            return View(messageList);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();

        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult validationResult = messageValidator.Validate(message);
            if (validationResult.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(message);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}