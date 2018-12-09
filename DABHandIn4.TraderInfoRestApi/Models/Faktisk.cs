using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DABHandIn4.TraderInfoRestApi.Models
{
    public partial class Faktisk
    {
        public int ProduceretkWh { get; set; }
        public int BrugtkWh { get; set; }
        public int Difference { get; set; }
    }
}
