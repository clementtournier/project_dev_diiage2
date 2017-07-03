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
    public class ProfilController : ApiController
    {
        // On instancie un profilBL pour utiliser les fonctions codées dedans
        private ProfilBL ProfilBL = new ProfilBL();

        // GET: api/Users
        public List<ProfilModel> Get()
        {
            // On appelle la fonction getProfilAll de ProfilBL
            return ProfilBL.getProfilAll();
        }

        // GET: api/Profil/5
        public ProfilModel Get(int id)
        {
            // On appelle la fonction getProfilById de ProfilBL
            return ProfilBL.getProfilbyId(id);
        }
    }
}