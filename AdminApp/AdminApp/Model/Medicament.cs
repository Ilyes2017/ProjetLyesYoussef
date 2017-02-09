using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Model
{
    class Medicament
    {
        public string Id { get; set; }
        public string nom { get; set; }
        public string utilisation { get; set; }
        public double prix { get; set; }
        public DateTime DateFabrication { get; set; }
        public DateTime Dateexpiration { get; set; }
        public String idPharmcie { get; set; }
    }
}
