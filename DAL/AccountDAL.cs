using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAL
    {
        drchronoEntities db = new drchronoEntities();
         public void autolock(string patientid,string duration)
        {
            
            loginuser user  = (from n in db.loginusers where n.patientID == patientid select n).SingleOrDefault();
            
             if(duration !="20")
              {
                  user.autolock=duration;
                  db.SaveChanges();
              }
             else
             {
                user.autolock = duration; //Default time
                 db.SaveChanges();
             }

        }

        public string RecentLogin(string patientid)
         {

             var lastlogindate = (from p in db.accounthistories
                             where p.patientID == patientid
                             orderby p.lastlogindate descending
                             select p.lastlogindate).First();

             var lastlogin = (from p in db.accounthistories
                              where p.lastlogindate == lastlogindate
                              orderby p.lastlogintime descending
                              select p.lastlogintime).First();
           return lastlogin;
                  
         }

        public List<string> GetAccountDetailLocalDB(string patientid)
        {
            List<string> account = new List<string>();
            var Email = db.loginusers.Where(x => x.patientID == patientid).Select(x => x.Email).Single();
            var pass = db.loginusers.Where(x => x.patientID == patientid).Select(x => x.pass).Single();
            
                account.Add(Email);
                account.Add(pass);
            
            return account;

        }
        public void AutorizeDevice(string patientid)
        {

            device dev = new device();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {




                IPInterfaceProperties properties = adapter.GetIPProperties();
                sMacAddress = adapter.GetPhysicalAddress().ToString();

                //Insert in devices all the Mac Address
               
                dev.AuthorizedDevices = sMacAddress;
                dev.patientID = patientid;
                db.devices.Add(dev);
                db.SaveChanges();
           

            }

            
        }

        public void DeauthorizeDevice(string patientid)
        {
           

                //Here delete the entry from devices table
                    var items  = db.devices.Where (x=>x.patientID == patientid).ToList();
                       foreach (var item in items)
                       {
                           db.devices.Remove(item);
                           db.SaveChanges();
                           
                       }

             
                    
            
           

               

            }


        public string CheckPassword(string patientid)
        {
            var pass = (from n in db.loginusers where n.patientID == patientid select n.pass).Single();
            return pass;


        }

        public void ResetPassword(string patientid,string password)
        {
                loginuser result = (from p in db.loginusers
                               where p.patientID == patientid
                               select p).SingleOrDefault();

               result.pass = password;

               db.SaveChanges();



        }

        public List<accounthistory> GetAccountHistory(string patientid)
        {
            var records = (from p in db.accounthistories
                           where p.patientID == patientid orderby p.accountID descending
                           select p).ToList();
          
            return records;
        }

      

        }
    }
           
