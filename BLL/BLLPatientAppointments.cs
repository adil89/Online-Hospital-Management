using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DAL;


namespace BLL
{
    public class BLLPatientAppointments
    {
        PatientAppointmentsDAL appointment = new PatientAppointmentsDAL();

        public void getAvailableTimeSlots(XmlNode usercontext, string url, string date)
        {

            var timeslot = "";
            var col = "";
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

            ppmdmsg.SetAttribute("action", "getappts");
            ppmdmsg.SetAttribute("class", "scheduler");

            ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
            ppmdmsg.SetAttribute("nocookie", "1");
            DateTime mydate = new DateTime();
            DateTimeFormatInfo us = new CultureInfo("en-US", false).DateTimeFormat;
            mydate = DateTime.ParseExact(date, "yyyy-MM-dd", null);
            string dob = mydate.ToString("MM/dd/yyyy");
            ppmdmsg.SetAttribute("date", dob);
            ppmdmsg.SetAttribute("view", "day");
            ppmdmsg.SetAttribute("columns", "col15 col16 col17 col18 col19 col20 col21 col22 col23 col24 col25");   
            XmlNode importNode = ppmdmsg.OwnerDocument.ImportNode(usercontext, true);
            ppmdmsg.AppendChild(importNode);
            writer2.WriteRaw(doc2.InnerXml);
            writer2.Flush();
            writer2.Close();

            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument getpatientID = new XmlDocument();
            getpatientID.Load(reader2);

            XmlNodeList apptlist = getpatientID.GetElementsByTagName("ppmd:appt");
            if (apptlist != null)
            {

                foreach (XmlNode appt in apptlist) 
                {


                    timeslot = appt.Attributes["time"].Value;
                    col = appt.Attributes["column"].Value;
                    appointment.populateBookedTable(col, timeslot,dob);

                }

            }


        }

            public string getLastRefreshedDate()
            {

               return appointment.getLastRefreshedTime();
            }

            public void PopulateAvailableColumnTime(string col, string time)
            {
                appointment.PopulateAvailableColumnTime(col, time);

            }
            public List<BookedAppts> getDistinctBookedTime(string date)
            {
                return  appointment.getDistinctBookedTime(date);
            }

                 public List<AllAppts> PopulateRoom()

         {
                    return appointment.PopulateRoom();

         
        
        }

                 public void SaveAppointmentLocalDB(XmlNode usercontext,string url ,string patientid, string appointmenttime,string consultation, string date, string comments,int[] fileIDs)
         
                     
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

             int clusterId = 0;
             if (fileIDs.Length > 0)
             {
                 clusterId = appointment.addDocuments(fileIDs);
             }


                     foreach(var id in ProviderID)
                     {

                         appointment.SaveAppointmentLocalDB(id, patientid, appointmenttime, consultation, date, comments, clusterId);
                     }
                 }

          
        }
    }
