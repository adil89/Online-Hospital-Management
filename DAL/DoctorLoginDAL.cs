using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL
{
    public class DoctorLoginDAL
    {
        drchronoEntities db = new drchronoEntities();
        public string EmailAddExists(string emailaddress)
        {

            try
            {
                var email = (from n in db.Doctorusers where n.Email == emailaddress select n.Email).Single();
                if (email == null)
                {

                    return "0";
                }
                else
                {
                    return "1";
                }

            }

            catch (Exception)   //email address is not found in database
            {
                return "0";

            }
        }

        public void createDoctor(string state, string zip, string city, string title, string email, string pwd, string primaryspeciality, string boardcertified, string yearsinpractice, string npino, string statelicense, string otherlicense, string skype, string referredby, string gender, string lastname, string firstname, string dateofbirth, string address, string cellno)
        {
            try
            {
                Doctoruser doc = new Doctoruser();
                doc.zip = zip;
                doc.Address = address;
                doc.BoardCertified = boardcertified;
                doc.cellno = cellno;
                doc.city = city;
                doc.dob = dateofbirth;
                doc.Email = email;
                doc.firstname = firstname;
                doc.gender = gender;
                doc.lastname = lastname;
                doc.NPI_NO = npino;
                doc.otherLicense = otherlicense;
                doc.password = pwd;
                doc.PrimarySpeciality = primaryspeciality;
                doc.referredby = referredby;
                doc.Skype = skype;
                doc.state = state;
                doc.stateLicense = statelicense;
                doc.Title = title;
                doc.YearsInPractice = yearsinpractice;
                doc.isActive = "0";
                db.Doctorusers.Add(doc);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
            }
        }



        public string checkActiveDoctor(string email,string password) 
        {
            try
            {

           
                var activeStatus =   (from n in db.Doctorusers where n.Email == email && n.password == password select n.isActive).Single();
                return activeStatus;    
            }
                           
            catch(Exception) //Exception can come if userid and password donot match or if user not found in local DB
            {
                return "1";
            }
        }
    }
}