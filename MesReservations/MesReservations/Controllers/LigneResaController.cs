using MesReservations.BL;
using MesReservations.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MesReservations.Controllers
{
    public class LigneResaController : ApiController
    {

        private LigneResaBL BLresa = new LigneResaBL();

        // GET: api/Reservation
        public List<LigneResaModel> Get()
        {
            return BLresa.getLigneResaAll();
        }

        // GET: api/Reservation/5
        public LigneResaModel Get(int id)
        {
            return BLresa.getLigneResaById(id);
        }

    }
}