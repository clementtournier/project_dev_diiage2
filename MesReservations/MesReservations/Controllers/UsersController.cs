using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MesReservations.DAL;
using MesReservations.Models;
using MesReservations.BL;

namespace MesReservations.Controllers
{
    public class UsersController : ApiController
    {
        private UtilisateurBL BLuser = new UtilisateurBL();

        //private BDD_GRP2Entities db = new BDD_GRP2Entities();
        // GET: api/Users
        public List<Userm> Get()
        {
            return BLuser.getUserAll();
        }

        // GET: api/Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }


    }
}
