using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace drchrono.Patients
{
    public partial class Messaging : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        [WebMethod(EnableSession = true)]
     
        public static string GetRecievedMessages()
        {
          
          

                XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
                Uri uri2 = new Uri(HttpContext.Current.Session["url"].ToString());                        //last returned URL
                List<Messages> messagelist = new List<Messages>();     
   
                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
                request2.Method = "POST";
                request2.ContentType = "text/xml";
                request2.CookieContainer = new CookieContainer();
                XmlTextWriter writer2 = new
                XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
                writer2.Namespaces = false;
                XmlDocument patientprofile = new XmlDocument();
                XmlElement ppmdmsg = (XmlElement)patientprofile.AppendChild(patientprofile.CreateElement("ppmdmsg"));
                ppmdmsg.SetAttribute("action", "getmessagelist");
                ppmdmsg.SetAttribute("class", "messaging");
                ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
                ppmdmsg.SetAttribute("userid", "5337");
                ppmdmsg.SetAttribute("nocookie", "1");
                ppmdmsg.SetAttribute("patientfid", "126389"/*HttpContext.Current.Session["patientid"].ToString().Substring(HttpContext.Current.Session["patientid"].ToString().IndexOf("t")+1, HttpContext.Current.Session["patientid"].ToString().Length-1 - (HttpContext.Current.Session["patientid"].ToString().IndexOf("t")))*/);
                XmlNode importNode = ppmdmsg.OwnerDocument.ImportNode(n, true);
                ppmdmsg.AppendChild(importNode);
                writer2.WriteRaw(patientprofile.InnerXml);
                writer2.Flush();
                writer2.Close();
                HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                StreamReader reader2 = new StreamReader(response2.GetResponseStream());
                XmlDocument getallery = new XmlDocument();
                getallery.Load(reader2);
                XmlNodeList record = getallery.GetElementsByTagName("messagelist");
                XmlNodeList result = getallery.GetElementsByTagName("Results");
                var totalmessages="";
                foreach(XmlNode res in result)
                {
                 totalmessages =  res.Attributes["messagetotal"].Value;

                }
                if (record!=null && totalmessages !="0")
                {

                    foreach (XmlNode messagenode in record)
                    {

                        foreach (XmlNode childNode in messagenode.ChildNodes)
                        {

                            
                            //grab messages from here
                            Messages message = new Messages();
                            message.from = childNode.Attributes["tostaff"].Value;
                            message.Time = childNode.Attributes["routedatetime"].Value;
                            message.Subject = childNode.Attributes["actiontype"].Value;
                            message.body = childNode.Attributes["body"].Value;
                            messagelist.Add(message);
                        }
                    }
                }
                System.Web.Script.Serialization.JavaScriptSerializer jSearializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                string messageserialized = jSearializer.Serialize(messagelist);
                return messageserialized;

        }

        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static string GetSentMessages()
        {



            XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
            Uri uri2 = new Uri(HttpContext.Current.Session["url"].ToString());                        //last returned URL
            List<Messages> messagelist = new List<Messages>();

            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
            request2.Method = "POST";
            request2.ContentType = "text/xml";
            request2.CookieContainer = new CookieContainer();
            XmlTextWriter writer2 = new
            XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
            writer2.Namespaces = false;
            XmlDocument patientprofile = new XmlDocument();
            XmlElement ppmdmsg = (XmlElement)patientprofile.AppendChild(patientprofile.CreateElement("ppmdmsg"));
            ppmdmsg.SetAttribute("action", "getmessagelist");
            ppmdmsg.SetAttribute("class", "messaging");
            ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
            ppmdmsg.SetAttribute("userid", "5337");
            ppmdmsg.SetAttribute("nocookie", "1");
            ppmdmsg.SetAttribute("patientfid", "126389"/*HttpContext.Current.Session["patientid"].ToString().Substring(HttpContext.Current.Session["patientid"].ToString().IndexOf("t")+1, HttpContext.Current.Session["patientid"].ToString().Length-1 - (HttpContext.Current.Session["patientid"].ToString().IndexOf("t")))*/);
            XmlNode importNode = ppmdmsg.OwnerDocument.ImportNode(n, true);
            ppmdmsg.AppendChild(importNode);
            writer2.WriteRaw(patientprofile.InnerXml);
            writer2.Flush();
            writer2.Close();
            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument getallery = new XmlDocument();
            getallery.Load(reader2);
            XmlNodeList record = getallery.GetElementsByTagName("messagelist");
            XmlNodeList result = getallery.GetElementsByTagName("Results");
            var totalmessages = "";
            foreach (XmlNode res in result)
            {
                totalmessages = res.Attributes["messagetotal"].Value;

            }
            if (record != null && totalmessages != "0")
            {

                foreach (XmlNode messagenode in record)
                {

                    foreach (XmlNode childNode in messagenode.ChildNodes)
                    {


                        //grab messages from here
                        Messages message = new Messages();
                        message.from = childNode.Attributes["tostaff"].Value;
                        message.Time = childNode.Attributes["routedatetime"].Value;
                        message.Subject = childNode.Attributes["actiontype"].Value;
                        messagelist.Add(message);
                    }
                }
            }
            System.Web.Script.Serialization.JavaScriptSerializer jSearializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            string messageserialized = jSearializer.Serialize(messagelist);
            return messageserialized;

        }

        

       
    }
}