using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTableti.Models
{
    public class PodaciDetalji
    {
        public DateTime datum { get; set; }
        public int kodMasine { get; set; }
        public int stopKod { get; set; }
        public string poruka { get; set; }
        public string User { get; set; }
    }
}