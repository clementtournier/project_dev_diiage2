﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MesReservations.DAL;
using System.Data.Entity;
using MesReservations.MODEL;

namespace MesReservations.BL
{
    public class UtilisateurBL
    {
        private BDD_GRP2Entities db = new BDD_GRP2Entities();

        // Récupérer tous les users
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
                ID_User = (int)u.ID_User,
                ID_Profil = (int)u.ID_Profil
            });

            List<Userm> userAll = new List<Userm>();

            userAll = lesUtilisateurs.ToList();

            return userAll;
        }

        // Récupérer un utilisateur suivant son id
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
                Purge = (Boolean)u.Purge,
                ID_User = (int)u.ID_User,
                ID_Profil = (int)u.ID_Profil
            }).FirstOrDefault();

            return UtilisateurById;
        }

        // Récupérer les utilisateurs qui ont purge à True
        public List<Userm> getUserNoPurge()
        {
            var UtilisateurNoPurge = db.Utilisateur.Where(p => p.Purge == false).Select(u => new Userm()
            {
                Nom_User = u.Nom_Utilisateur,
                Prenom = u.Prenom,
                Mail = u.Mail,
                Password = u.Password,
                Nom_Profil = db.Profil.FirstOrDefault(v => v.ID_Profil == u.ID_Profil).Nom_Profil,
                Last_Login = (DateTime)u.Last_login,
                Deconnexion = (int)u.Deconnexion,
                Purge = (Boolean)u.Purge,
                ID_User = (int)u.ID_User,
                ID_Profil = (int)u.ID_Profil
            }).ToList();
            

            return UtilisateurNoPurge;
        }

        // Editer l'utilisateur
        public Userm setEditUser(string nom_user, string prenom, string mail, string password, DateTime last_login, int deconnexion, int id_user, string nom_profil, Boolean purge)
        {
            // On lie les réponses du formulaire d'édition qui seront en paramètres à un Utilisateur de la BDD
            Utilisateur utilisateur = new Utilisateur();
            utilisateur.Nom_Utilisateur = nom_user;
            utilisateur.Prenom = prenom;
            utilisateur.Mail = mail;
            utilisateur.Password = password;
            utilisateur.Last_login = last_login;
            utilisateur.Deconnexion = deconnexion;
            utilisateur.ID_User = id_user;
            utilisateur.ID_Profil = db.Profil.Where(v => v.Nom_Profil == nom_profil).FirstOrDefault().ID_Profil;
            utilisateur.Purge = purge;
            
            // Envoi de la modification des données de l'utilisateur dans la BDD
            db.Entry(utilisateur).State = EntityState.Modified;
            db.SaveChanges();

            // Création de l'utilisateur précédemment créé suivant le modèle
            Userm user = new Userm();
            user.Nom_User = utilisateur.Nom_Utilisateur;
            user.Prenom = utilisateur.Prenom;
            user.Mail = utilisateur.Mail;
            user.Password = utilisateur.Password;
            user.Last_Login = (DateTime)utilisateur.Last_login;
            user.Deconnexion = (int)utilisateur.Deconnexion;
            user.ID_User = (int)utilisateur.ID_User;
            user.Nom_Profil = db.Profil.Where(v => v.ID_Profil == utilisateur.ID_Profil).FirstOrDefault().Nom_Profil;
            user.Purge = (Boolean)utilisateur.Purge;
            return user;
        }

        public void setCreateUser(string nom_user, string prenom, string mail, string password, DateTime last_login, int deconnexion, string nom_profil)
        {
            // On lie les réponses du formulaire d'ajout qui seront en paramètres à un Utilisateur de la BDD
            Utilisateur utilisateur = new Utilisateur();
            utilisateur.Nom_Utilisateur = nom_user;
            utilisateur.Prenom = prenom;
            utilisateur.Mail = mail;
            utilisateur.Password = password;
            utilisateur.Last_login = last_login;
            utilisateur.Deconnexion = deconnexion;
            utilisateur.ID_Profil = db.Profil.Where(v => v.Nom_Profil == nom_profil).FirstOrDefault().ID_Profil;
            utilisateur.Purge = false;

            // On ajoute l'utilisateur
            db.Utilisateur.Add(utilisateur);
            db.SaveChanges();
        }

        public void setRemoveUser(int id_user)
        {
            // On récupère l'utilisateur suivant son id
            Utilisateur utilisateur = db.Utilisateur.FirstOrDefault(v => v.ID_User == id_user);

            // On passe l'élément "purge" à true
            utilisateur.Purge = true;

            // On applique ces changements
            db.Entry(utilisateur).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
