using GameTradeTopia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace GameTradeTopia.Controllers
{
    public class TraderController : Controller
    {
        private Models.Model1 model = new Models.Model1();
        GameTradeTopia.Models.Trader curTrader = null;
        // GET: Trader
        public ActionResult TraderRatings()
        {
            ViewData["trader"] = model.Traders.ToList();
            ViewData["rating"] = model.traderRatings.ToList();
            return View();
        }
        public ActionResult Rate(int? id)
        {
            ViewData["trader"] = model.Traders.ToList();
            ViewData["rating"] = model.traderRatings.ToList();
            if (ViewData["dataID"] != null)
            {
                ViewData.Remove("dataID");
            }
            ViewData["dataID"] = id;
            List<Game> games = model.Games.ToList();
            return View(games);
        }
        [HttpPost]
        public ActionResult rate()
        {
            var rate = Request.Form["rate"];
            int r = rate.AsInt();
            int id = (int)TempData["id"];
            traderRating traderRating1 = (from traderRating in model.traderRatings
                                    where traderRating.traderID.Equals(id)
                                    select traderRating).SingleOrDefault();
            traderRating1.numOfRaters = traderRating1.numOfRaters + 1;
            traderRating1.sumOfRates = traderRating1.sumOfRates + r;
            traderRating1.traderStars = (traderRating1.sumOfRates)/ traderRating1.numOfRaters;

            model.Entry(traderRating1).State = System.Data.Entity.EntityState.Modified;
            model.SaveChanges();
            return RedirectToAction("TraderRatings");
        }
        public ActionResult profile()
        {
          //  int id = (int)TempData.Peek("c");
            var traders = model.Traders;
            var profile = traders.Find(1);
            ViewBag.id = 1;
            return View(profile);
        }
        public ActionResult viewRegistrationFeedback()
        {
           // int id = (int)TempData.Peek("c");
            var traders = model.Traders;
            curTrader = traders.Find(1);
            return View("_viewRegistrationFeedback", curTrader);
        }

        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult register(Models.Trader newItem, HttpPostedFileBase idCop)
        {
            if (idCop != null)
            {
                newItem.idCopy = new byte[idCop.ContentLength];
                idCop.InputStream.Read(newItem.idCopy, 0, idCop.ContentLength);
            }
            newItem.appealFeedback = "none";
            newItem.adminComments = "none";
            newItem.blacklisted = "no";
            newItem.approved = "no";
            string[] date = DateTime.Today.Date.ToString().Split(' ');
            newItem.registrationDate = date[0];
            model.Traders.Add(newItem);
            model.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("register","Trader");
        }

        public ActionResult MaintainGameCatalogue()
        {
            ViewData["games"] = model.Games.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult MaintainGameCatalogue(Models.Game newItem, HttpPostedFileBase pic)
        {
            if (pic != null)
            {
                newItem.image = new byte[pic.ContentLength];
                pic.InputStream.Read(newItem.image, 0, pic.ContentLength);
            }
           
            model.Games.Add(newItem);
            model.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("MaintainGameCatalogue", "Trader");
        }



    }
}
