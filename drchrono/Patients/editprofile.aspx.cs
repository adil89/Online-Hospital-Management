using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using BLL;
using System.Web.Services;
using drchrono.Patients;

namespace drchrono
{
    public partial class editprofile : System.Web.UI.Page
    {

        BLLPatientProfileHandler patientprofile = new BLLPatientProfileHandler();
        bool genderMale = false;
        bool genderFemale = false;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            
            {
               
                          
            }
        

           
        }
       [WebMethod(EnableSession = true)]
        public static void UpdatePatient(string first, string middle, string last, string dob, string sex, string cell,string home, string add, string zip, string citykey, string statekey)//update patient here
        {




          editprofile prof = new editprofile();
          XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
           prof.Update(n,HttpContext.Current.Session["url"].ToString(),first,middle,last,dob,sex,cell,home,add,zip,citykey,statekey);
            
                
          
            
        }

        public void Update(XmlNode n , string url, string first,string middle, string last,string dob,string sex,string cell,string home,string add,string zip,string citykey,string statekey)
        {

            if (first=="")
            {

                first = Session["firstname"].ToString();
            }

            if(middle=="")
            {

                middle = Session["middlename"].ToString();
            }

             if(last=="")
            {

                last = Session["lastname"].ToString();
            }

        /*     if(add=="")
            {

                add = Session["address"].ToString();
            }

             if(sex=="")
            {

                sex = Session["gender"].ToString();
            }

            /* if(dob=="")
            {

                dob = Session["dob"].ToString();
                
            }

             if(cell=="")
            {

                cell = Session["cellphone"].ToString();
            }

             if(home=="")
            {

                home = Session["homenumber"].ToString();
            }
             if(zip=="")
            {

                zip = Session["zip"].ToString();
            }

             if(citykey=="")
            {

                citykey = Session["city"].ToString();
            }

             if(statekey=="")
            {

                statekey = Session["state"].ToString();
            }*/

             
                 patientprofile.UpdatePatient(n, url, Session["patientid"].ToString(), first, middle, last, dob, sex, cell, home, add, zip, citykey, statekey);
             

        }

         [WebMethod(EnableSession = true)]
        public static List<string> LoadProfile()
        {
            List<string> editprof = new List<string>();
             editprof.Add(HttpContext.Current.Session["firstname"].ToString());
             editprof.Add(HttpContext.Current.Session["middlename"].ToString());
              editprof.Add(HttpContext.Current.Session["lastname"].ToString());
              editprof.Add(HttpContext.Current.Session["address"].ToString());
              editprof.Add(HttpContext.Current.Session["gender"].ToString());

              editprof.Add(DateTime.ParseExact(HttpContext.Current.Session["dob"].ToString(), "MM/dd/yyyy", null).ToString("yyyy-MM-dd"));
               editprof.Add(HttpContext.Current.Session["cellphone"].ToString());
               editprof.Add(HttpContext.Current.Session["homenumber"].ToString());
               editprof.Add(HttpContext.Current.Session["zip"].ToString());
               editprof.Add(HttpContext.Current.Session["city"].ToString());
               editprof.Add(HttpContext.Current.Session["state"].ToString());
               return editprof;
          

        }

      
      

    }
}