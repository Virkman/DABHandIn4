

namespace DABHandIn4.ProsumerInfoRestApi.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonAntal
    {
        public long PersonAntalId { get; set; }
        public int AntalVoksne { get; set; }
        public Nullable<long> ProsumerId { get; set; }
    
        public virtual Prosumer Prosumer { get; set; }
    }
}
