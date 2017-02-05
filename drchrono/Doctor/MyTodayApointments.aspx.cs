using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.Doctors;
using DAL;

namespace drchrono.Doctor
{
    public partial class MyTodayApointments : System.Web.UI.Page
    {
        MyTodaysAppointmentsBLL mta = new MyTodaysAppointmentsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static object GetMyTodaysAppointments()
        {
            MyTodayApointments mta = new MyTodayApointments();
            List<GetMyTodayAppointments_Result> rec = mta.GetMyTodaysAppointmentsPrivate();

            return new { Result = "OK", Records = rec, TotalRecordCount = rec.Count };
        }

        private List<GetMyTodayAppointments_Result> GetMyTodaysAppointmentsPrivate()
        { 
            int providerID = int.Parse(Session["providerid"].ToString());     //HttpContext.Current.Session["patientid"].ToString();
            List<GetMyTodayAppointments_Result> rec = mta.GetMyTodaysAppointmentsPrivate(providerID);
            return rec;
        }
    }
}