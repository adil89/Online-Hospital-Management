using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DAL;
using DAL.Patients;

namespace BLL.Patients
{
    public class MyAppointmentsBLL
    {
        MyAppointmentsDAL mad = new MyAppointmentsDAL();
        public List<getAppointments_Result> GetAllUpcomingAppointments(string patientId)
        {
            List<getAppointments_Result> rec = mad.GetAllUpcomingAppointment(patientId);
            return rec;
        }

        public List<GetPastAppointments_Result> GetAllPastAppointments(XmlNode usercontext, string url, string patientid)
        {
            List<GetPastAppointments_Result> pa = mad.GetAllPastAppointments(patientid);


            string name = getPatientName(usercontext, url, patientid);

            for (int i = 0; i < pa.Count; i++)
            {
                pa[i].patientID = name;
            }   

            return pa;
        }

        private string getPatientName(XmlNode usercontext, string url, string patientid)
        {

            string Name = "";

            Uri uri2 = new Uri(url);

            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
            request2.Method = "POST";
            request2.ContentType = "text/xml";
            request2.CookieContainer = new CookieContainer();
            XmlTextWriter writer2 = new
            XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
            writer2.Namespaces = false;
            XmlDocument doc2 = new XmlDocument();

            XmlElement el = (XmlElement)doc2.AppendChild(doc2.CreateElement("ppmdmsg"));

            el.SetAttribute("action", "getpatientbasic");
            el.SetAttribute("class", "demographics");
            el.SetAttribute("patientid", patientid);
            el.SetAttribute("nocookie", "1");

            XmlNode importNode = el.OwnerDocument.ImportNode(usercontext, true);
            el.AppendChild(importNode);
            writer2.WriteRaw(doc2.InnerXml);
            writer2.Flush();
            writer2.Close();

            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument getDocuments = new XmlDocument();

            getDocuments.Load(reader2);

            XmlNodeList patient = getDocuments.GetElementsByTagName("patient");

            if (patient.Count > 0)
            {
                for (int i = 0; i < patient.Count; i++)
                {
                    for (int j = 0; j < patient[i].Attributes.Count; j++)
                    {
                        if (patient[i].Attributes[j].Name == "name")
                        {
                            Name = patient[i].Attributes[j].Value;
                        }
                    }
                }
            }


            return Name;
        }
    }
}
