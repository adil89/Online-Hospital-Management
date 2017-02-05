using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Doctors
{
    public class FutureAvailableAppointmentsDAL
    {
        drchronoEntities db = new drchronoEntities();
        public List<GetFutureAvailableAppointments_Result> GetFutureAvailableAppointments(int providerID)
        {
            string nowDate = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string nowTime = DateTime.Now.ToString("hh:mm", CultureInfo.InvariantCulture);

            List<GetFutureAvailableAppointments_Result> GFAA = db.GetFutureAvailableAppointments(nowDate + " " + nowTime, providerID).ToList();

            return GFAA;
        }

        public void acceptAppointmet(string patientID, string appTime, string appDate,int ProviderID,string appType,string reason)
        {

            List<PendingAppointment> rec = (from n in db.PendingAppointments
                                            where n.patientID == patientID && n.appTime == appTime && n.appDate == appDate
                                            select n).ToList();

            for (int i = 0; i < rec.Count; i++)
            { 
                db.PendingAppointments.Remove(rec[i]); 
            }
            db.SaveChanges();

            PendingAppointment pa = new PendingAppointment();
            pa.patientID = patientID;
            pa.appTime = appTime;
            pa.appDate = appDate;
            pa.appType = appType;
            pa.Reason = reason;
            pa.ProviderID = ProviderID;
            pa.Status = "Accepted";

            db.PendingAppointments.Add(pa);
            db.SaveChanges();


        
        }

        public string getColumn(int providerID)
        {
            
           var id =  (from n in db.DoctorRooms where n.ProviderID == providerID select n.ColID).Single();
           return id;
        }
    }
}
