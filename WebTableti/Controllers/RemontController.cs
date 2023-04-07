using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTableti.Controllers
{
    public class RemontController : Controller
    {
        private readonly string connString = ConfigurationManager.ConnectionStrings["dbNautilusConnectionString"].ConnectionString;
        private dbNautilusEntities1 context = new dbNautilusEntities1();


        // GET: Remont
        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                return View();
            }

            return RedirectToAction("Login");
            //return View(context.TUBLAInfo.ToList());
        }

        public ActionResult DodajRemont()
        {
            if (Session["User"] != null)
            {
                return View();
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult DodajRemont(RemontMach tremont)
        {
            if (Session["User"] != null)
            {
                int brojMasine = Convert.ToInt32(tremont.MachCode);

                if (brojMasine < 1)
                {
                    TempData["ErrorMachCode"] = "Ne postoji mašina sa brojem " + brojMasine + "!";
                    return RedirectToAction("DodajRemont");
                }

                var id_machine = context.MACHINES_SETUP.Where(a => a.MachCode == tremont.MachCode).FirstOrDefault();

                using (var context = new dbNautilusEntities1())
                {
                    if (id_machine != null)
                    {
                        var remont = new RemontMach()
                        {
                            DatumOd = DateTime.Now,
                            Opis = tremont.Opis,
                            MachCode = tremont.MachCode,
                            MachineId = id_machine.MachineId,
                            Korisnik = Session["User"].ToString()
                        };

                        context.RemontMach.Add(remont);
                        context.SaveChanges();

                        TempData["Uspjeh"] = "Dodan je novi remont za mašinu " + id_machine.MachCode + ".";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Ne postoji mašina sa brojem " + tremont.MachCode + "!";
                        return RedirectToAction("DodajRemont");
                    }
                }

                return View();
            }

            return RedirectToAction("Login");

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

            if ((user == "admin" && pass == "admin") || (user == "mehanicar1" || pass == "mehanicar1"))
            {
                Session["User"] = user;
                Session["Password"] = pass;

                return RedirectToAction("Index");
            }
            

             @TempData["ErrorMessage"] = "Krivi username ili password!";
             return RedirectToAction("Login");                     
                        
        }

        public ActionResult PregledRemonta()
        {
            return View();
        }

    }
}