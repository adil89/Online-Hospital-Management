using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Xml;
using System.Net;
using System.IO;
using DAL;
namespace BLL
{
    public class BLLAccountsHandler
    {
        AccountDAL account = new AccountDAL();

        public void autolock(string patientid,string duration)
        {

           account.autolock(patientid,duration);
        }

        public string RecentLogin(string patientid)
        {
            return account.RecentLogin(patientid);

        }

        public List<string> GetAccountDetails(XmlNode usercontext, string url, string patientid)
        {
            List<string> accountdetails = new List<string>();
            Uri uri2 = new Uri(url);        
            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
            request2.Method = "POST";
            request2.ContentType = "text/xml";
            request2.CookieContainer = new CookieContainer();
            XmlTextWriter writer2 = new
            XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
            writer2.Namespaces = false;
            XmlDocument patientprofile = new XmlDocument();
            XmlElement ppmdmsg = (XmlElement)patientprofile.AppendChild(patientprofile.CreateElement("ppmdmsg"));
            ppmdmsg.SetAttribute("action", "getdemographic");
            ppmdmsg.SetAttribute("class", "api");
            ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
            ppmdmsg.SetAttribute("nocookie", "1");
            ppmdmsg.SetAttribute("patientid", patientid);


            XmlNode importNode = ppmdmsg.OwnerDocument.ImportNode(usercontext, true);
            ppmdmsg.AppendChild(importNode);
            writer2.WriteRaw(patientprofile.InnerXml);
            writer2.Flush();
            writer2.Close();


            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument getdemographics = new XmlDocument();
            getdemographics.Load(reader2);
            XmlNodeList nodeList = getdemographics.GetElementsByTagName("patient");
            if (nodeList != null)
            {
                foreach (XmlNode x in nodeList)
                {

                    string[] Token = x.Attributes["name"].Value.Split(',');
                    accountdetails.Add(Token[1] + Token[0]);  //username

                    foreach (XmlNode childNode in x.ChildNodes)
                    {



                        if (childNode.Name == "contactinfo")
                        {
                            accountdetails.Add(childNode.Attributes["homephone"].Value);  //linkedphonenumber
                           accountdetails.Add(childNode.Attributes["homephone"].Value);  //session homephone

                        }
                    }
                }
                return accountdetails;
            }
            return null;
        }
                


        public List<string> GetAccountDetailLocalDB(string patientid)
        {
          
          return  account.GetAccountDetailLocalDB(patientid);
        }


        public void SaveReminders(Boolean email, Boolean TextMessage, Boolean both, XmlNode usercontext, string url,string patientid)
        {
                if (email)
            {
             
                Uri uri2 = new Uri(url);                        //last returned URL

                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
                request2.Method = "POST";
                request2.ContentType = "text/xml";
                request2.CookieContainer = new CookieContainer();
                XmlTextWriter writer2 = new
                XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
                writer2.Namespaces = false;
                XmlDocument patientprofile = new XmlDocument();
                XmlElement ppmdmsg = (XmlElement)patientprofile.AppendChild(patientprofile.CreateElement("ppmdmsg"));
                ppmdmsg.SetAttribute("action", "savepatientpreference");
                ppmdmsg.SetAttribute("class", "messaging");
                ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
                ppmdmsg.SetAttribute("nocookie", "1");
                ppmdmsg.SetAttribute("patientid", patientid.Substring(2, patientid.Length));
                ppmdmsg.SetAttribute("apptreminderemail", "1");
                ppmdmsg.SetAttribute("apptremindertext", "0");
                ppmdmsg.SetAttribute("notificationemail", "0");
                ppmdmsg.SetAttribute("notiicationtext", "0");
                ppmdmsg.SetAttribute("campaignemail", "0");
                ppmdmsg.SetAttribute("campaigntext", "0");
                XmlNode importNode = ppmdmsg.OwnerDocument.ImportNode(usercontext, true);
                ppmdmsg.AppendChild(importNode);
                writer2.WriteRaw(patientprofile.InnerXml);
                writer2.Flush();
                writer2.Close();

            }

            else if (TextMessage)
            {

                Uri uri2 = new Uri(url);                        //last returned URL

                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
                request2.Method = "POST";
                request2.ContentType = "text/xml";
                request2.CookieContainer = new CookieContainer();
                XmlTextWriter writer2 = new
                XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
                writer2.Namespaces = false;
                XmlDocument patientprofile = new XmlDocument();
                XmlElement ppmdmsg = (XmlElement)patientprofile.AppendChild(patientprofile.CreateElement("ppmdmsg"));
                ppmdmsg.SetAttribute("action", "savepatientpreference");
                ppmdmsg.SetAttribute("class", "messaging");
                ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
                ppmdmsg.SetAttribute("nocookie", "1");
                ppmdmsg.SetAttribute("patientid", patientid.Substring(2, patientid.Length-1));
                ppmdmsg.SetAttribute("apptreminderemail", "0");
                ppmdmsg.SetAttribute("apptremindertext", "1");
                ppmdmsg.SetAttribute("notificationemail", "0");
                ppmdmsg.SetAttribute("notiicationtext", "0");
                ppmdmsg.SetAttribute("campaignemail", "0");
                ppmdmsg.SetAttribute("campaigntext", "0");
                XmlNode importNode = ppmdmsg.OwnerDocument.ImportNode(usercontext, true);
                ppmdmsg.AppendChild(importNode);
                writer2.WriteRaw(patientprofile.InnerXml);
                writer2.Flush();
                writer2.Close();



            }

            else if (both)
            {

               
                Uri uri2 = new Uri(url);                        //last returned URL

                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
                request2.Method = "POST";
                request2.ContentType = "text/xml";
                request2.CookieContainer = new CookieContainer();
                XmlTextWriter writer2 = new
                XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
                writer2.Namespaces = false;
                XmlDocument patientprofile = new XmlDocument();
                XmlElement ppmdmsg = (XmlElement)patientprofile.AppendChild(patientprofile.CreateElement("ppmdmsg"));
                ppmdmsg.SetAttribute("action", "savepatientpreference");
                ppmdmsg.SetAttribute("class", "messaging");
                ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
                ppmdmsg.SetAttribute("nocookie", "1");
                ppmdmsg.SetAttribute("patientid", patientid.Substring(2,patientid.Length));
                ppmdmsg.SetAttribute("apptreminderemail", "1");
                ppmdmsg.SetAttribute("apptremindertext", "1");
                ppmdmsg.SetAttribute("notificationemail", "0");
                ppmdmsg.SetAttribute("notiicationtext", "0");
                ppmdmsg.SetAttribute("campaignemail", "0");
                ppmdmsg.SetAttribute("campaigntext", "0");
                XmlNode importNode = ppmdmsg.OwnerDocument.ImportNode(usercontext, true);
                ppmdmsg.AppendChild(importNode);
                writer2.WriteRaw(patientprofile.InnerXml);
                writer2.Flush();
                writer2.Close();



            }


        }

        public void AutorizeDevice(string patientid)
       
        {

            account.AutorizeDevice(patientid);

        }

        public void DeauthorizeDevice(string patientid)
        
        {

            account.DeauthorizeDevice(patientid);

        }

        public string CheckPassword(string patientid)
        {

            return account.CheckPassword(patientid);

        }


        public void ResetPassword(string patientid,string password)
        {


            account.ResetPassword(patientid,password);
        
        }

        public List<accounthistory> GetAccountHistory(string patientid)
        {

           return account.GetAccountHistory(patientid);
        }

     


    }

    
}
