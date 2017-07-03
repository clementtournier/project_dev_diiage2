using MesReservations.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MesReservations.Controllers
{
    public class HomeController : Controller
    {
        private BDD_GRP2Entities db = new BDD_GRP2Entities();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
