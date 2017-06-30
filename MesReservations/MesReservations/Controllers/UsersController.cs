using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MesReservations.Models;
using MesReservations.BL;

namespace MesReservations.Controllers
{
    public class UsersController : ApiController
    {
        // On instancie un utilisateurBL pour utiliser les fonctions codées dedans
        private UtilisateurBL BLuser = new UtilisateurBL();

        // GET: api/Users
        public List<Userm> Get()
        {
            // On appelle la fonction getUserAll de UtilisateurBL
            return BLuser.getUserAll();
        }

        // GET: api/Users/5
        public Userm Get(int id)
        {
            // On appelle la fonction getUserById de UtilisateurBL
            return BLuser.getUserbyId(id);
        }
        
    }
}
