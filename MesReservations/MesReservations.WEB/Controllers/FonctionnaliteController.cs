using MesReservations.BL;
using MesReservations.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MesReservations.WEB.Controllers
{
    public class FonctionnaliteController : Controller
    {
        // On instancie un GenreBL pour utiliser les fonctions codées dedans
        private FonctionnaliteBL BLfonctionnalite = new FonctionnaliteBL();

        // GET: Genre
        public ActionResult Index()
        {
            List<FonctionnaliteModel> fonctionnalite = new List<FonctionnaliteModel>();
            fonctionnalite = BLfonctionnalite.getFonctionnaliteAll();
            return View(fonctionnalite);
        }
        // GET: Genre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FonctionnaliteModel fonctionnalite = new FonctionnaliteModel();
            fonctionnalite = BLfonctionnalite.GetFonctionnalitebyId((int)id);

            if (fonctionnalite == null)
            {
                return HttpNotFound();
            }
            return View(fonctionnalite);
        }
        // GET: Utilisateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FonctionnaliteModel fonctionnalite = new FonctionnaliteModel();
            fonctionnalite = BLfonctionnalite.GetFonctionnalitebyId((int)id);
            if (fonctionnalite == null)
            {
                return HttpNotFound();
            }
            return View(fonctionnalite);
        }
    }
}