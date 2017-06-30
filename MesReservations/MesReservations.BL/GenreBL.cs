using MesReservations.DAL;
using MesReservations.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesReservations.BL
{
    public class GenreBL

    {
        private BDD_GRP2Entities db = new BDD_GRP2Entities();

        // Récupérer tous les users
        public List<GenreModel> getGenreAll()
        {
            var lesGenres = db.Genre.Select(u => new GenreModel()
            {
                id_genre = u.ID_Genre,
                nom_genre = u.Nom_Genre,
                description = u.Description,
                purge = (Boolean)u.Purge
            });

            List<GenreModel> GenreAll = new List<GenreModel>();

            GenreAll = lesGenres.ToList();

            return GenreAll;
        }
        public GenreModel getGenrebyId(int id)
        {
            var GenreById = db.Genre.Where(p => p.ID_Genre == id).Select(u => new GenreModel()
            {
                id_genre = u.ID_Genre,
                nom_genre = u.Nom_Genre,
                description = u.Description,
                purge = (Boolean)u.Purge
            }).FirstOrDefault();

            return GenreById;
        }
    }
}
