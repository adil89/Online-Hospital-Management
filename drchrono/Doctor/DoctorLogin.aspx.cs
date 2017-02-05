using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace drchrono
{
    public partial class DoctorLogin : System.Web.UI.Page
    {

        BLLDoctorLogin doc = new BLLDoctorLogin();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void patientsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

        protected void organizationsButton_Click(object sender, EventArgs e)
        {

        }

        protected void aboutUsButton_Click(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e) 
        {

            var active =   doc.checkActiveDoctor(userTextbox.Text, passwordTextbox.Text);
            if (active == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your account has not yet been activated')", true);

            }
            else
            {
                if (userTextbox.Text == "BABBIT, CASEY")
                {
                    Session["providerid"] = "18";
                    Response.Redirect("DoctorPortal.aspx");

                }

                else if(userTextbox.Text=="ADAMS, CASEY")
                {
                    Session["providerid"] = "17";
                    Response.Redirect("DoctorPortal.aspx");


                }
            }
        }

       
    }
}