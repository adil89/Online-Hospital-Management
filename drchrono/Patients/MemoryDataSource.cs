using System.Collections.Generic;
using Hik.JTable.Models;
using drchrono.Patients;
using System.Xml;
using System.Web;
using System;
using System.Net;
using System.IO;

namespace Hik.JTable.Repositories.Memory
{
    public class MemoryDataSource
    {
       
        public List<Person> People { get; private set; }
        public List<PersonMedication> PeopleMedication { get; private set; }
        public List<Allergy> Al { get; private set; }
        public List<medication> Med { get; private set; }
        int id { get; set; }

        public MemoryDataSource()
        {
            People = new List<Person>();
            PeopleMedication = new List<PersonMedication>();
            Al = new List<Allergy>();
            Med = new List<medication>();
            id = 0;
           
          
            //Allergies
            XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
            Uri uri2 = new Uri(HttpContext.Current.Session["url"].ToString());                        //last returned URL

            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
            request2.Method = "POST";
            request2.ContentType = "text/xml";
            request2.CookieContainer = new CookieContainer();
            XmlTextWriter writer2 = new
            XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
            writer2.Namespaces = false;
            XmlDocument patienthealthhistory = new XmlDocument();
            XmlElement ppmdmsg = (XmlElement)patienthealthhistory.AppendChild(patienthealthhistory.CreateElement("ppmdmsg"));
            ppmdmsg.SetAttribute("action", "selectallergy");
            ppmdmsg.SetAttribute("class", "masterfiles");
            ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
            ppmdmsg.SetAttribute("nocookie", "1");
            XmlNode importNode = ppmdmsg.OwnerDocument.ImportNode(n, true);
            ppmdmsg.AppendChild(importNode);
            writer2.WriteRaw(patienthealthhistory.InnerXml);
            writer2.Flush();
            writer2.Close();
            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument getallery = new XmlDocument();
            getallery.Load(reader2);
            XmlNodeList record = getallery.GetElementsByTagName("record");
            if (record != null)
            {
                foreach (XmlNode allergy in record)   //All alergies
                {
                    Allergy al = new Allergy();
                    id = id + 1;
                    al.id = this.id;
                    al.name = allergy.Attributes["description"].Value;
                    Al.Add(al);

                }
            }

           //Medication

            request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
            request2.Method = "POST";
            request2.ContentType = "text/xml";
            request2.CookieContainer = new CookieContainer();
            writer2 = new
            XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
            XmlDocument patienthealthhistory1 = new XmlDocument();
            ppmdmsg = (XmlElement)patienthealthhistory1.AppendChild(patienthealthhistory1.CreateElement("ppmdmsg"));
            ppmdmsg.SetAttribute("action", "selectmedication");
            ppmdmsg.SetAttribute("class", "masterfiles");
            ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
            ppmdmsg.SetAttribute("nocookie", "1");
            importNode = ppmdmsg.OwnerDocument.ImportNode(n, true);
            ppmdmsg.AppendChild(importNode);
            writer2.WriteRaw(patienthealthhistory1.InnerXml);
            writer2.Flush();
            writer2.Close();
            response2 = (HttpWebResponse)request2.GetResponse();
            reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument getmedication = new XmlDocument();
            getmedication.Load(reader2);
            record = getmedication.GetElementsByTagName("record");
            if (record != null)
            {
                foreach (XmlNode medication in record)
                {
                    medication m = new medication();
                    id = id + 1;
                    m.id = this.id;
                    m.name = medication.Attributes["description"].Value;
                    Med.Add(m);

                }
            }

         
        }
    }
}
