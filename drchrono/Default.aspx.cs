using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Xml;
using Twilio;
using BLL;
using System.Linq;
using System.Net.Mail;

namespace drchrono
{

    public partial class _Default : Page
    {

        BLLLoginHandler login = new BLLLoginHandler();        

        protected void Page_Load(object sender, EventArgs e)
        
        {
            Session["patientid"] = null;
            Session["url"] = "https://partnerlogin.advancedmd.com/practicemanager/xmlrpc/processrequest.asp";
            Session["usercontext"] = login.ApplicationAuth()[0];
            if (!this.IsPostBack)
            {
                //SendEmail("abbasmustufain@outlook.com", "1");
                Session["patientid"] = null;
                HttpCookie myCookie = Request.Cookies["MyTestCookie"];
                if(myCookie!=null)
                {
                    userTextbox.Text = myCookie.Value;
                }

                string activationCode = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"]) ? Request.QueryString["ActivationCode"] : Guid.Empty.ToString();
               
                if (activationCode != "00000000-0000-0000-0000-000000000000")
                {
                 
                   
                    var rowsaffected = login.ActivationURL(activationCode.Substring(0,activationCode.IndexOf('/')));
                    if (rowsaffected != 1)
                    {
                   
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid activation code')", true);
                    }

                }

            }
       


        }  



  

        protected void loginButton_Click(object sender, EventArgs e)
        {
        
            var patientid = 0;
            var factor = 0;
            if (userTextbox.Text == "" || passwordTextbox.Text== "")
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('please fill all the required fields')", true);
            }
                
             else //check here the login credentials
 

            {
               //check wether user exists or not
                var id = login.checkLoginCredentials(userTextbox.Text, passwordTextbox.Text);
                if (id == null)
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email address or password is incorrect')", true);

                }

                else
                {
                    //Check whether email address is activated or not
                    List<int> email = new List<int>();
                    email = login.CheckEmailActivation(id);
                    patientid = email[0];
                    factor = email[1];
                    Session["patientid"] = id;


                    if (id != "" && patientid == 0) //User account has been activated
                    {


                        login.UserAccountActivated(DateTime.Now.Date.ToString(), DateTime.Now.TimeOfDay.ToString(), Request.Browser.Type, Session["ip"].ToString(), Session["patientid"].ToString());

                        if (factor == 1)
                        {
                            Response.Redirect("~/Patients/MobileVerificationCode.aspx");  //Patient Portal
                        }
                        else
                        {
                            Response.Redirect("~/Patients/PatientPortal.aspx");

                        }
                    }
                    else if (patientid > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please activate your account')", true);
                    }


                }

            }
        }

        protected void chkRememberMe_CheckedChanged(object sender, EventArgs e)  //when remember me clicked
        {
            if (chkRememberMe.Checked)
            {
                // Clear any other tickets that are already in the response
                Response.Cookies.Clear();

                // Set the new expiry date - to thirty days from now
                DateTime expiryDate = DateTime.Now.AddDays(30);

                HttpCookie myCookie = new HttpCookie("MyTestCookie");
                myCookie.Value = userTextbox.Text;
                myCookie.Expires = expiryDate;
                // Add the cookie to the response.
                Response.Cookies.Add(myCookie);
            }
        }
        protected void healthCareProvidersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Doctor/DoctorLogin.aspx");
        }

        protected void organizationsButton_Click(object sender, EventArgs e)
        {

        }

        protected void aboutUsButton_Click(object sender, EventArgs e)
        {

        }

        protected void howgomdnowWorksButton_Click(object sender, EventArgs e)
        {

        }

        protected void contactUsButton_Click(object sender, EventArgs e)
        {

        }

        protected void faqsButton_Click(object sender, EventArgs e)
        {

        }

        private void sendMobileCode()
        {
            string email = emailTextbox.Text.ToString();

            //Get Phone number of patient

            TwilioRestClient client;
            string ACCOUNT_SID = System.Configuration.ConfigurationManager.AppSettings["SMSSID"];
            string ACCOUNT_TOKEN = System.Configuration.ConfigurationManager.AppSettings["SMSAuthToken"];
            string CALLER_ID = System.Configuration.ConfigurationManager.AppSettings["SMSPhoneNumber"];

            // ACCOUNT_SID and ACCOUNT_TOKEN are from your Twilio account
            client = new TwilioRestClient(ACCOUNT_SID, ACCOUNT_TOKEN);
            Random rnd = new Random();
            int code = rnd.Next(1000, 9999);
            Session["MobileCode"] = code;
            var result = client.SendMessage(CALLER_ID, "PHONE NUMBER TO SEND TO", code.ToString());
            if (result.RestException != null)
            {
                Debug.WriteLine(result.RestException.Message);
            }

        }

        [WebMethod(EnableSession = true)]
        public static void GetIPAddress(string ip)
        {
            HttpContext.Current.Session["ip"] = ip;
        }
                //This code is for testing 

      /*  public void SendEmail(string email, string code)
        {


            try
            {

                MailMessage mm = new MailMessage("support@gomdnow.com", email);
                mm.Subject = "Account Activation";
                string body = "Hello " + email.Trim() + ",";
                body += "<br /><br />Please click the following link to activate your account";

                body += "<br /><a href = '" + HttpContext.Current.Request.Url.AbsoluteUri.Replace("RegisterPatient.aspx", "../Default.aspx?ActivationCode=" + code) + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
               // smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gomdnow.com";
                NetworkCredential NetworkCred = new NetworkCredential("support@gomdnow.com", "ieTj51!0");
                smtp.Credentials = NetworkCred;
                smtp.EnableSsl = true;

                smtp.Port = 25;
                smtp.Send(mm);


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email couldnot be sent ')", true);
                Console.WriteLine(ex.InnerException);
            }
        }*/


       

    }
}