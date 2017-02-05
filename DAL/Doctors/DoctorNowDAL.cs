using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Doctors
{
    public  class DoctorNowDAL
    {

        drchronoEntities db = new drchronoEntities();
        public void EmergencyRoom(int patientid,int providerid,string AppDate,string ApptTime,string ApptType,string Reason)
        {
            SeeDoctorNow emergency = new SeeDoctorNow();
            emergency.ProviderID = providerid;
            emergency.PatientID = patientid;
            emergency.ApptDate = AppDate;
            emergency.ApptTime = ApptTime;
            emergency.ApptType = ApptType;
            emergency.Reason = Reason;
            emergency.Status = "pending";
            db.SeeDoctorNows.Add(emergency);
            db.SaveChanges();
          


        }
    }
}
