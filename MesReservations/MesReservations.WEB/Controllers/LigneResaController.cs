using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MesReservations.DAL;
using MesReservations.Models;
using MesReservations.BL;
using MesReservations.MODEL;

namespace MesReservations.WEB.Controllers
{
    public class LigneResaController : Controller
    {
        private LigneResaBL BLligneresa = new LigneResaBL();

        // GET: LigneResa
        public ActionResult Index()
        {
            List<LigneResaModel> ligneresa = new List<LigneResaModel>();
            ligneresa = BLligneresa.getLigneResaAll();
            return View(ligneresa);
        }
    }
}