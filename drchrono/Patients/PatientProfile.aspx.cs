using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using BLL;

namespace drchrono
{
    public partial class PatientProfile : System.Web.UI.Page
    {
        BLLPatientProfileHandler profile = new BLLPatientProfileHandler();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["patientid"] == null)
                {

                    Response.Redirect("Default.aspx");

                }
            }

          
            String patientName = "", dateOfBirth = "", genderKey = "", homeNumber = "", addressField = "", City = "", Zip = "", State = "",cellphone="";
            XmlNode n = Session["usercontext"] as XmlNode;
            List<string> patientload = new List<string>();                                        
            patientload = profile.LoadPatient(n,Session["url"].ToString(),Session["patientid"].ToString());
            patientName = patientload[0];
            dateOfBirth = patientload[1];
            genderKey = patientload[2];
            addressField = patientload[3];
            City = patientload[4];
            Session["city"] = City;
            Zip = patientload[5];
            Session["zip"] = Zip;
            State = patientload[6];
            Session["state"] = State;
            homeNumber = patientload[7];
            cellphone = patientload[8];



            string[] tokens = patientName.Split(',');
           if (tokens.Length == 1)
           {
               firstNameLabelValue.Text = tokens[0];
               Session["firstname"] = firstNameLabelValue.Text; 
               

           }
           else if (tokens.Length == 2)
           {
               string[] firstAndMiddle = tokens[1].Split(' ');
               if (firstAndMiddle.Length == 1)
               {
                   firstNameLabelValue.Text = tokens[1];
                   Session["firstname"] = firstNameLabelValue.Text; 
                   middleNamealue.Text = "";
                   Session["middlename"] = middleNamealue.Text;
               
               }
               else if (firstAndMiddle.Length == 2)
               {
                   firstNameLabelValue.Text = firstAndMiddle[0];
                   middleNamealue.Text = firstAndMiddle[1];
                   Session["middlename"] = middleNamealue.Text;
                   Session["firstname"] = firstNameLabelValue.Text; 
               
               }

               lastNameValue.Text = tokens[0];
               Session["lastname"] = lastNameValue.Text;
               
           }

           if (genderKey == "M")
           {
               genderLabelValue.Text = "Male";
               Session["gender"] = genderLabelValue.Text;
                          }
           else if (genderKey == "F")
           {
               genderLabelValue.Text = "Female";
               Session["gender"] = genderLabelValue.Text;
           
           }
            dateOfBirthLabelValue.Text = dateOfBirth;
            Session["dob"] = dateOfBirthLabelValue.Text;
            addressLabelValue.Text = addressField;
            Session["address"] = addressLabelValue.Text;
            zipLabelValue.Text = Zip;
            cityLabelValue.Text = City;
            stateLabelValue.Text = State;
            cellNumberLabelValue.Text = cellphone;
            Session["cellphone"] = cellNumberLabelValue.Text;
            homePhoneLabelValue.Text = homeNumber;
            Session["homenumber"] = homePhoneLabelValue.Text;
        }

       
      
    }
}