using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using BLL.Patients;
using drchrono.PropertyClasses;
using DAL;

namespace drchrono.Patients
{
    public partial class MyAppointments : System.Web.UI.Page
    {
        MyAppointmentsBLL mab = new MyAppointmentsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static object GetAllUpcomingAppointments(int jtStartIndex, int jtPageSize)
        {
            MyAppointments ma = new MyAppointments();
            List<getAppointments_Result> rec = ma.GetAllUpcomingAppointmentsPrivate();
            
            return new { Result = "OK", Records = rec, TotalRecordCount = rec.Count };
        }

        private List<getAppointments_Result> GetAllUpcomingAppointmentsPrivate()
        {
            string patientId = HttpContext.Current.Session["patientid"].ToString();
            List<getAppointments_Result> rec = mab.GetAllUpcomingAppointments(patientId);
            return rec;
        }

        [WebMethod(EnableSession = true)]
        public static object GetAllPastAppointments(int jtStartIndex, int jtPageSize)
        {
            MyAppointments ma = new MyAppointments();
            List<GetPastAppointments_Result> rec = ma.GetAllPastAppointmentsPrivate(); 

            return new { Result = "OK", Records = rec, TotalRecordCount = rec.Count };
        }

        private List<GetPastAppointments_Result> GetAllPastAppointmentsPrivate()
        {
            string patientId = HttpContext.Current.Session["patientid"].ToString();
            XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
            string url = HttpContext.Current.Session["url"].ToString();
            List<GetPastAppointments_Result> rec = mab.GetAllPastAppointments(n,url,patientId);
            return rec;
        }
    }
}