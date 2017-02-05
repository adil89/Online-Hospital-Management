using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DAL
{
   public class PatientAppointmentsDAL
    {
        drchronoEntities db = new drchronoEntities();
        public string getLastRefreshedTime()
        {
            try
            {
                var refreshdate = (from n in db.AvailableColumnTimes select n.LastRefreshDate).Single();
                return refreshdate;
            }

            catch(Exception)
            {

                return "";
            }

        }
       public void populateBookedTable(string col, string time,string date)

        {
           
            BookedTime booked = new BookedTime();
          
            booked.ApptColumn = col;
            booked.ApptTime = time;
            DateTime mydate = new DateTime();
            DateTimeFormatInfo us = new CultureInfo("en-US", false).DateTimeFormat;
            mydate = DateTime.ParseExact(date, "MM/dd/yyyy", null);
            booked.apptDate = mydate;
            db.BookedTimes.Add(booked);
            db.SaveChanges();





        }

       public void PopulateAvailableColumnTime(string col, string time)
       {
           AvailableColumnTime column = new AvailableColumnTime();
           column.ApptColumn = col;
           column.ApptTime = time;
           column.LastRefreshDate = DateTime.Now.ToString();
           db.AvailableColumnTimes.Add(column);
           db.SaveChanges();

       }

       public List<BookedAppts> getDistinctBookedTime(string date)
       {

           List<BookedAppts> booked = new List<BookedAppts>();
           DateTime mydate = new DateTime();
           DateTimeFormatInfo us = new CultureInfo("en-US", false).DateTimeFormat;
           mydate = DateTime.ParseExact(date, "yyyy-MM-dd", null);

           var results = (from n in db.BookedTimes where n.apptDate == mydate select new { n.ApptColumn, n.ApptTime }).Distinct().ToList();
           foreach(var i in results)
           {

            BookedAppts bookedappts = new BookedAppts();
            bookedappts.ApptColumn =    i.ApptColumn;
            bookedappts.ApptTime =   i.ApptTime;
            booked.Add(bookedappts);
           
           }
           return booked;
         
       }
           public List<AllAppts> PopulateRoom()
       {

           List<AllAppts> allappts = new List<AllAppts>();
           var allrows = (from n in db.AvailableColumnTimes select new { n.ApptColumn, n.ApptTime }).ToList();
           foreach(var record in allrows)
           {
               AllAppts alltime = new AllAppts();
               alltime.ApptColumn = record.ApptColumn;
               alltime.ApptTime = record.ApptTime;
               allappts.Add(alltime);
              
           }
           return allappts;
           
       }


           public void SaveAppointmentLocalDB(int providerID,string patientid, string appointmenttime,string consultation, string date, string comments)
           {
               PendingAppointment pendingAppts = new PendingAppointment();
               pendingAppts.appDate = date;
               pendingAppts.appTime = appointmenttime;
               pendingAppts.appType = consultation;
               pendingAppts.patientID = patientid;
               pendingAppts.Reason = comments;
               pendingAppts.Status = "pending";
               pendingAppts.ProviderID = providerID;
               db.PendingAppointments.Add(pendingAppts);
               db.SaveChanges();

           }
   }
}
