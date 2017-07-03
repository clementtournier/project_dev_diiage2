﻿using MesReservations.DAL;
using MesReservations.MODEL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public List<LigneResaModel> getLigneResaNoPurge()
        {
            var LigneResaNoPurge = db.Ligne_Reservation.Where(y => y.Purge == false).Select(l => new LigneResaModel()
            {
                ID_Ligne_Reservation = l.ID_Ligne_Reservation,
                Date_Debut = (DateTime)l.Date_Debut,
                Date_Fin = (DateTime)l.Date_Fin,
                ID_Reservation = l.ID_Reservation,
                ID_Ressource = l.ID_Ressource

            }).ToList();

            return LigneResaNoPurge;
        }

        // Editer la ligne de reservation
        public LigneResaModel setEditLigneResa(int id_Ligne_Resa, DateTime date_debut, DateTime date_fin, int  id_ressource, int id_reservation, Boolean purge)
        {
            // On lie les réponses du formulaire d'édition qui seront en paramètres à une ligne de reservation de la BDD
            Ligne_Reservation ligneReservation = new Ligne_Reservation();
            ligneReservation.ID_Ligne_Reservation = id_Ligne_Resa;
            ligneReservation.Date_Debut = date_debut;
            ligneReservation.Date_Fin = date_fin;
            ligneReservation.ID_Reservation = id_reservation;
            ligneReservation.ID_Ressource = id_ressource;
            ligneReservation.Purge = purge;
            
            // Envoi de le la ligne de reservation dans la BDD
            db.Entry(ligneReservation).State = EntityState.Modified;
            db.SaveChanges();

            // Création de l'utilisateur précédemment créé suivant le modèle
            LigneResaModel ligneResa = new LigneResaModel();
            ligneResa.ID_Ligne_Reservation = ligneReservation.ID_Ligne_Reservation;
            ligneResa.Date_Debut = (DateTime)ligneReservation.Date_Debut;
            ligneResa.Date_Fin = (DateTime)ligneReservation.Date_Fin;
            ligneResa.ID_Reservation = ligneReservation.ID_Reservation;
            ligneResa.ID_Ressource = ligneReservation.ID_Ressource;
            ligneResa.Purge = (Boolean)ligneReservation.Purge;
            return ligneResa;
        }

        public void setCreateLigneResa(DateTime date_debut, DateTime date_fin, int id_ressource, int id_reservation)
        {
            // On lie les réponses du formulaire d'ajout qui seront en paramètres à un Utilisateur de la BDD
            Ligne_Reservation ligneResa = new Ligne_Reservation();
            ligneResa.Date_Debut = date_debut;
            ligneResa.Date_Fin = date_fin;
            ligneResa.ID_Reservation = id_reservation;
            ligneResa.ID_Ressource = id_ressource; 
            ligneResa.Purge = false;

            // On ajoute l'utilisateur
            db.Ligne_Reservation.Add(ligneResa);
            db.SaveChanges();
        }

        public void setRemoveLigneResa(int id_ligneResa)
        {
            // On récupère la ligne resa suivant son id
            Ligne_Reservation ligneResa = db.Ligne_Reservation.FirstOrDefault(l => l.ID_Ligne_Reservation == id_ligneResa);

            // On passe l'élément "purge" à true
            ligneResa.Purge = true;

            // On applique ces changements
            db.Entry(ligneResa).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
