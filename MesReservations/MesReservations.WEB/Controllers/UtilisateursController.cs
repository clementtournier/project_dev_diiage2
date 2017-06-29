using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MesReservations.DAL;
using MesReservations.Models;
using MesReservations.BL;
namespace MesReservations.WEB.Controllers
{
    public class UtilisateursController : Controller
    {
        // On instancie un utilisateurBL pour utiliser les fonctions codées dedans
        private UtilisateurBL BLuser = new UtilisateurBL();

        // GET: Utilisateurs
        public ActionResult Index()
        {
            List<Userm> utilisateur = new List<Userm>();
            utilisateur = BLuser.getUserAll();
            return View(utilisateur);
        }
        // GET: Utilisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userm utilisateur = new Userm();
            utilisateur = BLuser.getUserbyId((int)id);
          
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilisateurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateConfirmed([Bind(Include = "Nom_User,Prenom,Mail,Password,Last_login,Deconnexion,Nom_Profil")] Userm utilisateur)
        {
            if (ModelState.IsValid)
            {
                BLuser.setCreateUser(utilisateur.Nom_User, utilisateur.Prenom, utilisateur.Mail, utilisateur.Password, utilisateur.Last_Login, utilisateur.Deconnexion, utilisateur.Nom_Profil);
            }
            return RedirectToAction("Index");
        }

        // GET: Utilisateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userm utilisateur = new Userm();
            utilisateur = BLuser.getUserbyId((int)id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nom_User,Prenom,Mail,Password,Last_Login,Deconnexion,ID_User,Nom_Profil,Purge")] Userm utilisateur)
        {
            if (ModelState.IsValid)
            {
                BLuser.setEditUser(utilisateur.Nom_User, utilisateur.Prenom, utilisateur.Mail, utilisateur.Password, utilisateur.Last_Login, utilisateur.Deconnexion,utilisateur.ID_User,utilisateur.Nom_Profil,utilisateur.Purge);
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userm utilisateur = new Userm();
            utilisateur = BLuser.getUserbyId((int)id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                BLuser.setRemoveUser(id);
            }
            return RedirectToAction("Index");
            
        }
    }
}
