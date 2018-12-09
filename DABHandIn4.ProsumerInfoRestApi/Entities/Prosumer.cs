

namespace DABHandIn4.ProsumerInfoRestApi.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Prosumer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prosumer()
        {
            this.Forbrugs = new HashSet<Forbrug>();
            this.PersonAntals = new HashSet<PersonAntal>();
        }
    
        public long ProsumerId { get; set; }
        public long SmartEnhedId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Forbrug> Forbrugs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonAntal> PersonAntals { get; set; }
    }
}
