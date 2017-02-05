using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using BLL;

namespace drchrono.Patients
{
    public partial class Accountsettings : System.Web.UI.Page
    {

        BLLAccountsHandler account = new BLLAccountsHandler();
       
        Boolean emailrem = false;
        Boolean textmessagerem = false;
        Boolean bothrem = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack) //First Time page loads
            {

                   XmlNode n = Session["usercontext"] as XmlNode;
                   List<string> getAccount;
                   List<string> getAccountLocalDB;
                   getAccount = account.GetAccountDetails(n,Session["url"].ToString(),Session["patientid"].ToString());
                   getAccountLocalDB = account.GetAccountDetailLocalDB(Session["patientid"].ToString());    
                   linkedEmailAddress.Text = getAccountLocalDB[0];
                   password.Text = getAccountLocalDB[1];
                   username.Text =  getAccount[0];
                   linkedPhoneNo.Text = getAccount[1]; 
                   Session["homephone"] = getAccount[2]; 
                
              
                  login.Text = "Last Login: " + account.RecentLogin(Session["patientid"].ToString()); 
            }

        }

        protected void authorize_Click(object sender, EventArgs e)
        {


            account.AutorizeDevice(Session["patientid"].ToString());
        }

        protected void deauthorize_Click(object sender, EventArgs e)
        {
            account.DeauthorizeDevice(Session["patientid"].ToString());
          

        }
        protected void email_CheckedChanged(object sender, EventArgs e)
        {
            emailrem = true;
        }

        protected void TextMessage_CheckedChanged(object sender, EventArgs e)
        {
            textmessagerem = true;
        }

        protected void both_CheckedChanged(object sender, EventArgs e)
        {
            bothrem = true;
        }

        protected void saveaccountsettings_Click(object sender, EventArgs e)
        {

            XmlNode n = Session["usercontext"] as XmlNode;
            account.SaveReminders(emailrem,textmessagerem,bothrem,n,Session["url"].ToString(),Session["patientid"].ToString());
            try
            {
                account.autolock(Session["patientid"].ToString(), Session["autolock"].ToString());
            }

            catch(Exception)
            {
                account.autolock(Session["patientid"].ToString(), "20"); //set default to 20 if nothing is selected

            }
        }

        

     
        protected void autolockdropdownlist_SelectedIndexChanged(object sender, EventArgs e)
        {

           Session["autolock"] =  autolockdropdownlist.SelectedValue.ToString();
           
        }

       
        
    }
}