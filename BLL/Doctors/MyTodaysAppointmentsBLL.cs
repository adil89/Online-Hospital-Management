using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Doctors;

namespace BLL.Doctors
{
    public class MyTodaysAppointmentsBLL
    {
        MyTodaysAppointmentsDAL mta = new MyTodaysAppointmentsDAL();

        public List<GetMyTodayAppointments_Result> GetMyTodaysAppointmentsPrivate(int providerID)
        {
             List<GetMyTodayAppointments_Result> rec = mta.GetMyTodaysAppointmentsPrivate(providerID);
             return rec;
        }
    }
}
