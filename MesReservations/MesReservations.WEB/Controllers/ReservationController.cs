using System;
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
    }
}