using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using drchrono.PropertyClasses;

namespace BLL.Patients
{
    public class BLLMyDocuments
    {

        public void UploadDocument(string name, XmlNode usercontext, string url, string patientid,
            string UTF8, string filename, string description = "")
        {

            Uri uri2 = new Uri(url);

            HttpWebRequest request2 = (HttpWebRequest) WebRequest.Create(uri2.ToString());
            request2.Method = "POST";
            request2.ContentType = "text/xml";
            request2.CookieContainer = new CookieContainer();
            XmlTextWriter writer2 = new
                XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
            writer2.Namespaces = false;
            XmlDocument doc2 = new XmlDocument();

            XmlElement file = doc2.CreateElement("file");
            XmlElement docinfo = doc2.CreateElement("docinfo");
            XmlElement categorylist = doc2.CreateElement("categorylist");
            XmlElement category = doc2.CreateElement("category");
            XmlElement filecontents = doc2.CreateElement("filecontents");

            XmlElement el = (XmlElement) doc2.AppendChild(doc2.CreateElement("ppmdmsg"));

            el.SetAttribute("action", "uploadfile");
            el.SetAttribute("class", "files");
            el.SetAttribute("msgtime", DateTime.Now.ToString());
            el.SetAttribute("force", "1");
            el.SetAttribute("nocookie", "1");


            file.SetAttribute("filetype", "D");
            file.SetAttribute("id", "1483391980934");
            file.SetAttribute("patientid", patientid);
            file.SetAttribute("profileid", "prof3");
            file.SetAttribute("visitid", "");
            file.SetAttribute("zipmode", "2");
            file.SetAttribute("name", filename);
            file.SetAttribute("description", filename);
            file.SetAttribute("filename", filename);


            docinfo.SetAttribute("templatedescription", "");
            docinfo.SetAttribute("countchars", "2385");
            docinfo.SetAttribute("countcharswspaces", "2568");
            docinfo.SetAttribute("countwords", "207");
            docinfo.SetAttribute("countlines", "76");
            docinfo.SetAttribute("countparas", "24");
            docinfo.SetAttribute("countpages", "1");
            docinfo.SetAttribute("resourceid", "");

            category.SetAttribute("id", "25");
            category.SetAttribute("filegroupfid", "4");
            category.SetAttribute("code", "MIUNSP");
            category.SetAttribute("name", "Unspecified");
            category.SetAttribute("filetype", "0");
            category.SetAttribute("level", "0");
            category.SetAttribute("default", "1");
            category.SetAttribute("default", "1");

            filecontents.InnerText = UTF8;


            categorylist.AppendChild(category.Clone());

            file.AppendChild(docinfo.Clone());
            file.AppendChild(categorylist.Clone());
            file.AppendChild(filecontents.Clone());

            el.AppendChild(file.Clone());

            XmlNode importNode = el.OwnerDocument.ImportNode(usercontext, true);
            el.AppendChild(importNode);
            writer2.WriteRaw(doc2.InnerXml);
            writer2.Flush();
            writer2.Close();

            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument getDocuments = new XmlDocument();

            getDocuments.Load(reader2);
        }

        public List<Documents> GetAllDocuments(string patientId, string url, XmlNode usercontext)
        {
            List<Documents> docList = new List<Documents>();
            Uri uri2 = new Uri(url);

            HttpWebRequest request2 = (HttpWebRequest) WebRequest.Create(uri2.ToString());
            request2.Method = "POST";
            request2.ContentType = "text/xml";
            request2.CookieContainer = new CookieContainer();
            XmlTextWriter writer2 = new
                XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
            writer2.Namespaces = false;
            XmlDocument doc2 = new XmlDocument();

            XmlElement el = (XmlElement) doc2.AppendChild(doc2.CreateElement("ppmdmsg"));

            el.SetAttribute("action", "getfilelist");
            el.SetAttribute("class", "files");
            el.SetAttribute("patientid", patientId);
            el.SetAttribute("nocookie", "1");

            XmlNode importNode = el.OwnerDocument.ImportNode(usercontext, true);
            el.AppendChild(importNode);
            writer2.WriteRaw(doc2.InnerXml);
            writer2.Flush();
            writer2.Close();

            HttpWebResponse response2 = (HttpWebResponse) request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument getDocuments = new XmlDocument();

            getDocuments.Load(reader2);

            XmlNodeList result = getDocuments.GetElementsByTagName("Results");
            XmlNodeList fileList = getDocuments.GetElementsByTagName("file");


            

            if (fileList.Count > 0 && result.Count > 0)
            {
                for (int i = 0; i < fileList.Count; i++)
                {
                    Documents doc = new Documents();
                    for (int j = 0; j < fileList[i].Attributes.Count; j++)
                    {
                        if (fileList[i].Attributes[j].Name == "id")
                        {
                            doc.FileId = fileList[i].Attributes[j].Value;
                        }

                        if (fileList[i].Attributes[j].Name == "name")
                        {
                            doc.Name = fileList[i].Attributes[j].Value;
                        }

                        if (fileList[i].Attributes[j].Name == "createdat")
                        {
                            doc.Date = fileList[i].Attributes[j].Value;
                        }

                        if (fileList[i].Attributes[j].Name == "description")
                        {
                            doc.Document = fileList[i].Attributes[j].Value;
                        }
                                            }

                    docList.Add(doc);
                }
                
                

            }
            return docList;
        }

        
        public void DeleteFile(int fileId,XmlNode usercontext,string url)
        {
            Uri uri2 = new Uri(url);

            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
            request2.Method = "POST";
            request2.ContentType = "text/xml";
            request2.CookieContainer = new CookieContainer();
            XmlTextWriter writer2 = new
            XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
            writer2.Namespaces = false;
            XmlDocument doc2 = new XmlDocument();

            XmlElement el = (XmlElement)doc2.AppendChild(doc2.CreateElement("ppmdmsg"));

            el.SetAttribute("action", "deletefile");
            el.SetAttribute("class", "files");
            el.SetAttribute("fileid", fileId.ToString());
            el.SetAttribute("nocookie", "1");

            XmlNode importNode = el.OwnerDocument.ImportNode(usercontext, true);
            el.AppendChild(importNode);
            writer2.WriteRaw(doc2.InnerXml);
            writer2.Flush();
            writer2.Close();

            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument getDocuments = new XmlDocument();

            getDocuments.Load(reader2);
        }

        public string DownloadFile(int fileId, XmlNode usercontext, string url)
        {

            Uri uri2 = new Uri(url);

            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
            request2.Method = "POST";
            request2.ContentType = "text/xml";
            request2.CookieContainer = new CookieContainer();
            XmlTextWriter writer2 = new
            XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
            writer2.Namespaces = false;
            XmlDocument doc2 = new XmlDocument();

            XmlElement el = (XmlElement)doc2.AppendChild(doc2.CreateElement("ppmdmsg"));

            el.SetAttribute("action", "getfile");
            el.SetAttribute("class", "files");
            el.SetAttribute("fileid", fileId.ToString());
            el.SetAttribute("nocookie", "1");

            XmlNode importNode = el.OwnerDocument.ImportNode(usercontext, true);
            el.AppendChild(importNode);
            writer2.WriteRaw(doc2.InnerXml);
            writer2.Flush();
            writer2.Close();

            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument getDocuments = new XmlDocument();

            getDocuments.Load(reader2);

            string utf8Message = getDocuments.InnerText;

            return utf8Message;
        }

        public string getFileName(int fileId, XmlNode usercontext, string url)
        {
            List<Documents> docList = new List<Documents>();

            Uri uri2 = new Uri(url);

            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
            request2.Method = "POST";
            request2.ContentType = "text/xml";
            request2.CookieContainer = new CookieContainer();
            XmlTextWriter writer2 = new
            XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
            writer2.Namespaces = false;
            XmlDocument doc2 = new XmlDocument();

            XmlElement filelist = doc2.CreateElement("filelist");
            XmlElement file = doc2.CreateElement("file");

            XmlElement el = (XmlElement)doc2.AppendChild(doc2.CreateElement("ppmdmsg"));

            el.SetAttribute("action", "getfilelist");
            el.SetAttribute("class", "files");
            el.SetAttribute("nocookie", "1");

            file.SetAttribute("id", fileId.ToString());

            filelist.AppendChild(file.Clone());

            el.AppendChild(filelist.Clone());

            XmlNode importNode = el.OwnerDocument.ImportNode(usercontext, true);



            el.AppendChild(importNode);
            writer2.WriteRaw(doc2.InnerXml);
            writer2.Flush();
            writer2.Close();

            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());
            XmlDocument getDocuments = new XmlDocument();

            getDocuments.Load(reader2);

            XmlNodeList fileList = getDocuments.GetElementsByTagName("file");

            string name = "";
            if (fileList.Count > 0)
            {
                for (int i = 0; i < fileList.Count; i++)
                {
                    
                    for (int j = 0; j < fileList[i].Attributes.Count; j++)
                    {
                        if (fileList[i].Attributes[j].Name == "name")
                        {
                            name = fileList[i].Attributes[j].Value;
                            break;
                        }
                    }
                }
            }
            
            return name;
        }
    }
}
