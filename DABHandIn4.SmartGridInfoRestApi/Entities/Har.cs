//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.ComponentModel.DataAnnotations;

namespace DABHandIn4.SmartGridInfoRestApi.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Har
    {
        [Key]
        public long SmartEnhedId { get; set; }
        public long ElkildeId { get; set; }
        public int Antal { get; set; }
    
        public virtual Elkilde Elkilde { get; set; }
        public virtual SmartEnhed SmartEnhed { get; set; }
    }
}