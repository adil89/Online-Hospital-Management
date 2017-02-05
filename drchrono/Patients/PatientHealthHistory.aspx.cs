using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace drchrono
{
    public partial class PatientHealthHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["patientid"] == null)
            {

                Response.Redirect("Default.aspx");
            }

            if(!IsPostBack)
            {
                //Get Allergy

                XmlNode n = Session["usercontext"] as XmlNode;
                Uri uri2 = new Uri(Session["url"].ToString());                        //last returned URL

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
                    foreach (XmlNode allergy in record)
                    {

                        AllergyDropDownList.Items.Add(allergy.Attributes["description"].Value);
                    }
                }

               

                //GET MEDICATION

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
                if (record!=null)
                {
                foreach (XmlNode medication in record)
                {
                    MedicationDropDownList.Items.Add(medication.Attributes["description"].Value);

                }
                }

                //get Health problems   Error popping up here ??

                request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
                request2.Method = "POST";
                request2.ContentType = "text/xml";
                request2.CookieContainer = new CookieContainer();
                writer2 = new
                XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
                writer2.Namespaces = false;
                XmlDocument patienthealthhistory2 = new XmlDocument();
                ppmdmsg = (XmlElement)patienthealthhistory2.AppendChild(patienthealthhistory2.CreateElement("ppmdmsg"));
                ppmdmsg.SetAttribute("action", "selectclinicalproblem");
                ppmdmsg.SetAttribute("class", "masterfiles");
                ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
                ppmdmsg.SetAttribute("nocookie", "1");
                importNode = ppmdmsg.OwnerDocument.ImportNode(n, true);
                ppmdmsg.AppendChild(importNode);
                writer2.WriteRaw(patienthealthhistory2.InnerXml);
                writer2.Flush();
                writer2.Close();
                response2 = (HttpWebResponse)request2.GetResponse();
                reader2 = new StreamReader(response2.GetResponseStream());
                XmlDocument gethealthproblem = new XmlDocument();
                gethealthproblem.Load(reader2);
                record = gethealthproblem.GetElementsByTagName("record");
                if (record != null)
                {
                    foreach (XmlNode healthproblem in record)
                    {
                        HealthProblemDropDownList.Items.Add(healthproblem.Attributes["description"].Value);
                       
                    }
                }

            }

        }

        protected void HealthProblemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        protected void FamilyHistoryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void MedicationDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        protected void AllergyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}