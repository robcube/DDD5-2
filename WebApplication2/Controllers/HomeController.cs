using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult Status()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<Hubs.StatusHub>();
            context.Clients.All.addNewMessageToPage("Admin", "stop the chat");
            return View();
        }

        public JsonResult GetStatus()
        {
            var entity = new StatusModel();
            var data = entity.StatusUpdates;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
