using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MesReservations.DAL;
using MesReservations.BL;
using MesReservations.MODEL;

namespace MesReservations.Controllers
{
    public class ReservationController : ApiController
    {

        private ReservationBL BLresa = new ReservationBL();

        // GET: api/Reservation
        public List<ReservationModel> Get()
        {
            return BLresa.getResaAll();
        }

        // GET: api/Reservation/5
        public ReservationModel Get(int id)
        {
            return BLresa.getResaById(id);
        }


    }
}