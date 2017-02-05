using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace drchrono.Patients
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        BLLAccountsHandler account = new BLLAccountsHandler();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void reset_Click(object sender, EventArgs e)
        {
            var old = currpassTextBox.Text.ToString();
            var newpass = newpassTextBox.Text.ToString();
            var repeat = repeatnewpassTextBox.Text.ToString();
            var curr = "";
            
            curr = account.CheckPassword(Session["patientid"].ToString());


            if(newpass!=repeat)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Passwords donot match')", true);
            }

            else if (old=="" || newpass=="" || repeat == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill all the required fields')", true);

            }

            else if (old != curr)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The password you entered is incorrect')", true);


            }

            else //Update Password
            {
                account.ResetPassword(Session["patientid"].ToString(), newpass);
                Response.Redirect("../Default.aspx");
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Accountsettings.aspx");
        }
    }
}