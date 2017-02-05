using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using BLL;
using BLL.Patients;
using drchrono.PropertyClasses;

namespace drchrono.Patients
{
    public partial class MyDocuments : System.Web.UI.Page
    {
        BLLMyDocuments _myDoc = new BLLMyDocuments();

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            //string description = txtDescription.Text;
            if (FileUploadControl.HasFile)
            {
                try
                {
                    UTF8Encoding utf8 = new UTF8Encoding();
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    Stream inputStream = FileUploadControl.FileContent;


                    StreamReader stream = new StreamReader(inputStream);
                    string x = stream.ReadToEnd();
                    string xml = HttpUtility.UrlDecode(x);

                    byte[] b1 = System.Text.Encoding.UTF8.GetBytes(xml);

                    string UTF8 = System.Convert.ToBase64String(b1);
                    XmlNode n = Session["usercontext"] as XmlNode;
                    _myDoc.UploadDocument(name, n, Session["url"].ToString(),
                        Session["patientid"].ToString(), UTF8, filename);
                    StatusLabel.Text = "Upload status: File uploaded!";

                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " +
                                       ex.Message;
                }
            }
        }

        [WebMethod(EnableSession = true)]
        public static object GetAllDocument(int jtStartIndex, int jtPageSize)
        {

            MyDocuments my = new MyDocuments();
            List<Documents> doc = my.GetAllDocument2();

            return new {Result = "OK", Records = doc, TotalRecordCount = doc.Count};
        }

        private List<Documents> GetAllDocument2()
        {
            XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
            string url = HttpContext.Current.Session["url"].ToString();
            string patientId = HttpContext.Current.Session["patientid"].ToString();
            List<Documents> doc = _myDoc.GetAllDocuments(patientId, url, n);
            return doc;
        }

        [WebMethod(EnableSession = true)]
        public static object DeleteFile(int FileId)
        {
            MyDocuments my = new MyDocuments();
            my.DeleteFileBLL(FileId);


            return new {Result = "OK"};
        }

        private void DeleteFileBLL(int fileId)
        {
            XmlNode usercontext = HttpContext.Current.Session["usercontext"] as XmlNode;
            string url = HttpContext.Current.Session["url"].ToString();
            _myDoc.DeleteFile(fileId, usercontext, url);
        }

        [WebMethod(EnableSession = true)]
        public static void downloadAttachment(string FileId)
        {
            try
            {

                HttpContext context = HttpContext.Current;

                MyDocuments my = new MyDocuments();
                string patientId = HttpContext.Current.Session["patientid"].ToString();

                Documents doc = my.DownloadFilePrivate(Convert.ToInt32(FileId));
                string utf8Message = doc.Message;
                string fileName = doc.Name + patientId;
                string filePath = context.Server.MapPath("~/DownloadedFiles/") ; 

                File.WriteAllBytes(filePath + fileName, Convert.FromBase64String(utf8Message));

                my.FileName(1,fileName);

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        [WebMethod(EnableSession = true)]
        public static void delFile()
        {
            MyDocuments my = new MyDocuments();

            my.deleteFile();
        }

        private void deleteFile()
        {
            string fName = (string)Session["fileName"];
            string filePath = HttpContext.Current.Server.MapPath("~/DownloadedFiles/");
           
            if(File.Exists(filePath + fName))
            {
                File.Delete(filePath + fName);
            }
        }


        public string FileName(int i,string fileName = "")
        {

            if (i == 1)
            {
                
               // HttpContext.Current.Session["fileName"] = fileName;
                Session.Add("fileName", fileName);
                return "";
            }
            else
            {
              
                fileName = Session["fileName"].ToString();

                return fileName;
            }
        }

        private string GetPath(string halfPath)
        {

            string path = Server.MapPath(halfPath);
            return path;
        }

        private Documents DownloadFilePrivate(int fileId)
        {
            Documents doc = new Documents();

            XmlNode n = HttpContext.Current.Session["usercontext"] as XmlNode;
            string url = HttpContext.Current.Session["url"].ToString();
            string utf8Message = _myDoc.DownloadFile(fileId, n, url);
            string fileName = _myDoc.getFileName(fileId, n, url);

            doc.Name = fileName;
            doc.Message = utf8Message;

            return doc;
        }

    }
}