using MesReservations.DAL;
using MesReservations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesReservations.BL
{
    public class ReservationBL
    {
        private BDD_GRP2Entities db = new BDD_GRP2Entities();

        public List<ReservationModel> getResaAll()
        {
            var lesReservations = db.Reservation.Select(r => new ReservationModel()
            {
                id_Reservation = r.ID_Reservation,
                Date_Debut_Resa = (DateTime)r.Date_Debut_Reservation,
                Date_Fin_Resa = (DateTime)r.Date_Fin_Reservation,
                Date_Resa = (DateTime)r.Date_Reservation,
                Nom_User = db.Utilisateur.Where(v => v.ID_User == r.ID_User).FirstOrDefault().Nom_Utilisateur

            });

            List<ReservationModel> resaAll = new List<ReservationModel>();

            resaAll = lesReservations.ToList();

            return resaAll;
        }

        public ReservationModel getResaById(int id_res)
        {
            var ResaById = db.Reservation.Where(r => r.ID_Reservation == id_res).Select(r => new ReservationModel()
            {
                id_Reservation = r.ID_Reservation,
                Date_Debut_Resa = (DateTime)r.Date_Debut_Reservation,
                Date_Fin_Resa = (DateTime)r.Date_Fin_Reservation,
                Date_Resa = (DateTime)r.Date_Reservation,
                Nom_User = db.Utilisateur.Where(v => v.ID_User == r.ID_User).FirstOrDefault().Nom_Utilisateur

            }).FirstOrDefault();

            return ResaById;

        }


    }
}
