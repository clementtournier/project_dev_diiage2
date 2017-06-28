﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesReservations.Models
{
    public class Ressourcem
    {
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut Nom_Ressource
        public string Nom_Ressource { get; set; }
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut Disponibilite
        public int Disponibilite { get; set; }
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut Description
        public string Description { get; set; }
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut Date_Achat
        public DateTime Date_Achat { get; set; }
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut QRCode
        public string QRCode { get; set; }
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut Purge
        public Boolean Purge { get; set; }
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut Nom_Genre
        public string Nom_Genre { get; set; }

        public Ressourcem()
        {

        }
        public Ressourcem(string n, int di, string de, DateTime da, string qcr, Boolean pu, string ng)
        {
            Nom_Ressource = n;
            Disponibilite = di;
            Description = de;
            Date_Achat = da;
            QRCode = qcr;
            Purge = pu;
            Nom_Genre = ng;
        }
    }
}
