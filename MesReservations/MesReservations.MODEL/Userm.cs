﻿using System;

namespace MesReservations.MODEL
{
    public class Userm
    {
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut Nom_User
        public string Nom_User{ get; set; }
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut Prenom
        public string Prenom { get; set; }
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut Mail
        public string Mail { get; set; }
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut Password
        public string Password { get; set; }
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut Nom_Profil
        public string Nom_Profil { get; set; }
        //définition public du getter permettant d'acceder au données et du setter permettant de modifier les données pour l'attribut Last_Login
        public DateTime Last_Login { get; set; }
        //définition public du getter permettant d'acceder au données et du setter permettant de modifier les données pour l'attribut Déconnexion
        public int Deconnexion { get; set; }
        //définition public du getter permettant d'acceder au données et du setter permettant de modifier les données pour l'attribut Purge
        public Boolean Purge { get; set; }
        //définition public du getter permettant d'acceder au données et du setter permettant de modifier les données pour l'attribut ID_User
        public int ID_User { get; set; }
        public int ID_Profil { get; set; }
        
        //Constructeur Vide qui permet l'utilisation du model sans utiliser les attributs
        public Userm()
        {

        }
        //Contructeur par défaut avec tous les attributs
        public Userm(string n, string pr, string m, string pa, string np,DateTime ll, int d,Boolean pu, int uid,int pid)
        {
            Nom_User = n;
            Prenom = pr;
            Mail = m;
            Password = pa;
            Nom_Profil = np;
            Last_Login = ll;
            Deconnexion = d;
            Purge = pu;
            ID_User = uid;
            ID_Profil = pid;
        }
    }
}