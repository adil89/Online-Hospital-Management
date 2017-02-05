using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Net;
using System.Xml;
using System.IO;
using System.Globalization;
namespace BLL
 
{
    public class BLLLoginHandler
    {
        LoginDAL login = new LoginDAL();


          public string EmailAddExists(string emailaddress)
        {

          return  login.EmailAddExists(emailaddress);
        }
        public string checkLoginCredentials(string username, string password)
        {

            return login.checkLoginCredentials(username, password);

        }

        public List<int> CheckEmailActivation(string id)
        {

            return login.CheckEmailActivation(id);
        }
        public void UserAccountActivated(string date, string time, string browser, string ip, string id)
        {

            login.UserAccountActivated(date, time, browser, ip, id);

        }
      
        public int ActivationURL(string activationcode)
        {

            return login.ActivationURL(activationcode);
        }

        public List<XmlNode> ApplicationAuth()
        {

            List<XmlNode> getAuth = new List<XmlNode>();
            string token = "";

            string cookie = "";
            string errorcode = "";
            string webserver = "";
            string success = "";
            Uri uri = new Uri("https://partnerlogin.advancedmd.com/practicemanager/xmlrpc/processrequest.asp");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri.ToString());
            request.Method = "POST";
            request.ContentType = "text/xml";

            // Send the request
            XmlTextWriter writer = new
            XmlTextWriter(request.GetRequestStream(), System.Text.Encoding.UTF8);
            writer.Namespaces = false;
            string data = "<ppmdmsg action=\"login\" class=\"login\" msgtime=" + "'" + DateTime.Now + "'" + " username=\"GMNFUL\" psw=\"hjp()567\" officecode=\"991349\" appname=\"API\"/>";
            writer.WriteRaw(data);
            writer.Flush();
            writer.Close();

            // Return the response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            XmlDocument doc = new XmlDocument();
            doc.Load(reader);

            XmlNodeList node = doc.GetElementsByTagName("usercontext");
            if (node != null)
            {
                foreach (XmlNode n in node)
                {
                    success = n.ParentNode.Attributes["success"].Value;
                    webserver = n.Attributes["webserver"].Value;
                }
            }

            XmlNodeList node2 = doc.GetElementsByTagName("code");
            if (node2 != null)
            {

                foreach (XmlNode n in node2)
                {
                    errorcode = n.InnerText;

                }
            }


            if (errorcode == "-2147220476" && success == "0")
            {

                Uri uri1 = new Uri(webserver + "/xmlrpc/processrequest.asp");
                HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(uri1.ToString());
                request1.Method = "POST";
                request1.ContentType = "text/xml";
                XmlTextWriter writer1 = new
                XmlTextWriter(request1.GetRequestStream(), System.Text.Encoding.UTF8);
                writer1.Namespaces = false;
                string data1 = "<ppmdmsg action=\"login\" class=\"login\" msgtime=" + "'" + DateTime.Now + "'" + " username=\"GMNFUL\" psw=\"hjp()567\" officecode=\"991349\" appname=\"API\"/>";
                writer1.WriteRaw(data1);
                writer1.Flush();
                writer1.Close();

                HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
                StreamReader reader1 = new StreamReader(response1.GetResponseStream());

                XmlDocument doc1 = new XmlDocument();
                doc1.Load(reader1);
                XmlNodeList node4 = doc1.GetElementsByTagName("usercontext");
                if (node4 != null)
                {
                    foreach (XmlNode n in node4)
                    {
                        success = n.ParentNode.Attributes["success"].Value;
                        webserver = n.Attributes["webserver"].Value;
                        token = n.InnerText;
                    }


                }

                if (success == "1")  //extract user context
                {

                    //  send user context  as first child in ppmdmsg 
                   // getAuth.Add(webserver + "/xmlrpc/processrequest.asp");


                    XmlDocument doc2 = new XmlDocument();
                    XmlElement usercontext = doc2.CreateElement("usercontext");

                    foreach (XmlNode n in node4)
                    {
                        foreach (XmlAttribute attr in n.Attributes)
                        {
                            usercontext.SetAttribute(attr.Name, attr.Value);

                        }

                    }

                    usercontext.InnerText = token;  //token


                    // Use usercontext while making API calls
                    
                    getAuth.Add(usercontext.Clone());


                }


            }
            return getAuth;

        }

        public string CheckPatientID(XmlNode usercontext, string url ,string dateofbirth)
        {

            Uri uri2 = new Uri(url);
            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
            request2.Method = "POST";
            request2.ContentType = "text/xml";
            request2.CookieContainer = new CookieContainer();
            XmlTextWriter writer2 = new
            XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
            writer2.Namespaces = false;
            XmlDocument doc2 = new XmlDocument();

            XmlElement ppmdmsg = (XmlElement)doc2.AppendChild(doc2.CreateElement("ppmdmsg"));

            ppmdmsg.SetAttribute("action", "lookuppatient");
            ppmdmsg.SetAttribute("class", "api");

            ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
            ppmdmsg.SetAttribute("nocookie", "1");
            ppmdmsg.SetAttribute("exactmatch", "-1");
            ppmdmsg.SetAttribute("page", "1");

            DateTime mydate = new DateTime();
            DateTimeFormatInfo us = new CultureInfo("en-US", false).DateTimeFormat;
            mydate = DateTime.ParseExact(dateofbirth, "yyyy-MM-dd", null);
            string dob = mydate.ToString("MM/dd/yyyy");
            ppmdmsg.SetAttribute("dob", dob);
            XmlNode importNode = ppmdmsg.OwnerDocument.ImportNode(usercontext, true);
            ppmdmsg.AppendChild(importNode);
            writer2.WriteRaw(doc2.InnerXml);
            writer2.Flush();
            writer2.Close();


            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument getid = new XmlDocument();
            getid.Load(reader2);
            string id = "";
            XmlNodeList patid = getid.GetElementsByTagName("patient");
            if (patid != null)
            {
                foreach (XmlNode i in patid)
                {
                    id = i.Attributes["id"].Value;

                }

                return id;
            }

            return null;
        }

        public string CheckPatientEmail(XmlNode usercontext,string url,string id)
        {
            string email = "";
            Uri uri2 = new Uri(url);
             HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
            request2.Method = "POST";
            request2.ContentType = "text/xml";
            request2.CookieContainer = new CookieContainer();
            XmlTextWriter writer2 = new
            XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
            writer2.Namespaces = false;
            XmlDocument doc3 = new XmlDocument();
            XmlElement ppmdmsg = (XmlElement)doc3.AppendChild(doc3.CreateElement("ppmdmsg"));
            ppmdmsg = (XmlElement)doc3.AppendChild(doc3.CreateElement("ppmdmsg"));

            ppmdmsg.SetAttribute("action", "getdemographic");
            ppmdmsg.SetAttribute("class", "demographics");

            ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
            ppmdmsg.SetAttribute("nocookie", "1");
            ppmdmsg.SetAttribute("patientid", id);


            XmlNode importNode = ppmdmsg.OwnerDocument.ImportNode(usercontext, true);
            ppmdmsg.AppendChild(importNode);
            writer2.WriteRaw(doc3.InnerXml);
            writer2.Flush();
            writer2.Close();
            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument getemail = new XmlDocument();
            getemail.Load(reader2);

            XmlNodeList emailadd = getemail.GetElementsByTagName("patient");

            if (emailadd != null)
            {
                foreach (XmlNode em in emailadd)
                {
                    foreach (XmlNode childNode in em.ChildNodes)
                    {
                        if (childNode.Name == "contactinfo")
                        {

                            email = childNode.Attributes["email"].Value;
                        }
                    }
                }

                return email;
            }

            return null;

        }

        public string GetPass(string email)
        {

            return login.GetPass(email);

        }

        
    }
}
