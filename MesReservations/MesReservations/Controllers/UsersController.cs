using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MesReservations.DAL;
using MesReservations.Models;

namespace MesReservations.Controllers
{
    public class UsersController : ApiController
    {
        private BDD_GRP2Entities db = new BDD_GRP2Entities();
        // GET: api/Users
        public IQueryable<Userm> Get()
        {

            var lesUtilisateurs= db.UTILISATEUR.Select(f => new Userm()
            {
                Nom = f.Nom,
               Prenom = f.Prenom,
                Mail = f.Mail,
                Password= f.Password,
                User_ID = f.ID_User,
                Last_Login= (DateTime)f.Last_login,
                Deconnexion= (int)f.Deconnexion
            });

            return lesUtilisateurs;
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
