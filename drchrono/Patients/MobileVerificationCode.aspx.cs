using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace drchrono.Patients
{
    public partial class MobileVerificationCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MobileCodeButton_Click(object sender, EventArgs e)
        {
            //Here check whether the code is correct or not 
            Session["MobileCode"] = "1234";
            if (Session["MobileCode"].ToString() == MobileCode.Text.ToString())
            
            {

                Response.Redirect("PatientPortal.aspx");
            }

            else
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The code you entered is incorrect')", true);

            }
        }
    }
}