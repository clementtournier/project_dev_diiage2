using MesReservations.DAL;
using MesReservations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MesReservations.Controllers
{
    public class RessourceController : ApiController
    {
        private BDD_GRP2Entities db = new BDD_GRP2Entities();
        // GET: api/Ressource
        public IQueryable<Ressourcem> Get()
        {
            var lesRessources = db.Ressource.Select(r => new Ressourcem()
            {
                Nom_Ressource = r.Nom_Ressource,
                Disponibilite = (int)r.Disponibilite,
                Description = r.Description,
                Date_Achat = (DateTime)r.Date_Achat,
                QRCode = r.QRCode,
                Purge = (Boolean)r.Purge,
                Nom_Genre = db.Genre.Where(v => v.ID_Genre == r.ID_Genre).FirstOrDefault().Nom_Genre
            });

            return lesRessources;
        }

        // GET: api/Ressource/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ressource
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Ressource/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ressource/5
        public void Delete(int id)
        {
        }
    }
}
