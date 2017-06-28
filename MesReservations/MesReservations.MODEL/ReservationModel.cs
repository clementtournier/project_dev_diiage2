using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MesReservations.WEB.Models
{
    public class ReservationModel
    {
        public int id_Reservation { get; set; }

        public DateTime Date_Debut_Resa { get; set; }

        public DateTime Date_Fin_Resa { get; set; }

        public DateTime Date_Resa { get; set; }

        public Boolean Purge { get; set; }

        public int id_User { get; set; }

    }

    //public ReservationModel()
    //{

    //}

    //public ReservationModel(int id_Resa, DateTime ddr, DateTime dfr, DateTime)
    //{

    //}

}