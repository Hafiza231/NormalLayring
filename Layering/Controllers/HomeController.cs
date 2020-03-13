using Layering.BL;
using Layring.EL.Model;
using Layring.EL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Layering.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult GetList()
        {
            UserBL ubl = new UserBL();
            List<UserViewModel> list= ubl.GetUserList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserViewModel vmodel)
        {
            UserBL ubl = new UserBL();
            var ReturnCBL=ubl.AddUserBL(vmodel);
            if (ReturnCBL)
            {
                return RedirectToAction("GetList");
            }
            else
            {
                return View();
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}