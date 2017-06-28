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

            var lesUtilisateurs = db.Utilisateur.Select(u => new Userm()
            {
                Nom_User = u.Nom_Utilisateur,
                Prenom = u.Prenom,
                Mail = u.Mail,
                Password = u.Password,
                Nom_Profil = db.Profil.Where(v => v.ID_Profil == u.ID_Profil).FirstOrDefault().Nom_Profil,
                Last_Login = (DateTime)u.Last_login,
                Deconnexion = (int)u.Deconnexion,
                Purge = (Boolean)u.Purge
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
