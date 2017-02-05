using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;


namespace drchrono.Patients
{
    public partial class TwoFactorAuthentication : System.Web.UI.Page
    {

        int mobilecode = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
      

      

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Accountsettings.aspx");
           
        }

        private  void sendMobileCode()
        {
            string user_no = mobileno.Text.ToString();

            //Get Phone number of patient

            TwilioRestClient client;
            string ACCOUNT_SID = System.Configuration.ConfigurationManager.AppSettings["SMSSID"];
            string ACCOUNT_TOKEN = System.Configuration.ConfigurationManager.AppSettings["SMSAuthToken"];
            string CALLER_ID = System.Configuration.ConfigurationManager.AppSettings["SMSPhoneNumber"];

            // ACCOUNT_SID and ACCOUNT_TOKEN are from your Twilio account
            client = new TwilioRestClient(ACCOUNT_SID, ACCOUNT_TOKEN);
            Random rnd = new Random();
            int code = rnd.Next(1000, 9999);
            mobilecode = code;
           // var result = client.SendMessage("(502) 276-8990", user_no, "Verification code:" + code.ToString());

            // Build the parameters 
            var options = new CallOptions();
            options.From = CALLER_ID;
            options.To = user_no;
            options.Url = "https://demo.twilio.com/welcome/voice/";
            

            var result = client.InitiateOutboundCall(options);
            Console.WriteLine(result.Sid);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Verification code has been sent to you via sms')", true);
            if (result.RestException != null)
            {
                Debug.WriteLine(result.RestException.Message);
            }

        }

        protected void save_Click1(object sender, EventArgs e)
        {
            //Here Save phone number assosciated with this patientID onto AdvancedMD in telephone Number
            //Update database whether 2 factor authentication is enabled or not

            sendMobileCode();


            if (mobilecode.ToString() == mobilecodetextbox.ToString())  //Phone Number verified
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have successfully verified your phone number')", true);
                //add here boolean value in database
                String query = "update loginuser set TwoFactorAuth = @twofactorauth where patientID=@patientid";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@patientid", Session["patientid"].ToString());
                cmd.Parameters.AddWithValue("@twofactorauth", 1);
               
                try
                {

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }

                catch (Exception)
                {


                }

            }
            
        }

       
    }
}