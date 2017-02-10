using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace drchrono.Patients
{
    public partial class AccountActivity : System.Web.UI.Page
    {
        BLLAccountsHandler account = new BLLAccountsHandler();
        protected void Page_Load(object sender, EventArgs e)
        {

            


        }

        [WebMethod(EnableSession = true)]
        public static object GetAccountHistory(int jtStartIndex, int jtPageSize)
        {
            string patientId = HttpContext.Current.Session["patientid"].ToString();
            AccountActivity activity = new AccountActivity();
            List<accounthistory> rec = activity.GetAccountDetails(patientId);
         
            return new { Result = "OK", Records = rec, TotalRecordCount = rec.Count };
        }

        private List<accounthistory> GetAccountDetails(string patientid)
        {

            
           return  account.GetAccountHistory(patientid);

        }



    }
}