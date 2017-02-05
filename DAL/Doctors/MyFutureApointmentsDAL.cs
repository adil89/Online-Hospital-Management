using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace DAL.Doctors
{
    public class MyFutureApointmentsDAL
    {
        drchronoEntities db = new drchronoEntities();
        public List<GetMyFutureAppointments_Result> GetMyFutureAppointments(int providerID)
        {
            string nowDate = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            List<GetMyFutureAppointments_Result> rec = db.GetMyFutureAppointments(nowDate, providerID).ToList();
    
            return rec;
        }
    }
}
