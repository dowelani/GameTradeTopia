using GameTradeTopia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
namespace GameTradeTopia.Controllers
{
    public class LoginController : Controller
    {
        private Models.GameTradeTopia model = new Models.GameTradeTopia();
        [HttpGet]
        public ActionResult home()
        {
            return View();
        }
        [HttpPost]
        public ActionResult pass()
        {
           var usertype = Request.Form["user_type"];
           Session["usertype"] = usertype; 
           return RedirectToAction("verifyUser");       
        }

        [HttpGet]
        public ActionResult verifyUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult passTo()
        {
            var email_address = Request.Form["email_address"];
            var password = Request.Form["password"];
            return lookUp(new User(email_address, password));
        }

        private ActionResult lookUp(User user)
        {
            var cur_userType = Session["usertype"].ToString();
            if (cur_userType.Equals("admin"))
            {
                Administration admin = (from cur_user in model.Administrations  where cur_user.emailAddress.Equals(user.Email_Address)
                               select cur_user).SingleOrDefault();
                TempData.Add("cA", admin.adminID);
                if (admin.password.Equals(user.Password))
                {
                    return RedirectToAction("ViewTraders", "Admin"); 
                }
                else
                {
                    TempData.Remove("cA");
                    ViewBag.message = "*email or password incorrect";
                    return View("verifyUser");
                }
            }
            else
            {
               
                Trader trader = (from cur_trader in model.Traders
                             where cur_trader.emailAddress.Equals(user.Email_Address)
                             select cur_trader).SingleOrDefault();
                TempData.Add("c", trader.traderID);
                if (trader.password.Equals(user.Password))
                {
                    return RedirectToAction("TraderRatings", "Trader");  
                }
                else
                {
                    TempData.Remove("c");
                    ViewBag.message = "*email or password incorrect";
                    return View("verifyUser");
                }
            }
        }
    }
}