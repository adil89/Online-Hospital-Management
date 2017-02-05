using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Doctors;
using BLL;
using drchrono.Patients;
using DAL;
using System.Xml;

namespace drchrono
{
    public partial class DoctorPortal : System.Web.UI.Page
    {
        PatientsQueueBLL fab = new PatientsQueueBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void patientsQueueButton_Click(object sender, EventArgs e)
        {

        }

        protected void todayAppointmentsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyTodayApointments.aspx");
        }

        protected void futureAppointmentsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("FutureAppointments2.aspx");
        }

        protected void futureAvailableAppointmentButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("FutureAppointments.aspx");
        }

        protected void myRoomButton_Click(object sender, EventArgs e)
        {

        }

        protected void mySchedulerButton_Click(object sender, EventArgs e)
        {

        }

        protected void myProfileButton_Click(object sender, EventArgs e)
        {

        }

        protected void messagesButton_Click(object sender, EventArgs e)
        {

        }

        protected void myPatientsButton_Click(object sender, EventArgs e)
        {

        }

        protected void clinicalGuidelinesButton_Click(object sender, EventArgs e)
        {

        }

        protected void myBillingButton_Click(object sender, EventArgs e)
        {

        }

        protected void accountSettingsButton_Click(object sender, EventArgs e)
        {

        }

        protected void systemTestButton_Click(object sender, EventArgs e)
        {

        }
        protected void Consultation_Click(object sender, EventArgs e)
        {
            Response.Redirect("Consultation.aspx");
        }
         
        [WebMethod(EnableSession = true)]
        public static Object PatientQueue()
        {
            DoctorPortal fa = new DoctorPortal();
            List<GetPatientsInQueue_Result> rec = fa.GetPatientsInQueuePrivate();

            return new { Result = "OK", Records = rec, TotalRecordCount = rec.Count };

   

        }

        private List<GetPatientsInQueue_Result> GetPatientsInQueuePrivate()
        {
            int providerID = int.Parse(Session["providerid"].ToString());     //HttpContext.Current.Session["patientid"].ToString();
            List<GetPatientsInQueue_Result> gfaa = fab.GetQueue(providerID);
            return gfaa;
        }

        [WebMethod(EnableSession = true)]
        public static object acceptAppointment(string patientID, string appTime, string appDate, string appType, string reason)
        {
            var currTime = DateTime.Now.ToString("HH:mm");  //make an appointment at time when doctor accepts it 
           
            //Save PatientAppointment to advancedMD 
            DoctorPortal fa = new DoctorPortal();
            XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
            fa.acceptAppointmentPrivate(patientID, appTime, appDate, appType, reason);
            fa.SaveAppointmentAdvancedMD(n, HttpContext.Current.Session["url"].ToString(), patientID, currTime, appDate, appType, reason);
            return new { Result = "OK", Records = "rec", TotalRecordCount = "rec.Count" };
        }

        private void acceptAppointmentPrivate(string patientID, string appTime, string appDate, string appType, string reason)
        {
            int providerID = int.Parse(Session["providerid"].ToString());     //HttpContext.Current.Session["patientid"].ToString();
            fab.acceptAppointment(int.Parse(patientID), appTime, appDate, providerID, appType, reason);

        }

        public void SaveAppointmentAdvancedMD(XmlNode usercontext, string url, string patientID, string appTime, string appDate, string appType, string reason)
        {

            fab.SaveAppointmentAdvancedMD(usercontext, url, int.Parse(patientID), appTime, appDate, int.Parse(Session["ProviderID"].ToString()), appType, reason);
        }


    }
}