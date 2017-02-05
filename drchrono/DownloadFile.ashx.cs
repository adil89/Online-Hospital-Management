using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using drchrono.Patients;

namespace drchrono
{
    /// <summary>
    /// Summary description for DownloadFile
    /// </summary>
    public class DownloadFile : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        [WebMethod(EnableSession = true)]
        public void ProcessRequest(HttpContext context)
        {
           
            //MyDocuments doc = new MyDocuments();
     
            //string fname = HttpContext.Current.Session["fileName"].ToString();
            // string fileName = doc.FileName(0);  
            string fname = context.Session["fileName"].ToString();

            string filePath = context.Server.MapPath("DownloadedFiles/");

            context.Response.Clear();
            context.Response.ContentType = "application/octet-stream";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fname + ".txt" );
            context.Response.TransmitFile(filePath + fname);
            context.Response.End();

           

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}