using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Doctors
{
    public class PatientsQueueDAL
    {
        drchronoEntities db = new drchronoEntities();
        public List<GetPatientsInQueue_Result> GetQueue(int providerID)
        {
            string nowDate = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string nowTime = DateTime.Now.ToString("hh:mm", CultureInfo.InvariantCulture);
    
            List<GetPatientsInQueue_Result> GFAA = db.GetPatientsInQueue(providerID).ToList();

            return GFAA;
        }

        public void acceptAppointmet(int patientID, string appTime, string appDate, int ProviderID, string appType, string reason)
        {

            List<SeeDoctorNow> rec = (from n in db.SeeDoctorNows
                                            where n.PatientID == patientID && n.ApptTime == appTime && n.ApptDate == appDate
                                            select n).ToList();

            for (int i = 0; i < rec.Count; i++)
            {
                db.SeeDoctorNows.Remove(rec[i]);
            }
            db.SaveChanges();
        
            SeeDoctorNow pa = new SeeDoctorNow();
            pa.PatientID = patientID;
            pa.ApptTime = appTime;
            pa.ApptDate = appDate;
            pa.ApptType = appType;
            pa.Reason = reason;
            pa.ProviderID = ProviderID;
            pa.Status = "Accepted";

            db.SeeDoctorNows.Add(pa);
            db.SaveChanges();



        }

        public string getColumn(int providerID)
        {

            var id = (from n in db.DoctorRooms where n.ProviderID == providerID select n.ColID).Single();
            return id;
        }

    }
}
