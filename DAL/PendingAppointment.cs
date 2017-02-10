//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PendingAppointment
    {
        public PendingAppointment()
        {
            this.ApprovedAppointments = new HashSet<ApprovedAppointment>();
        }
    
        public int appID { get; set; }
        public string patientID { get; set; }
        public string appTime { get; set; }
        public string appDate { get; set; }
        public string appType { get; set; }
        public string Reason { get; set; }
        public int ProviderID { get; set; }
        public string Status { get; set; }
        public string Feedback { get; set; }
        public Nullable<int> clusterID { get; set; }
    
        public virtual DoctorRoom DoctorRoom { get; set; }
        public virtual ICollection<ApprovedAppointment> ApprovedAppointments { get; set; }
    }
}
