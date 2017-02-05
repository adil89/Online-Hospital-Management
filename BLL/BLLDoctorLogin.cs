using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{  
    public class BLLDoctorLogin
    {
        DoctorLoginDAL login = new DoctorLoginDAL();
        public string EmailAddExists(string emailaddress)
        {

            return login.EmailAddExists(emailaddress);
        }

        public void createDoctor (string state,string zip,string city,string title,string email,string pwd,string primaryspeciality,string boardcertified,string yearsinpractice,string npino,string statelicense,string otherlicense,string skype,string referredby,string gender, string lastname, string firstname, string dateofbirth, string address, string cellno)
    {

        login.createDoctor(state, zip, city, title, email, pwd, primaryspeciality, boardcertified, yearsinpractice, npino, statelicense, otherlicense, skype, referredby, gender, lastname, firstname, dateofbirth, address, cellno);
            
    }

        public string checkActiveDoctor(string email,string password) //call here getproviderAPI if found return 1 else return 0
        {

            return login.checkActiveDoctor(email,password);
        }

       
    }
}
