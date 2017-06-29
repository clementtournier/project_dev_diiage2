using MesReservations.DAL;
using MesReservations.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesReservations.BL
{
    public class LigneResaBL
    {

        private BDD_GRP2Entities db = new BDD_GRP2Entities();

        public List<LigneResaModel> getLigneResaAll()
        {
            var lesLigneResas = db.Ligne_Reservation.Select(l => new LigneResaModel()
            {
                ID_Ligne_Reservation = l.ID_Ligne_Reservation,
                Date_Debut = (DateTime)l.Date_Debut,
                Date_Fin = (DateTime)l.Date_Fin,
                ID_Reservation = l.ID_Reservation,
                ID_Ressource = l.ID_Ressource

            });

            List<LigneResaModel> LigneResaAll = new List<LigneResaModel>();

            LigneResaAll = lesLigneResas.ToList();

            return LigneResaAll;
        }

        public LigneResaModel getLigneResaById(int id_ligneResa)
        {
            var LigneResaById = db.Ligne_Reservation.Where(l => l.ID_Ligne_Reservation == id_ligneResa).Select(l => new LigneResaModel()
            {
                ID_Ligne_Reservation = l.ID_Ligne_Reservation,
                Date_Debut = (DateTime)l.Date_Debut,
                Date_Fin = (DateTime)l.Date_Fin,
                ID_Reservation = l.ID_Reservation,
                ID_Ressource = l.ID_Ressource

            }).FirstOrDefault();

            return LigneResaById;

        }

    }
}
