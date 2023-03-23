using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTableti.Controllers
{
    public class RemontController : Controller
    {
        // GET: Remont
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DodajRemont()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logiranje(string username, string password)
        {
            string user = "";
            string pass = "";

            user = username;
            pass = password;

            Response.Write("Imena " + user + " " + pass);

            if (user != "admin"  || pass != "admin")
            {
                @TempData["ErrorMessage"] = "Krivi username ili password!";
                return RedirectToAction("Login");
            }
         


            Session["User"] = user;
            Session["Password"] = pass;

            return RedirectToAction("Index");
        }

        public ActionResult PregledRemonta()
        {
            return View();
        }

    }
}