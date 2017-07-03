using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MesReservations.MODEL;
using MesReservations.BL;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
namespace MesReservations.WEB.Controllers
{
    public class AuthentificationController : Controller
    {
        private UtilisateurBL BLuser = new UtilisateurBL();
        // GET: Authentification
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Mail,Password")] Userm utilisateur)
        {

            Userm utilisateurverif = new Userm();
            utilisateurverif = BLuser.getTestConnexion(utilisateur.Mail, utilisateur.Password);
            if(String.IsNullOrEmpty(utilisateurverif.Mail))
            {

            }
            else
            {
                if((utilisateur.Mail == utilisateurverif.Mail) && (utilisateur.Password == utilisateurverif.Password))
                {
                    return RedirectToAction("/../Home/Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
