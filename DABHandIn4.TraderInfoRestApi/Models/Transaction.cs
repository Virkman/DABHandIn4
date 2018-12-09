using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DABHandIn4.TraderInfoRestApi.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int ProsumerId { get; set; }
        public Forventet Forventet { get; set; }
        public Faktisk Faktisk { get; set; }     
    }
}
