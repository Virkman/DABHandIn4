

namespace DABHandIn4.ProsumerInfoRestApi.Entities
{
    using System;
    
    public partial class Forbrug
    {
        public long ForbrugId { get; set; }
        public int AarligkWh { get; set; }
        public Nullable<int> Kvartal1kWh { get; set; }
        public Nullable<int> Kvartal2kWh { get; set; }
        public Nullable<int> Kvartal3kWh { get; set; }
        public Nullable<int> Kvartal4kWh { get; set; }
        public System.DateTime Aarstal { get; set; }
        public long ProsumerId { get; set; }
    
        public virtual Prosumer Prosumer { get; set; }
    }
}
