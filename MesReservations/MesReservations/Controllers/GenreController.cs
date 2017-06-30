using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MesReservations.BL;
using MesReservations.MODEL;

namespace MesReservations.Controllers
{
    public class GenreController : ApiController
    {
        // On instancie un utilisateurBL pour utiliser les fonctions codées dedans
        private GenreBL BLgenre = new GenreBL();

        // GET: api/Users
        public List<GenreModel> Get()
        {
            // On appelle la fonction getUserAll de UtilisateurBL
            return BLgenre.getGenreAll();
        }

        // GET: api/Users/5
        public GenreModel Get(int id)
        {
            // On appelle la fonction getUserById de UtilisateurBL
            return BLgenre.getGenrebyId(id);
        }
    }
}
