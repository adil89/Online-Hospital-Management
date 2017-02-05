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
    public class BLLBill
    {
        drchrono.PropertyClasses.Patients pa = new drchrono.PropertyClasses.Patients();
        public drchrono.PropertyClasses.Patients GetDemographics(XmlNode usercontext,string url,string patientid)
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
            XmlNodeList address = getDocuments.GetElementsByTagName("address");

             
            if (patient.Count > 0)
            {
                for (int i = 0; i < patient.Count; i++)
                {
                    for (int j = 0; j < patient[i].Attributes.Count; j++)
                    {
                        if (patient[i].Attributes[j].Name == "name")
                        {
                            pa.Name = patient[i].Attributes[j].Value;
                        }
                    }
                }
             }

            if (address.Count > 0)
            {
                for (int i = 0; i < address.Count; i++)
                {
                    for (int j = 0; j < address[i].Attributes.Count; j++)
                    {
                        if (address[i].Attributes[j].Name == "city")
                        {
                            pa.City = address[i].Attributes[j].Value;
                        }

                        if (address[i].Attributes[j].Name == "state")
                        {
                            pa.State = address[i].Attributes[j].Value;
                        }

                        if (address[i].Attributes[j].Name == "zip")
                        {
                            pa.Zip = address[i].Attributes[j].Value;
                        }
                    }
                }
            }

            return pa;
        }

        public string VerifyBill(string cardNum, string month, string year, string zip, XmlNode usercontext,string url)
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

            XmlElement ccrequest = doc2.CreateElement("ccrequest");

            XmlElement el = (XmlElement)doc2.AppendChild(doc2.CreateElement("ppmdmsg"));

            el.SetAttribute("action", "authorize");
            el.SetAttribute("class", "ppicreditcard");
            el.SetAttribute("nocookie", "1");

            ccrequest.SetAttribute("accountid", "1");
            ccrequest.SetAttribute("accountname", "LOCATION 1");
            ccrequest.SetAttribute("ccexpmonth", month);
            ccrequest.SetAttribute("ccexpyear", year);
            ccrequest.SetAttribute("type", "entered");
            ccrequest.SetAttribute("ccnumber", cardNum);
            ccrequest.SetAttribute("billzip", zip);

            el.AppendChild(ccrequest.Clone());

            XmlNode importNode = el.OwnerDocument.ImportNode(usercontext, true);
            el.AppendChild(importNode);
            writer2.WriteRaw(doc2.InnerXml);
            writer2.Flush();
            writer2.Close();

            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument getDocuments = new XmlDocument();

            getDocuments.Load(reader2);

            XmlNodeList ccresponse = getDocuments.GetElementsByTagName("ccresponse");

            string authorization = "";
            if (ccresponse.Count > 0)
            {
                for (int i = 0; i < ccresponse.Count; i++)
                {

                    for (int j = 0; j < ccresponse[i].Attributes.Count; j++)
                    {
                        if (ccresponse[i].Attributes[j].Name == "authorized")
                        {
                            authorization = ccresponse[i].Attributes[j].Value;
                            break;
                        }
                    }
                }
            }
            else
            {
                authorization = "0";
            }

            return authorization;
        }
    }
}
