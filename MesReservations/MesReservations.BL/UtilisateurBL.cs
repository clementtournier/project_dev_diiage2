using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MesReservations.DAL;
using MesReservations.Models;

namespace MesReservations.BL
{
    public class UtilisateurBL
    {
        private BDD_GRP2Entities db = new BDD_GRP2Entities();
        public List<Userm> getUserAll()
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
                Purge = (Boolean)u.Purge,
                ID_User = (int)u.ID_User
            });
            
            List<Userm> userAll = new List<Userm>();

            userAll = lesUtilisateurs.ToList();

            return userAll;
        }
        public Userm getUserbyId(int id)
        {

            var UtilisateurById = db.Utilisateur.Where(p => p.ID_User == id).Select(u => new Userm()
            {
                Nom_User = u.Nom_Utilisateur,
                Prenom = u.Prenom,
                Mail = u.Mail,
                Password = u.Password,
                Nom_Profil = db.Profil.Where(v => v.ID_Profil == u.ID_Profil).FirstOrDefault().Nom_Profil,
                Last_Login = (DateTime)u.Last_login,
                Deconnexion = (int)u.Deconnexion,
                Purge = (Boolean)u.Purge
            }).FirstOrDefault();
            return UtilisateurById;
        }
    }
}
