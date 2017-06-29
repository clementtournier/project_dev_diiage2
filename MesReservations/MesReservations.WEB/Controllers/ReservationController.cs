﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MesReservations.DAL;
using MesReservations.Models;
using MesReservations.BL;

namespace MesReservations.WEB.Controllers
{
    public class ReservationController : Controller
    {
        private ReservationBL BLresa = new ReservationBL();

        // GET: Reservation
        public ActionResult Index()
        {
            List<ReservationModel> reservation = new List<ReservationModel>();
            reservation = BLresa.getResaAll();
            return View(reservation);

        }

        // GET: Reservation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservation = new ReservationModel();
            reservation = BLresa.getResaById((int)id);



            if (reservation.id_Reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservation = new ReservationModel();
            reservation = BLresa.getResaById((int)id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservation/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Reservation,Date_Debut_Resa,Date_Fin_Resa,Date_Resa,Nom_User,Purge")] ReservationModel reservation)
        {
            if (ModelState.IsValid)
            {
                BLresa.setEditResa(reservation.id_Reservation, reservation.Date_Debut_Resa, reservation.Date_Fin_Resa, reservation.Date_Resa, reservation.Nom_User, reservation.Purge);
            }
            return View(reservation);
        }

        //// GET: Utilisateurs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
            
        //    if (reservation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(utilisateur);
        //}

        //// POST: Utilisateurs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Utilisateur utilisateur = db.Utilisateur.Find(id);
        //    utilisateur.Purge = true;
        //    db.Entry(utilisateur).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}