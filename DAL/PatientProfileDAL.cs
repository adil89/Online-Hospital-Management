using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL
{
    public class PatientProfileDAL
    {
        drchronoEntities db = new drchronoEntities();

           public string SendActivationEmail(string userId)
        {
            string activationcode = Guid.NewGuid().ToString();
            UserActivation useractive = new UserActivation();
            useractive.patientID = userId;
            useractive.ActivationCode = activationcode;
            db.UserActivations.Add(useractive);
            db.SaveChanges();
            return activationcode;
            

        }
        
       public void SavePatientLocalDB(string id,string email,string pass,string autolock)
       {

           loginuser user = new loginuser();
           user.patientID = id;
           user.Email = email;
           user.pass = pass;
           user.autolock = autolock;
           db.loginusers.Add(user);
           db.SaveChanges();

       }

        public string getEmail(string patientid)
       {

           var email = (from n in db.loginusers where n.patientID == patientid select n.Email).Single();
           return email;
       }

        public string getAutoLock(string patientid)
        {

           var autolock =  (from n in db.loginusers where n.patientID == patientid select n.autolock).Single();
           return autolock;
        }
   
    }
}
