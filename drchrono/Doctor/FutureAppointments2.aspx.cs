using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using drchrono.Patients;
using DAL;
using BLL.Doctors;

namespace drchrono.Doctor
{
    public partial class FutureAppointments2 : System.Web.UI.Page
    {
        MyFutureApointments mfa = new MyFutureApointments();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

         

        [WebMethod(EnableSession = true)]
        public static object GetMyFutureAppointments(int jtStartIndex, int jtPageSize)
        {
            FutureAppointments2 fa = new FutureAppointments2();
            List<GetMyFutureAppointments_Result> rec = fa.GetMyFutureAppointmentsPrivate();

            return new { Result = "OK", Records = rec, TotalRecordCount = rec.Count };
        }

        private List<GetMyFutureAppointments_Result> GetMyFutureAppointmentsPrivate()
        {
               int providerID = int.Parse(Session["providerid"].ToString());     //HttpContext.Current.Session["patientid"].ToString();
               List<GetMyFutureAppointments_Result> rec = mfa.GetMyFutureAppointments(providerID);

               return rec;
        }
    }
}