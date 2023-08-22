using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameTradeTopia.Models;

namespace GameTradeTopia.Controllers
{
    public class HomeController : Controller
    {
        private Models.GameTradeTopia model = new Models.GameTradeTopia();
        // GET: Home
        public ActionResult Index(int? id)
        {
            List<Game> games=null;
            if (id == 1)
            {
                games = model.Games.Where(x=>x.gameType.Equals("Action")).ToList();
            }
            else if (id == 2)
            {
                games = model.Games.Where(x => x.gameType.Equals("Adventure")).ToList();
            }
            else if (id == 3)
            {
                games = model.Games.Where(x => x.gameType.Equals("Racing")).ToList();
            }
            else if (id == 4)
            {
                games = model.Games.Where(x => x.gameType.Equals("Arcade")).ToList();
            }
            else if (id == 5)
            {
                games = model.Games.Where(x => x.gameType.Equals("Sports")).ToList();
            }
            else
            {
                 games = model.Games.ToList();
            }
            return View(games);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
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

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
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

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
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
