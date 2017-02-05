using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Doctors;
using System.Net;
using System.Xml;
using System.IO;
namespace BLL.Doctors
{
    public  class DoctorNowBLL
    {
        DoctorNowDAL SeeDoctorNow = new DoctorNowDAL();
         public void EmergencyRoom(XmlNode usercontext, string url,int patientid, string AppDate, string ApptTime, string ApptType, string Reason)
        {  
                Uri uri2 = new Uri(url);

            int count = 0;
            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
            request2.Method = "POST";
            request2.ContentType = "text/xml";
            request2.CookieContainer = new CookieContainer();
            XmlTextWriter writer2 = new
            XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
            writer2.Namespaces = false;
            XmlDocument doc2 = new XmlDocument();
            XmlElement ppmdmsg = (XmlElement)doc2.AppendChild(doc2.CreateElement("ppmdmsg"));

            ppmdmsg.SetAttribute("action", "lookupprofile");
            ppmdmsg.SetAttribute("class", "api");

            ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
            ppmdmsg.SetAttribute("nocookie", "1");
            XmlNode importNode = ppmdmsg.OwnerDocument.ImportNode(usercontext, true);
            ppmdmsg.AppendChild(importNode);
            writer2.WriteRaw(doc2.InnerXml);
            writer2.Flush();
            writer2.Close();
            List<int> ProviderID = new List<int>();
            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument profilelookup = new XmlDocument();
            profilelookup.Load(reader2);
            XmlNodeList profilecode = profilelookup.GetElementsByTagName("profile");
             if (profilecode != null)
             {
                 foreach (XmlNode code in profilecode)
                 {

                     count = count + 1;
                     if (count <= 11)
                     { 
                         var providerID = code.Attributes["id"].Value.Substring(4);
                         ProviderID.Add(int.Parse(providerID));
                         //Retrieve all the list of providers here 
                     }
                     }

            
             }

                     foreach(var id in ProviderID)
                     {

                              SeeDoctorNow.EmergencyRoom(patientid,id, AppDate, ApptTime, ApptType, Reason);
                     }
                 }


            
        }
    }

