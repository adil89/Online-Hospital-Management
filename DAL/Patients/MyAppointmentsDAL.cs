using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Patients
{
    
   public class MyAppointmentsDAL
    {
        drchronoEntities db = new drchronoEntities();

        public List<getAppointments_Result> GetAllUpcomingAppointment(string patientId)
        {
            string nowDate = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string nowTime = DateTime.Now.ToString("hh:mm", CultureInfo.InvariantCulture);

            List<getAppointments_Result> p = db.getAppointments(nowDate + " " + nowTime,patientId).ToList();
            return p;
        }

        public List<GetPastAppointments_Result> GetAllPastAppointments(string patientId)
        {
            string nowDate = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string nowTime = DateTime.Now.ToString("hh:mm", CultureInfo.InvariantCulture);

            List<GetPastAppointments_Result> returnList = new List<GetPastAppointments_Result>();

            List<GetPastAppointments_Result> pa = db.GetPastAppointments(nowDate + " " + nowTime,patientId, "Okay").ToList();
            List<GetPastAppointments_Result> pa2 = db.GetPastAppointments(nowDate + " " + nowTime,patientId, "pending").ToList();

            for(int i = 0;i < pa2.Count; i++)
            {
                pa2[i].ProviderID = 0;
                pa2[i].Feedback = "";
            }

            returnList = pa.Concat(pa2).ToList();

            return returnList;
        }

       
    }
}
