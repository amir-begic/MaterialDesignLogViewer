//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonitoringClient.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Accounting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Accounting()
        {
            this.Productgroups = new HashSet<Productgroup>();
            this.SoftwareServices = new HashSet<SoftwareService>();
        }
    
        public long Id { get; set; }
        public string CustomerAccountNumber_FK { get; set; }
        public long Location_FK { get; set; }
        public long Device_FK { get; set; }
        public long Interface_FK { get; set; }
    
        public virtual CustomerAccount CustomerAccount { get; set; }
        public virtual Location Location { get; set; }
        public virtual Device Device { get; set; }
        public virtual Interface Interface { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Productgroup> Productgroups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoftwareService> SoftwareServices { get; set; }
    }
}
