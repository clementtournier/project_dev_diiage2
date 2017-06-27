using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MesReservations.WEB.Models
{
    public class Userm
    {
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut Nom
        public string Nom { get; set; }
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut Prenom
        public string Prenom { get; set; }
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut Mail
        public string Mail { get; set; }
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut Password
        public string Password { get; set; }
        //définition public du getter permettant d'acceder aux données et du setter permettant de modifier les données pour l'attribut User_ID
        public int User_ID { get; set; }
        //définition public du getter permettant d'acceder au données et du setter permettant de modifier les données pour l'attribut Last_Login
        public DateTime Last_Login { get; set; }
        //définition public du getter permettant d'acceder au données et du setter permettant de modifier les données pour l'attribut Déconnexion
        public int Deconnexion { get; set; }
        //Constructeur Vide qui permet l'utilisation du model sans utiliser tous les attributs
        public Userm()
        {

        }
        //Contructeur par défaut avec tout les attributs
        public Userm(string n, string pr, string m, string pa, int uid, DateTime ll, int d)
        {
            Nom = n;
            Prenom = pr;
            Mail = m;
            Password = pa;
            User_ID = uid;
            Last_Login = ll;
            Deconnexion = d;
        }
    }
}