﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTableti.Models;

namespace WebTableti.Controllers

{
    public class HomeController : Controller
    {
        private readonly string connString = ConfigurationManager.ConnectionStrings["dbNautilusConnectionString"].ConnectionString;
        private SqlConnection conn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private dbNautilusEntities1 context = new dbNautilusEntities1();

        public ActionResult Index()
        {
            
                if (context.TUBLAInfo.OrderByDescending(x => x.datum).ToList() != null)
                {
                    using (context)
                        {
                            return View(context.TUBLAInfo.OrderByDescending(x => x.datum).ToList());
                        }
                        
                }
                
          return View();
   
        }

        //Grupa1
        public ActionResult About()
        {
            Podaci podaci = new Podaci();
            DataTable dtPodaci = podaci.NapuniGrid();

            string email = "grupa1.nautilus@tubla.local";

            ViewBag.Brojac2 = podaci.vratiSumuBrojac2(email);
            ViewBag.Brojac7 = podaci.vratiSumuBrojac7(email);
            ViewBag.Brojac8 = podaci.vratiSumuBrojac8(email);

            return View("About", dtPodaci);
        }

        //Grupa2
        public ActionResult About2()
        {
            Podaci podaci = new Podaci();
            DataTable dtPodaci = podaci.NapuniGrid2();

            string email = "grupa2.nautilus@tubla.local";

            ViewBag.Brojac2 = podaci.vratiSumuBrojac2(email);
            ViewBag.Brojac7 = podaci.vratiSumuBrojac7(email);
            ViewBag.Brojac8 = podaci.vratiSumuBrojac8(email);

            return View("About2", dtPodaci);
        }
           
     
        public ActionResult Details(int kod)
        {
            DataTable dtPovijest = new DataTable();
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                cmd = new SqlCommand("Select * from NF_Tracc_fermi_96ore where MachCode = @code order by DateRec desc", conn);
                cmd.Parameters.AddWithValue("@code", kod);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtPovijest);
            }

            ViewBag.Data = kod;

            return View("Details", dtPovijest);
        }

        //Grupa 1
        public ActionResult ChangeStatus(string kod)
        {
            using (var context = new dbNautilusEntities1())
            {
                if (context.TUBLAFermi.Any(o => o.UniqueID == kod))
                {
                    var status = context.TUBLAFermi.OrderBy(a => a.ID).LastOrDefault(a => a.UniqueID == kod);
                    status.Status = true;
                    context.SaveChanges();
                }
                else
                {
                    var Stato = new TUBLAFermi()
                    {
                        UniqueID = kod,
                        Status = true
                    };
                    context.TUBLAFermi.Add(Stato);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("About", "Home");
        }

        //Grupa 2
        public ActionResult ChangeStatus2(string kod)
        {
            using (var context = new dbNautilusEntities1())
            {
                if (context.TUBLAFermi.Any(o => o.UniqueID == kod))
                {
                    var status = context.TUBLAFermi.OrderBy(a => a.ID).LastOrDefault(a => a.UniqueID == kod);
                    status.Status = true;
                    context.SaveChanges();
                }
                else
                {
                    var Stato = new TUBLAFermi()
                    {
                        UniqueID = kod,
                        Status = true
                    };
                    context.TUBLAFermi.Add(Stato);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("About2", "Home");
        }

        //Grupa 1
        public ActionResult OdbaciStatus(string kod) {
            using (var context = new dbNautilusEntities1())
            {
                var status = context.TUBLAFermi.Where(a => a.UniqueID == kod)
                                               .OrderByDescending(p => p.ID)
                                               .FirstOrDefault();
                context.TUBLAFermi.Remove(status);
                context.SaveChanges();
            }

            return RedirectToAction("About", "Home");
        }

        //Grupa 2
        public ActionResult OdbaciStatus2(string kod)
        {
            using (var context = new dbNautilusEntities1())
            {
                var status = context.TUBLAFermi.Where(a => a.UniqueID == kod).OrderByDescending(p => p.ID).FirstOrDefault();
                context.TUBLAFermi.Remove(status);
                context.SaveChanges();
            }

            return RedirectToAction("About2", "Home");
        }



        //[HttpPost]
        //public ActionResult Login(string username, string password)
        //{
        //    if (username.Equals("acc1") && password.Equals("123"))
        //    {
        //        Session["username"] = "username";
        //        return View("Index");
        //    }
        //    else
        //    {
        //        ViewBag.error = "Invalid Account";
        //        return View("Login");
        //    }
        //}

        //[HttpGet]
        //public ActionResult Logout()
        //{
        //    Session.Remove("username");
        //    return RedirectToAction("Index");
        //}
    }
}