using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using HtmlAgilityPack;
using BLL;
using DAL;
using BLL.Doctors;
using BLL.Patients;
namespace drchrono
{
    public partial class MakeAppointment : System.Web.UI.Page
    {
        BLLPatientAppointments appointment = new BLLPatientAppointments();
        DoctorNowBLL doctorNow = new DoctorNowBLL();
        BLLRequestConsultant consultant = new BLLRequestConsultant();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {  
            
                
                
                //Run this code every 6 months

                   //write code for executing this code after every 6 months


              /*     var col=15;
                    while (col < 26)
                    {
                        var Availabletime = "";
                        var time = appointment.getLastRefreshedDate();
                        Uri uri2 = new Uri(Session["url"].ToString());                        //last returned URL
                        XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
                        HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
                        request2.Method = "POST";
                        request2.ContentType = "text/xml";
                        request2.CookieContainer = new CookieContainer();
                        XmlTextWriter writer2 = new
                        XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
                        writer2.Namespaces = false;
                        XmlDocument doc2 = new XmlDocument();
                        XmlElement ppmdmsg = (XmlElement)doc2.AppendChild(doc2.CreateElement("ppmdmsg"));

                        ppmdmsg.SetAttribute("action", "getgrid");
                        ppmdmsg.SetAttribute("class", "scheduler");

                        ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
                        ppmdmsg.SetAttribute("nocookie", "1");
                        ppmdmsg.SetAttribute("view", "day");
                        ppmdmsg.SetAttribute("columns", "col" + col.ToString());   //First find appointment of the given date in all columns
                        XmlNode importNode = ppmdmsg.OwnerDocument.ImportNode(n, true);
                        ppmdmsg.AppendChild(importNode);
                        writer2.WriteRaw(doc2.InnerXml);
                        writer2.Flush();
                        writer2.Close();
                        HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                        StreamReader reader2 = new StreamReader(response2.GetResponseStream());
                        HtmlDocument doc = new HtmlDocument();
                        doc.Load(reader2);
                        if (doc.DocumentNode != null)
                        {
                            foreach (HtmlNode th in doc.DocumentNode.SelectNodes("//th[@class='" + "apptgrid-th" + "']"))
                            {

                                Availabletime = th.InnerText; //From here you can get column time
                                if(Availabletime.Contains("A")) //AM
                                {


                                    Availabletime = Availabletime.Substring(0, Availabletime.Length - 1) + " " + "AM";
                                }

                                else //PM
                                {
                                    Availabletime = Availabletime.Substring(0, Availabletime.Length - 1) + " " + "PM";

                                }
                                    DateTime timeValue = Convert.ToDateTime(Availabletime);
                                string timeString24Hour = timeValue.ToString("HH:mm", CultureInfo.CurrentCulture);
                                appointment.PopulateAvailableColumnTime("col"+col.ToString(), timeString24Hour);

                            }

                            col = col + 1;
                        }
                    }*/
                   
                
            }

        }

            [WebMethod(EnableSession = true)]

            public static List<AvailableSlot> GetAvailableTimeSlots(string date)      
            {
                XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
                MakeAppointment consultant = new MakeAppointment();
                consultant.getAvailableTime(n, HttpContext.Current.Session["url"].ToString(), date);
                List<BookedAppts> DistinctRows = new List<BookedAppts>();
                List<AllAppts> alltime = new List<AllAppts>();
                DistinctRows = consultant.getDistinctTime(date);//get distinct booked time along with column on this particular date
                alltime = consultant.getAllRows(); //get all time along with rooms
                List<AvailableSlot> availableSlotList = new List<AvailableSlot>();
                
                var query = alltime.Where(p2 => !DistinctRows.Any(p1 => p1.ApptTime == p2.ApptTime && p1.ApptColumn == p2.ApptColumn)).ToList();
                foreach(var record in query)
                {
                    AvailableSlot availabletimeslot = new AvailableSlot();
                    availabletimeslot.ApptColumn = record.ApptColumn;
                    availabletimeslot.ApptTime = record.ApptTime;
                    availableSlotList.Add(availabletimeslot);
                   
                }
                return availableSlotList;

            }


        public void  getAvailableTime(XmlNode n , string url,string date)
        {
            appointment.getAvailableTimeSlots(n, url, date);

        }

        public List<BookedAppts> getDistinctTime(string date)
        {

               return appointment.getDistinctBookedTime(date);
        }

        [WebMethod(EnableSession = true)]
        public static List<AllAppts> PopulateDiv()
        {
            MakeAppointment consultant = new MakeAppointment();
            List<AllAppts> allrecords = new List<AllAppts>();
              allrecords  =  consultant.getAllRows();
              
            
             return allrecords;

        }

        public List<AllAppts>  getAllRows()
        {

           return appointment.PopulateRoom();
        }


        [WebMethod(EnableSession = true)]


        public static void GetSelectedRoomTime(string value)
        {
            var column = value.Split(',')[0];
            var time = value.Split(',')[1];
            HttpContext.Current.Session["ApptRoom"] =column;
            HttpContext.Current.Session["ApptTime"] = time;



        }


         [WebMethod(EnableSession = true)]
         

            public static void  SaveAppointmentLocalDB(int [] fileIDs)
        {
            MakeAppointment SaveAppt = new MakeAppointment();    
            XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
            SaveAppt.SaveAppts(n, HttpContext.Current.Session["url"].ToString(), HttpContext.Current.Session["patientid"].ToString(), HttpContext.Current.Session["ApptTime"].ToString(), HttpContext.Current.Session["consultation"].ToString(), HttpContext.Current.Session["date"].ToString(), HttpContext.Current.Session["comments"].ToString(), fileIDs);


        }

         public void SaveAppts(XmlNode usercontext, string url, string patientid, string time, string consultation, string date, string comments, int [] fileIDs)
                
       {
           appointment.SaveAppointmentLocalDB(usercontext, url, patientid, time, consultation, date, comments, fileIDs);
    
        }

          [WebMethod(EnableSession = true)]
        public static void SaveSeeDoctorNow()
         {

             string time = DateTime.Now.ToString(" HH:mm:ss.fff");
             string date = DateTime.Now.ToString("yyy-MM-dd");
             HttpContext.Current.Session["date"] = date;
             var showtime = Convert.ToDateTime(time);
             var showtimeString = showtime.ToString("HH:mm");
             HttpContext.Current.Session["ApptTime"] = showtimeString ;
             MakeAppointment SaveAppt = new MakeAppointment();
             XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
             try
             {
                 SaveAppt.SaveDoctorNow(n, HttpContext.Current.Session["url"].ToString(), int.Parse(HttpContext.Current.Session["patientid"].ToString().Substring(3)), time, HttpContext.Current.Session["consultation"].ToString(), HttpContext.Current.Session["date"].ToString(), HttpContext.Current.Session["comments"].ToString());
             }
              catch(Exception e)
             {

                 Console.WriteLine(e.InnerException);
             }
              }
        public void SaveDoctorNow(XmlNode usercontext, string url, int patientid, string time, string consultation, string date, string comments)
          {

              doctorNow.EmergencyRoom(usercontext, url, patientid,date, time, consultation,comments);
          }
   
           [WebMethod(EnableSession = true)]
        public static void SaveValues(string consultation,string appt,string date,string comments)
        {

            HttpContext.Current.Session["consultation"] = consultation;
            HttpContext.Current.Session["ApptType"] = appt;
            if (appt == "TakeAppointment")
            {
                   
                    HttpContext.Current.Session["date"] = date;
            }
            else
            {
                HttpContext.Current.Session["date"] = DateTime.Now.ToString("yyy-MM-dd");
                HttpContext.Current.Session["ApptTime"] = DateTime.Now.ToString("HH:mm");
            }

            HttpContext.Current.Session["comments"] = comments;
         

        }
         [WebMethod(EnableSession = true)]
        public static string  GetTypeAppt()
           {

               return HttpContext.Current.Session["ApptType"].ToString();

           }
         [WebMethod(EnableSession = true)]
        public static List<string> GetDateTime()
         {
             List<string> dateTime = new List<string>();
             dateTime.Add(HttpContext.Current.Session["date"].ToString());
             dateTime.Add(HttpContext.Current.Session["ApptTime"].ToString());
             return dateTime;

         }

          [WebMethod(EnableSession = true)]
         public static void SaveReminder(string reminderType)
          {

              XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
              string url = HttpContext.Current.Session["url"].ToString();
              MakeAppointment apptrem = new MakeAppointment();
              apptrem.SaveReminderAppts(reminderType, n, url, HttpContext.Current.Session["patientid"].ToString());

          }
          public void SaveReminderAppts(string reminderType, XmlNode usercontext, string url, string patientid)
          {
                        consultant.SaveReminder(reminderType,usercontext, url, patientid);

          }
       
    }
}