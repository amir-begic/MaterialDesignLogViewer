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
    
    public partial class LogEntry
    {
        public long Id { get; set; }
        public string Pod { get; set; }
        public string Location { get; set; }
        public string Hostname { get; set; }
        public Nullable<int> Severity { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
        public string Message { get; set; }
    }
}
