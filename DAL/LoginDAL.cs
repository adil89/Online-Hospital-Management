using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Objects;


namespace DAL
{
      public class LoginDAL
    {
          drchronoEntities db = new drchronoEntities();

        public string checkLoginCredentials(string username, string password)
        {
            var patientid = "";
            try
            {

                 patientid = (from n in db.loginusers where n.Email == username && n.pass == password select n.patientID).Single();
            }

            catch(Exception)
            {

                     return null;
            }
                
           
           
            return patientid;


        }


          public List<int>  CheckEmailActivation(string id)
          {

                  List<int> output = new List<int>();
                  int count = 0;
                  int twofactorauth=0; 
                  count  = (from n in db.UserActivations where n.patientID == id select n).Count();

                  twofactorauth = (from n in db.loginusers where n.patientID == id select n.TwoFactorAuth).Single();
                  output.Add(count);
                  output.Add(twofactorauth);
                  return output;

        

          }

          public void UserAccountActivated(string date, string time, string browser, string ip, string id)
          {
               accounthistory account = new accounthistory();
              account.lastlogintime = time;
              account.lastlogindate = date;
              account.ipaddress = ip;
              account.browser = browser;
              account.patientID=id;
              db.accounthistories.Add(account);
              db.SaveChanges();
              
             
              
            


          }

            public int ActivationURL(string activationcode)
          {

              var items = db.UserActivations.Where(x => x.ActivationCode == activationcode).ToList();
              foreach (var item in items)
              {
                  db.UserActivations.Remove(item);

              }

            
            return  db.SaveChanges();
                    
          }

            public string GetPass(string email)
            {

                var pass = (from n in db.loginusers where n.Email == email select n.pass).Single();
                return pass;

            }

          public string EmailAddExists(string emailaddress)
            {
              try
              { 
              var email =  (from n in db.loginusers where n.Email == emailaddress select n.Email).Single();
              if(email==null)
              {

                  return "0";
              }
              else
              {
                  return "1";
              }
              
              }

              catch(Exception)
              {
                  return "0";

              }
             

            }
    }
}
