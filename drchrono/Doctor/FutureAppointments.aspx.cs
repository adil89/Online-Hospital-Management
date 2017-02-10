using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Doctors;
using drchrono.Patients;
using DAL;
using System.Xml;
using drchrono.PropertyClasses;
using BLL.Patients;

namespace drchrono.Doctor
{
    public partial class FutureAppointments : System.Web.UI.Page
    {
        FutureAvailableAppointmentsBLL fab = new FutureAvailableAppointmentsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        BLLMyDocuments _myDoc = new BLLMyDocuments();

        [WebMethod(EnableSession = true)]
        public static object GetFutureAvailableAppointments(int jtStartIndex, int jtPageSize)
        {
            FutureAppointments fa = new FutureAppointments();
            List<GetFutureAvailableAppointments_Result> rec = fa.GetFutureAvailableAppointmentsPrivate();

            return new { Result = "OK", Records = rec, TotalRecordCount = rec.Count };
        }

        private List<GetFutureAvailableAppointments_Result> GetFutureAvailableAppointmentsPrivate()
        {
            int providerID = int.Parse(Session["providerid"].ToString());     //HttpContext.Current.Session["patientid"].ToString();
            List<GetFutureAvailableAppointments_Result> gfaa = fab.GetFutureAvailableAppointments(providerID);
            return gfaa;
        }

        [WebMethod(EnableSession = true)]
        public static object acceptAppointment(string patientID, string appTime,string appDate,string appType,string reason)
        {
            //Save PatientAppointment to advancedMD 
            FutureAppointments fa = new FutureAppointments();
              XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
            fa.acceptAppointmentPrivate(patientID, appTime, appDate, appType, reason);
            fa.SaveAppointmentAdvancedMD(n, HttpContext.Current.Session["url"].ToString(), patientID, appTime, appDate, appType, reason);
            return new { Result = "OK", Records = "rec", TotalRecordCount = "rec.Count" };
        }

        private void acceptAppointmentPrivate(string patientID, string appTime, string appDate,string appType,string reason)
        {
            int providerID = int.Parse(Session["providerid"].ToString());     //HttpContext.Current.Session["patientid"].ToString();
            fab.acceptAppointment(patientID, appTime, appDate, providerID, appType, reason);
        
        }

        public void SaveAppointmentAdvancedMD(XmlNode usercontext,string url,string patientID, string appTime,string appDate,string appType,string reason)
        {

            fab.SaveAppointmentAdvancedMD(usercontext, url, patientID, appTime, appDate, int.Parse(Session["ProviderID"].ToString()), appType, reason);
        }

        [WebMethod(EnableSession = true)]
        public static object GetAllDocument(int jtStartIndex, int jtPageSize)
        {

            string patientID = HttpContext.Current.Request.QueryString["patientID"];
            int appID = Convert.ToInt32(HttpContext.Current.Request.QueryString["appID"]);

            FutureAppointments my = new FutureAppointments();
            List<Documents> doc = my.GetAllDocument2(patientID, appID);

            return new { Result = "OK", Records = doc, TotalRecordCount = doc.Count };
        }

        private List<Documents> GetAllDocument2(string patientID, int appID)
        {
               
            XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
            string url = HttpContext.Current.Session["url"].ToString();
            string patientId = patientID;
            List<Documents> doc = _myDoc.GetAllDocuments(patientId, url, n, appID);
            return doc;
        }

        }
}