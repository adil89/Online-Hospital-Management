using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Doctors;
using System.Net;
using System.IO;
using System.Xml;
using System.Globalization;
namespace BLL.Doctors
{
    public class PatientsQueueBLL
    {

       PatientsQueueDAL faa = new PatientsQueueDAL();


        public List<GetPatientsInQueue_Result> GetQueue(int providerID)
        {
            List<GetPatientsInQueue_Result> gfaa = faa.GetQueue(providerID);

            return gfaa;
        }

        public void acceptAppointment(int patientID, string appTime, string appDate, int ProviderID, string appType, string reason)
        {
            
            faa.acceptAppointmet(patientID, appTime, appDate, ProviderID, appType, reason);

        }

        public void SaveAppointmentAdvancedMD(XmlNode usercontext, string url, int patientID, string appTime, string appDate, int ProviderID, string appType, string reason)
        {
            var colid = faa.getColumn(ProviderID);
            var apptid = "";
            Uri uri2 = new Uri(url);                        //last returned URL

            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
            request2.Method = "POST";
            request2.ContentType = "text/xml";
            request2.CookieContainer = new CookieContainer();
            XmlTextWriter writer2 = new
            XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
            writer2.Namespaces = false;
            XmlDocument doc2 = new XmlDocument();
            XmlElement ppmdmsg = (XmlElement)doc2.AppendChild(doc2.CreateElement("ppmdmsg"));

            ppmdmsg.SetAttribute("action", "addnew");
            ppmdmsg.SetAttribute("class", "scheduler");
            XmlElement ppmdappt = doc2.CreateElement("ppmd", "appt", "ppmd:appt");

            ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
            ppmdmsg.SetAttribute("nocookie", "1");

            DateTime mydate = new DateTime();
            DateTimeFormatInfo us = new CultureInfo("en-US", false).DateTimeFormat;
            mydate = DateTime.ParseExact(appDate, "yyyy-MM-dd", null);
            string dob = mydate.ToString("MM/dd/yyyy");

            ppmdappt.SetAttribute("xmlns:ppmd", "www.perfectpractice.md");
            ppmdappt.SetAttribute("patient", "pat" + patientID.ToString());
            ppmdappt.SetAttribute("date", dob);

            ppmdappt.SetAttribute("types", "ap_type9");
            ppmdappt.SetAttribute("duration", "15");
            ppmdappt.SetAttribute("profile", "prof" + ProviderID.ToString());
            ppmdappt.SetAttribute("time", appTime);

            ppmdappt.SetAttribute("column", "col" + colid);
            XmlNode importNode = ppmdmsg.OwnerDocument.ImportNode(usercontext, true);
            ppmdmsg.AppendChild(ppmdappt);
            ppmdmsg.AppendChild(importNode);
            ppmdappt.InnerText = reason;
            writer2.WriteRaw(doc2.InnerXml);
            writer2.Flush();
            writer2.Close();

            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument SaveApptmt = new XmlDocument();
            SaveApptmt.Load(reader2);

            //ExtractAppointmentID here

            XmlNodeList apptlist = SaveApptmt.GetElementsByTagName("ppmd:appt");
            if (apptlist != null)
            {

                foreach (XmlNode appt in apptlist)
                {
                    apptid = appt.Attributes["id"].Value.Substring(4); //Now map this id with pendingAppt id and store it at your end 

                }

            }

        }
    }
}
