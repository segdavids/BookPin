using CBLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookPin.Controllers
{
    public class CBLoginController : Controller
    {
        // GET: CBLogin
        [HttpPost]
        public ActionResult Index(CBUserModel model)
        {
            ConsumerBankingEntities cbe = new ConsumerBankingEntities();
            var s = cbe.GetCBLoginInfo(model.UserName, model.Password);

            var item = s.FirstOrDefault();
            if (item == "Success")
            {

                return View("UserLandingView");
            }
            else if (item == "User Does not Exists")

            {
                ViewBag.NotValidUser = item;

            }
            else
            {
                ViewBag.Failedcount = item;
            }
            return View("Index");
        }

        public ActionResult UserLandingView()
        {
            return View();
        }
    }
}