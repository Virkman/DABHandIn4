using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DABHandIn4.TraderInfoRestApi.Models
{
    public partial class HistorikOgAktuel
    {
        public string id { get; set; }
        public string Dato { get; set; }
        public string Tidsrum { get; set; }
        public Transaction[] Transaction { get; set; }
        
    }
}
