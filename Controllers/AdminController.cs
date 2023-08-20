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
            trader.approved  = "yes";
            model.Entry(trader).State = System.Data.Entity.EntityState.Modified;
            model.SaveChanges();
            return RedirectToAction("ApproveRegistration");
        }

         public ActionResult decline(int id)
        {
            Trader trader = (from Trader in model.Traders
                                          where Trader.traderID.Equals(id)
                                          select Trader).SingleOrDefault();
            trader.approved  = "no";
            model.Entry(trader).State = System.Data.Entity.EntityState.Modified;
            model.SaveChanges();
            return RedirectToAction("ApproveRegistration");
        }
       
        public ActionResult Blacklist(int? id)
        {
            if (id == 1)
            {
                List<traderRating> list=model.traderRatings.Where(x=>x.traderStars<=3).ToList();
                List<Trader> list2 = model.Traders.ToList();
                List<Trader> list3=new List<Trader>();
                foreach (traderRating traderRating in list)
                {
                    foreach (Trader trader in list2)
                    {
                        if (traderRating.traderID.Equals(trader.traderID)) { list3.Add(trader); }
                    }
                }
                ViewData["trader"]=list3;
            }
            else if (id == 2)
            {
                List<Trade> list = model.Trades.Where(x => ( DateTime.Parse(x.Date).CompareTo(DateTime.Now) < 0)).ToList();
                List<Trader> list2 = model.Traders.ToList();
                List<Trader> list3 = new List<Trader>();
                foreach (Trade trade in list)
                {
                    foreach (Trader trader in list2)
                    {
                        if (trade.traderID.Equals(trader.traderID)) { list3.Add(trader); }
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

        public ActionResult Blacklist3()
        {
            ViewData["trader"] = model.Traders.ToList();
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

        public ActionResult ViewTraders()
        {
            ViewData["trader"] = model.Traders.ToList();
            ViewData["rating"] = model.traderRatings.ToList();
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
