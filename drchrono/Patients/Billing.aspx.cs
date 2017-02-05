using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using BLL.Patients;


namespace drchrono.Patients
{
    public partial class Billing : System.Web.UI.Page
    {
        BLLBill _myDemo = new BLLBill();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static object GetPatientDemographics()
        {
            
            Billing bill = new Billing();
            PropertyClasses.Patients patientInfo = bill.GetPatientDemographicsPrivate();

            return new { patientInfo };
        }

        [WebMethod(EnableSession = true)]
        public static object VerifyCreditCard(string cardNum,string month,string year,string zip)
        {

            Billing bill = new Billing();
            string verifyCc = bill.VerifyCreditCardPrivate(cardNum,month,year,zip);

            int verify = Convert.ToInt32(verifyCc);

            

            return new { verify };
        }

        private string VerifyCreditCardPrivate(string cardNum, string month, string year, string zip)
        {
            BLLBill bill = new BLLBill();
            XmlNode usercontext = HttpContext.Current.Session["usercontext"] as XmlNode;
            string url = HttpContext.Current.Session["url"].ToString();

            string verifyCc = bill.VerifyBill(cardNum, month, year, zip, usercontext, url);

            return verifyCc;
        }

        private PropertyClasses.Patients GetPatientDemographicsPrivate()
        {
            XmlNode usercontext = HttpContext.Current.Session["usercontext"] as XmlNode;
            string url = HttpContext.Current.Session["url"].ToString();
            string patientid = Session["patientid"].ToString();
            PropertyClasses.Patients pa =  _myDemo.GetDemographics(usercontext, url,patientid);
            
            return pa;
        }
    }
}