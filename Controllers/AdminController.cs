using GameTradeTopia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace GameTradeTopia.Controllers
{
    public class AdminController : Controller
    {
        private Models.GameTradeTopia model = new Models.GameTradeTopia();
        // GET: Admin
        public ActionResult ApproveRegistration()
        {
            ViewData["trader"] = model.Traders.ToList();
            return View();
        }
        public ActionResult approve(int id)
        {
            Trader trader = (from Trader in model.Traders
                             where Trader.traderID.Equals(id)
                             select Trader).SingleOrDefault();
            trader.approved = "yes";
            model.Entry(trader).State = System.Data.Entity.EntityState.Modified;
            model.SaveChanges();
            return RedirectToAction("ApproveRegistration");
        }

        public ActionResult decline(int id)
        {
            Trader trader = (from Trader in model.Traders
                             where Trader.traderID.Equals(id)
                             select Trader).SingleOrDefault();
            trader.approved = "declined";
            model.Entry(trader).State = System.Data.Entity.EntityState.Modified;
            model.SaveChanges();
            return RedirectToAction("ApproveRegistration");
        }

        public ActionResult Blacklist(int? id)
        {
            if (id == 1)
            {
                List<traderRating> list = model.traderRatings.Where(x => x.traderStars <= 3).ToList();
                List<Trader> list2 = model.Traders.ToList();
                List<Trader> list3 = new List<Trader>();
                foreach (traderRating traderRating in list)
                {
                    foreach (Trader trader in list2)
                    {
                        if (traderRating.traderID.Equals(trader.traderID)) { list3.Add(trader); }
                    }
                }
                ViewData["trader"] = list3;
            }

            else
            {
                ViewData["trader"] = model.Traders.ToList();
            }
            return View();
        }



        public ActionResult blacklisted(int id)
        {
            Trader trader = (from Trader in model.Traders
                             where Trader.traderID.Equals(id)
                             select Trader).SingleOrDefault();
            trader.blacklisted = "yes";
            model.Entry(trader).State = System.Data.Entity.EntityState.Modified;
            model.SaveChanges();
            return RedirectToAction("Blacklist");
        }

        public ActionResult BlacklistedProfiles()
        {
            List<Trader> traders = model.Traders.ToList();
            return View(traders);
        }
        public ActionResult BlacklistReport()
        {
            List<Trader> traders = model.Traders.ToList();
            return View(traders);
        }

        public ActionResult addProfile(int id)
        {
            Trader trader = (from Trader in model.Traders
                             where Trader.traderID.Equals(id)
                             select Trader).SingleOrDefault();
            trader.blacklisted = "yes";
            model.Entry(trader).State = System.Data.Entity.EntityState.Modified;
            model.SaveChanges();
            return RedirectToAction("BlacklistReport");
        }
        public ActionResult removeProfile(int id)
        {
            Trader trader = (from Trader in model.Traders
                             where Trader.traderID.Equals(id)
                             select Trader).SingleOrDefault();
            trader.blacklisted = "no";
            model.Entry(trader).State = System.Data.Entity.EntityState.Modified;
            model.SaveChanges();
            return RedirectToAction("BlacklistReport");
        }
 
        public ActionResult ViewTrader(int? w,string word)
        {
            if (w==null)
            {
                ViewData["trader"] = model.Traders.ToList();
                ViewData["rating"] = model.traderRatings.ToList();
            }
            else
            {
                ViewData["trader"] = model.Traders.Where(x=>x.username.Contains(word)).ToList();
                ViewData["rating"] = model.traderRatings.ToList();
            }
            return View();
        }

        [HttpPost]
        public ActionResult viewTrader()
        {
            return ViewTrader(1,Request.Form["word"].ToString());
        }

        public ActionResult deleteTrader()
        {
            List<Trader> traders = model.Traders.ToList();
            return View(traders);
        }
        public ActionResult delete(int id)
        {
            Trader trader = (from Trader in model.Traders
                             where Trader.traderID.Equals(id)
                             select Trader).SingleOrDefault();

            model.Traders.Remove(trader);
            model.SaveChanges();
            return RedirectToAction("deleteTrader");
        }
    }
}
