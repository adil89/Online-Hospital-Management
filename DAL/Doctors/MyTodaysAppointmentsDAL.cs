using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Doctors
{
    public class MyTodaysAppointmentsDAL
    {
        drchronoEntities db = new drchronoEntities();
        public List<GetMyTodayAppointments_Result> GetMyTodaysAppointmentsPrivate(int providerID)
        {

            string nowDate = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            List<GetMyTodayAppointments_Result> rec = db.GetMyTodayAppointments(nowDate, providerID).ToList();

            return rec;
        }
    }
}
