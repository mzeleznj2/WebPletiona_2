using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebTableti.Models
{
    public class Podaci
    {
        string connString = ConfigurationManager.ConnectionStrings["dbNautilusConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        List<PodaciDetalji> DetaljiPodataka = new List<PodaciDetalji>();

        public DataTable NapuniGrid()
        {
            DataTable dtPodaci = new DataTable();
            using (conn = new SqlConnection(connString))
            {
                string email = "grupa1.nautilus@tubla.local";
                conn.Open();
                cmd = new SqlCommand("Select * from NF_Tracc_fermi_Grupa33 where Email=@email and LastStopCode in (50002,50007,50008) order by Email, DateRec desc", conn);
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtPodaci);
            }        
           
            return dtPodaci;
        }

      
        public DataTable NapuniGrid2()
        {
            DataTable dtPodaci = new DataTable();
            using (conn = new SqlConnection(connString))
            {
                string email = "grupa2.nautilus@tubla.local";
                conn.Open();
                cmd = new SqlCommand("Select * from NF_Tracc_fermi_Grupa33 where Email=@email and LastStopCode in (50002,50007,50008) order by Email, DateRec desc", conn);
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtPodaci);
            }

            return dtPodaci;
        }


        public DataTable NapuniGrid3()
        {
            DataTable dtPodaci = new DataTable();
            using (conn = new SqlConnection(connString))
            {
                string email = "grupa3.nautilus@tubla.local";
                conn.Open();
                cmd = new SqlCommand("Select * from NF_Tracc_fermi_Grupa33 where Email=@email and LastStopCode in (50002,50007,50008) order by Email, DateRec desc", conn);
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtPodaci);
            }

            return dtPodaci;
        }

        //public DataTable NapuniGrupu3()
        //{
        //    DataTable dtPodaci = new DataTable();
        //    using (conn = new SqlConnection(connString))
        //    {
        //        conn.Open();
        //        cmd = new SqlCommand("select * from NF_Tracc_fermi_Grupa33 where StopCode in (50002,50007,50008)", conn);
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(dtPodaci);
        //    }          

        //    return dtPodaci;
        //}

        public int vratiSumuBrojac2(string email)
        {
            int brojac;
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                cmd = new SqlCommand("select count(*) from NF_Tracc_fermi_Grupa3 where LastStopCode = 50002 and Email=@email", conn);
                cmd.Parameters.AddWithValue("@email", email);

                brojac = (int)cmd.ExecuteScalar();
            }
            return brojac;
        }

        public int vratiSumuBrojac7(string email)
        {
            int brojac;
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                cmd = new SqlCommand("select count(*) from NF_Tracc_fermi_Grupa3 where LastStopCode = 50007 and Email=@email", conn);
                cmd.Parameters.AddWithValue("@email", email);

                brojac = (int)cmd.ExecuteScalar();
            }
            return brojac;
        }

        public int vratiSumuBrojac8(string email)
        {
            int brojac;
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                cmd = new SqlCommand("select count(*) from NF_Tracc_fermi_Grupa3 where LastStopCode = 50008 and Email=@email", conn);
                cmd.Parameters.AddWithValue("@email", email);

                brojac = (int)cmd.ExecuteScalar();
            }
            return brojac;
        }


        // Brojač na drugi način

        public DataTable brojacGrupa1()
        {
            DataTable dtPodaciBrojac = new DataTable();
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                cmd = new SqlCommand("select LastStopCode, count(LastStopCode) as Brojac " +
                    "from NF_Tracc_fermi_Grupa33 where Email='grupa1.nautilus@tubla.local' group by LastStopCode", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtPodaciBrojac);
            }
            
            return dtPodaciBrojac;
        }

        public DataTable brojacGrupa2()
        {
            DataTable dtPodaciBrojac = new DataTable();
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                cmd = new SqlCommand("select LastStopCode, count(LastStopCode) as Brojac " +
                    "from NF_Tracc_fermi_Grupa33 where Email='grupa2.nautilus@tubla.local' group by LastStopCode", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtPodaciBrojac);
            }

            return dtPodaciBrojac;
        }


        public DataTable brojacGrupa3()
        {
            DataTable dtPodaciBrojac = new DataTable();
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                cmd = new SqlCommand("select LastStopCode, count(LastStopCode) as Brojac " +
                    "from NF_Tracc_fermi_Grupa33 where Email='grupa3.nautilus@tubla.local' group by LastStopCode", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtPodaciBrojac);
            }

            return dtPodaciBrojac;
        }

        //



    }

}