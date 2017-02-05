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
using System.Web.Services;
using Newtonsoft.Json.Linq;
using drchrono.Patients;
using RestSharp;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using BLL;

namespace drchrono
{
    public partial class RegisterPatient : System.Web.UI.Page
    {
        BLLPatientProfileHandler profile = new BLLPatientProfileHandler();
        BLLLoginHandler checkEmail = new BLLLoginHandler();

      
       

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
          [WebMethod(EnableSession = true)]
          public static void Register(string first, string last, string emailaddress,string password,string dob,string sex,string cell,string add) 
        {

                
                 XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
                 RegisterPatient patient = new RegisterPatient();
                
                 var id =  patient.CreatePatient(n, first, last, emailaddress, dob, sex, cell, emailaddress, add);
                 patient.PatientLocalDB(id, emailaddress, password,"20");
                 var activationcode =   patient.getActivationCode(id);
                 patient.SendEmail(emailaddress, activationcode);    
                
                   
            

               
         
        }

        
         public void PatientLocalDB(string id, string email,string password,string autolock)
          {

              profile.SavePatientLocalDB(id,email, password,autolock); 

          }

          public string CreatePatient(XmlNode n ,string first, string last, string emailaddress, string dob, string sex, string cell,string email, string add)
          {
              var id = profile.SavePatient(sex, n, Session["areacode"].ToString(),Session["state"].ToString(), Session["zip"].ToString(), Session["city"].ToString(), Session["url"].ToString(),last, first, dob, email, cell);
              return id;
          }

        public string getActivationCode(string patientid)
        {
           return profile.SendActivationEmail(patientid);

        }
        

        [WebMethod(EnableSession = true)]

      
            public static List<String> SetCityState(string zipcodevalue)
        {
                   
            
                   List<String> zipcodeelement = new List<String>();
                   XmlDocument getzipcodelist = HttpContext.Current.Session["getzipcodelist"] as XmlDocument; 
                   XmlNodeList zipcodelist = getzipcodelist.GetElementsByTagName("zipcode");

                   if (zipcodelist != null)
                   {
                       foreach (XmlNode zipcodenode in zipcodelist)
                       {

                                  if (zipcodevalue == zipcodenode.Attributes["code"].Value)
                                  {
                                     
                                   
                                    zipcodeelement.Add (zipcodenode.Attributes["city"].Value);
                                    zipcodeelement.Add(zipcodenode.Attributes["state"].Value);
                                    HttpContext.Current.Session["areacode"] = zipcodenode.Attributes["areacode"].Value;
                                    HttpContext.Current.Session["city"] = zipcodenode.Attributes["city"].Value;
                                    HttpContext.Current.Session["state"] = zipcodenode.Attributes["state"].Value;
                                    HttpContext.Current.Session["zip"] = zipcodevalue;
                                   

                                  }

                       }
                   }

                   return zipcodeelement;


        }
        
        public void SendEmail(string email,string code)
        {
            
            
            try
            {

                MailMessage mm = new MailMessage("abbasmustufain@gmail.com", email);
                mm.Subject = "Account Activation";
                string body = "Hello " + email.Trim() + ",";
                body += "<br /><br />Please click the following link to activate your account";
                
                body += "<br /><a href = '" + HttpContext.Current.Request.Url.AbsoluteUri.Replace("RegisterPatient.aspx", "../Default.aspx?ActivationCode=" + code) + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com";
                NetworkCredential NetworkCred = new NetworkCredential("abbasmustufain@gmail.com", "psychology@123");
                smtp.Credentials = NetworkCred;
                smtp.EnableSsl = true;
         
                smtp.Port = 587;
                smtp.Send(mm);
              
            
        }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email couldnot be sent ')", true);
                Console.WriteLine(ex.InnerException);
            }
        }



        [WebMethod(EnableSession = true)]
      
        public static string LoadZipCode(string zipcodevalue)   //When ajax called this method is executed
        {
            int count = 0;
            Uri uri2 = new Uri(HttpContext.Current.Session["url"].ToString());
            List<string> ziplist = new List<string>();
            //get zipcodes
            XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
            request2.Method = "POST";
            request2.ContentType = "text/xml";
            request2.CookieContainer = new CookieContainer();
            XmlTextWriter writer2 = new
            XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
            writer2.Namespaces = false;
            XmlDocument zipcode = new XmlDocument();
            XmlElement ppmdmsg = (XmlElement)zipcode.AppendChild(zipcode.CreateElement("ppmdmsg"));
            XmlNode importNode = ppmdmsg.OwnerDocument.ImportNode(n, true);
            ppmdmsg.SetAttribute("action", "lookupzipcode");
            ppmdmsg.SetAttribute("class", "lookup");
            ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
            ppmdmsg.SetAttribute("exactmatch", "0");
            ppmdmsg.SetAttribute("code", "");
            ppmdmsg.SetAttribute("orderby", "code");
            ppmdmsg.SetAttribute("page", "1");
            ppmdmsg.SetAttribute("nocookie", "1");
            ppmdmsg.AppendChild(importNode);
            writer2.WriteRaw(zipcode.InnerXml);
            writer2.Flush();
            writer2.Close();


            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument getzipcodelist = new XmlDocument();
            HttpContext.Current.Session["getzipcodelist"] = getzipcodelist;
            getzipcodelist.Load(reader2);
           
            XmlNodeList zipcodelist = getzipcodelist.GetElementsByTagName("zipcode");

            if (zipcodelist != null)
            {
                foreach (XmlNode zipcodenode in zipcodelist)
                {
                    ziplist.Add(zipcodenode.Attributes["code"].Value);
                   
                   

                }
            }


            if(ziplist.Contains(zipcodevalue))
            {

                return "1";
            }

            else
            {

                return "0";
            }

           
        }

          [WebMethod(EnableSession = true)]
       
        public static string EmailAddExist(string emailaddress)
          {



              RegisterPatient patient = new RegisterPatient();
              return  patient.RegistercheckEmail(emailaddress);
                
          }

        public string RegistercheckEmail(string emailaddress)
        {

            return checkEmail.EmailAddExists(emailaddress);
        }

    }
}