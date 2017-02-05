using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Doctors;

namespace BLL.Doctors
{
    public class MyFutureApointments
    {
        MyFutureApointmentsDAL mfa = new MyFutureApointmentsDAL();                 


        public List<GetMyFutureAppointments_Result> GetMyFutureAppointments(int providerID)
        {
            List<GetMyFutureAppointments_Result> rec = mfa.GetMyFutureAppointments(providerID);

            return rec;
        }
    }
}
