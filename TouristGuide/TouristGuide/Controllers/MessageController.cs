using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.BLL;
using TouristGuide.Models;

namespace TouristGuide.Controllers
{
    public class MessageController : Controller
    {

        MessageManager _messageManager = new MessageManager();
        Message _message = new Message();
        // GET: Message
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Message message)
        {
            if (_messageManager.Add(message))
            {
                ViewBag.successMsg = "Message Sent";
            }

            else
            {
                ViewBag.failMsg = "Failed to send";
            }
            return View(message);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _message.Id = id;
            var amessage = _messageManager.GetById(_message);
            return View(amessage);
        }

        [HttpPost]
        public ActionResult Delete(Message message)
        {
            if (_messageManager.Delete(message))
            {
                ViewBag.successMsg = "Deleted";
            }
            else
            {
                ViewBag.failMsg = "Already deleted";
            }
            return View(message);
        }

        public ActionResult Show()
        {
            _message.Messages = _messageManager.GetAll();
            if (_message.Messages.Count == 0)
            {
                ViewBag.Msg = "No message found";
            }
            return View(_message);
        }
    }
}