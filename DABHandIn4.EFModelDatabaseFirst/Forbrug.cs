//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DABHandIn4.EFModelDatabaseFirst
{
    using System;
    using System.Collections.Generic;
    
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
