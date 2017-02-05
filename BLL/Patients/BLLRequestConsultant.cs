using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BLL.Patients
{
    public class BLLRequestConsultant
    {

        public void SaveReminder( string reminderType,XmlNode usercontext, string url,string patientid)
        {

                                                //last returned URL
                if (reminderType == "email")
                {
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
                    ppmdmsg.SetAttribute("action", "savepatientpreference");
                    ppmdmsg.SetAttribute("class", "messaging");
                    ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
                    ppmdmsg.SetAttribute("nocookie", "1");
                    ppmdmsg.SetAttribute("patientid", patientid);
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
                    HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                    StreamReader reader2 = new StreamReader(response2.GetResponseStream());
                    XmlDocument Reminder = new XmlDocument();
                    Reminder.Load(reader2);
                }
                else if (reminderType == "textmessage")
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
                    ppmdmsg.SetAttribute("patientid", patientid);
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
                    HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                    StreamReader reader2 = new StreamReader(response2.GetResponseStream());
                    XmlDocument Reminder = new XmlDocument();
                    Reminder.Load(reader2);

                }

                else if(reminderType == "both")
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
                    ppmdmsg.SetAttribute("patientid", patientid);
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
                    HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                    StreamReader reader2 = new StreamReader(response2.GetResponseStream());
                    XmlDocument Reminder = new XmlDocument();
                    Reminder.Load(reader2);

                }
        }
    }
}
