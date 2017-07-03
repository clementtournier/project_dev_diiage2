﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MesReservations.DAL;
using MesReservations.BL;
using MesReservations.MODEL;
using System.Net;

namespace MesReservations.WEB.Controllers
{
    public class LigneResaController : Controller
    {
        private LigneResaBL BLligneresa = new LigneResaBL();

        // GET: LigneResa
        public ActionResult Index()
        {
            List<LigneResaModel> ligneresa = new List<LigneResaModel>();
            ligneresa = BLligneresa.getLigneResaNoPurge();
            return View(ligneresa);
        }

        // GET: LigneResa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneResaModel ligneResa = new LigneResaModel();
            ligneResa = BLligneresa.getLigneResaById((int)id);

            if (ligneResa == null)
            {
                return HttpNotFound();
            }
            return View(ligneResa);
        }

        // GET: LigneReservation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneResaModel ligneReservation = new LigneResaModel();
            ligneReservation = BLligneresa.getLigneResaById((int)id);
            if (ligneReservation == null)
            {
                return HttpNotFound();
            }
            return View(ligneReservation);
        }

        // POST: LigenReservation/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Ligne_Reservation,Date_Debut,Date_Fin,ID_Reservation,ID_Ressource,Purge")] LigneResaModel ligneReservation)
        {
            if (ModelState.IsValid)
            {
                BLligneresa.setEditLigneResa(ligneReservation.ID_Ligne_Reservation, ligneReservation.Date_Debut, ligneReservation.Date_Fin, ligneReservation.ID_Reservation, ligneReservation.ID_Ressource, ligneReservation.Purge);
            }
            return View(ligneReservation);
        }

        // GET: LigneResa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LigneResa/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateConfirmed([Bind(Include = "Date_Debut,Date_Fin,ID_Reservation,ID_Ressource")] LigneResaModel ligneResa)
        {
            if (ModelState.IsValid)
            {
                BLligneresa.setCreateLigneResa(ligneResa.Date_Debut, ligneResa.Date_Fin, ligneResa.ID_Reservation, ligneResa.ID_Ressource);
            }
            return RedirectToAction("Index");
        }

        // GET: LigneResa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneResaModel ligneResa = new LigneResaModel();
            ligneResa = BLligneresa.getLigneResaById((int)id);
            if (ligneResa == null)
            {
                return HttpNotFound();
            }
            return View(ligneResa);
        }

        // POST: ligneResa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                BLligneresa.setRemoveLigneResa(id);
            }
            return RedirectToAction("Index");

        }

    }


}