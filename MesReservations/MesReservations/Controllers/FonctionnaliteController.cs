using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MesReservations.BL;
using MesReservations.MODEL;
using MesReservations.DAL;

namespace MesReservations.Controllers
{
    public class FonctionnaliteController : ApiController
    {
        // On instancie un utilisateurBL pour utiliser les fonctions codées dedans
        private FonctionnaliteBL BLfonctionnalite = new FonctionnaliteBL ();

        // GET: api/Users
        public List<FonctionnaliteModel> Get()
        {
            // On appelle la fonction getUserAll de UtilisateurBL
            return BLfonctionnalite.getFonctionnaliteAll();
        }

        // GET: api/Users/5
        public FonctionnaliteModel Get(int id)
        {
            // On appelle la fonction getUserById de UtilisateurBL
            return BLfonctionnalite.GetFonctionnalitebyId(id);
        }
    }

}
