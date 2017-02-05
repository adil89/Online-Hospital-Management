using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace drchrono.Doctor
{
    public partial class DoctorRegister : System.Web.UI.Page
    {
        BLLDoctorLogin checkEmail = new BLLDoctorLogin();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod(EnableSession = true)]
        public static void Register(string primaryspeciality, string DocTitle, string board, string practiceyears, string NpiNo, string statelicenseno, string otherlicenseno, string skypeid, string referrer, string first, string last, string emailaddress, string password, string dob, string sex, string cell, string add)
        {


        
          

           DoctorRegister register = new DoctorRegister();
           register.CreateDoc(HttpContext.Current.Session["state"].ToString(), HttpContext.Current.Session["zip"].ToString(), HttpContext.Current.Session["city"].ToString(), primaryspeciality, DocTitle, board, practiceyears, NpiNo, statelicenseno, otherlicenseno, skypeid, referrer, first, last, emailaddress, password, dob, sex, HttpContext.Current.Session["areacode"].ToString() + cell, add);




        }

        public void CreateDoc(string state, string zip, string city,string primary,string DocTitle, string board, string practiceyears, string NpiNo, string statelicenseno, string otherlicenseno,string skypeid,string referrer, string first, string last, string emailaddress, string password, string dob, string sex, string cell, string add)
        {

           checkEmail.createDoctor(state,zip,city,DocTitle,emailaddress,password,primary,board,practiceyears,NpiNo,statelicenseno,otherlicenseno,skypeid,referrer,sex,last,first,dob,add,cell);
        }
        [WebMethod(EnableSession = true)]

        public static string EmailAddExist(string emailaddress)
        {



            DoctorRegister doctor = new DoctorRegister();
            return doctor.RegistercheckEmail(emailaddress);

        }
        public string RegistercheckEmail(string emailaddress)
        {

            return checkEmail.EmailAddExists(emailaddress);
        }
    }
}