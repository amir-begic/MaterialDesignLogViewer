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
    
    public partial class Log
    {
        public long Id { get; set; }
        public long Device_fk { get; set; }
        public System.DateTime Timestamp { get; set; }
        public string LogMessage { get; set; }
        public string Level { get; set; }
        public Nullable<short> Is_acknowledged { get; set; }
    
        public virtual Device Device { get; set; }
    }
}
