using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace drchrono
{
    public partial class PatientPortal : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["patientid"] == null)
            {

                Response.Redirect("Default.aspx");
            }
        }
        protected void requestConsultButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestConsultant.aspx");
        }

        protected void myProfileButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientProfile.aspx");
        }

        protected void myAppointmentsButton_Click(object sender, EventArgs e)
        {

              Response.Redirect("MyAppointments.aspx");

        }

        protected void healthHstoryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SimplePeopleList.aspx");

        }

        protected void messagesButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Messaging.aspx");

        }

        protected void accountHistoryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Accountsettings.aspx");
        }

        protected void myDocumentsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyDocuments.aspx");
        }

        protected void myBillingButton_Click(object sender, EventArgs e)
        {
					   Response.Redirect("MyBilling.aspx");
        }

        protected void dependantButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dependents.aspx");
        }

        protected void systemTestButton_Click(object sender, EventArgs e)
        {

        }

        protected void contactUsButton_Click(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static Object getTime()
        {
            BLLPatientProfileHandler profile = new BLLPatientProfileHandler();
             var autolock =  profile.getAutoLock(HttpContext.Current.Session["patientid"].ToString());
            return JsonConvert.SerializeObject(autolock);

        }
    }
}