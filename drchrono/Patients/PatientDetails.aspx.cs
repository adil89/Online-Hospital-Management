using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace drchrono
{
    public partial class PatientDetails : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {
          //check value of session here
            XmlNode n = Session["usercontext"] as XmlNode;
            




        }
    }
}