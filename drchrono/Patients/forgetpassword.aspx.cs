using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using BLL;

namespace drchrono
{
    public partial class forgetpassword : System.Web.UI.Page
    {
        BLLLoginHandler login = new BLLLoginHandler();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void recoverPasswordButton_Click(object sender, EventArgs e)
        {
               string email = "";
               string password = "";
               XmlNode n = Session["usercontext"] as XmlNode;
               var id =  login.CheckPatientID(n,Session["url"].ToString(),dateOfBirthTextbox.Text);
            
           
            if (id == "")
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of Birth is not incorrect')", true);
            }

            if (id != "")
            {
               email = login.CheckPatientEmail(n, Session["url"].ToString(),id);
                // check email assigned to this patientid and whether user has given correct email or not (against given DOB) 
                
                if (email == "")

                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email Address not incorrect')", true);
                    
                }
            }

             if(email!="")
            { 
            //Now here check by that email retrieved from api call matches email given by user

                if (email == emailAddressTextbox.Text.ToString().ToUpper())   //correct email address againt selected DOB
                {

                    //Now retireve password from local database
                    password = login.GetPass(email);
                  

                    try
                    {
                        
                  
                        MailMessage mm = new MailMessage("abbasmustufain@gmail.com", email);
                        mm.Subject = "Password Recovery";
                        mm.Body = "Your password is:" + password;
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        System.Net.NetworkCredential NetworkCred = new NetworkCredential();
                        NetworkCred.UserName = "abbasmustufain@gmail.com";
                        NetworkCred.Password = "psychology@123";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password has been sent to your email')", true);
                        Response.Redirect("RecoveryEmailSent.aspx");

                    }

                    catch (Exception)
                    {



                    }

                }

          
                
            }
         
        }
    }
}