using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Xml;
using System.Net;
using System.Globalization;
using System.IO;
namespace BLL
{
    
   public class BLLPatientProfileHandler
    {
       PatientProfileDAL profile = new PatientProfileDAL();

       public string SendActivationEmail(string userId)
       {


          return  profile.SendActivationEmail(userId);
       }

       public string SavePatient(string gender,XmlNode usercontext,string areacode,string state,string zip,string city,string url ,string lastname, string firstname, string dateofbirth,string email, string cellno)

       {
           var id = "";
           Uri uri2 = new Uri(url);                        //last returned URL

           HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
           request2.Method = "POST";
           request2.ContentType = "text/xml";
           request2.CookieContainer = new CookieContainer();
           XmlTextWriter writer2 = new
           XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
           writer2.Namespaces = false;
           XmlDocument doc2 = new XmlDocument();

           XmlElement patientlist = doc2.CreateElement("patientlist");
           XmlElement patient = doc2.CreateElement("patient");
           XmlElement respparty = doc2.CreateElement("respparty");
           XmlElement resppartylist = doc2.CreateElement("resppartylist");

           XmlElement el = (XmlElement)doc2.AppendChild(doc2.CreateElement("ppmdmsg"));
           XmlElement address = doc2.CreateElement("address");
           XmlElement contactinfo = doc2.CreateElement("contactinfo");

           el.SetAttribute("action", "addpatient");
           el.SetAttribute("class", "demographics");

           el.SetAttribute("msgtime", DateTime.Now.ToString());
           el.SetAttribute("nocookie", "1");
           el.SetAttribute("force", "1");





           //Use usercontext while making API calls
           //Save password locally

           respparty.SetAttribute("name", "SELF");
           respparty.SetAttribute("accttype", "4");
           resppartylist.AppendChild(respparty.Clone());
           patient.SetAttribute("respparty", "SELF");
           patient.SetAttribute("relationship", "1");
           patient.SetAttribute("hipaarelationship", "18");
           patient.SetAttribute("chart", "AUTO");
           patient.SetAttribute("profile", "prof3");
           patient.SetAttribute("name", lastname + "," + firstname);


           //CultureInfo us = new CultureInfo("en-US", true);
           // yyyy-MM-dd (2016-10-06) recieved from text box
           DateTime mydate = new DateTime();
           DateTimeFormatInfo us = new CultureInfo("en-US", false).DateTimeFormat;
           mydate = DateTime.ParseExact(dateofbirth, "yyyy-MM-dd", null);
           string dob = mydate.ToString("MM/dd/yyyy");
           patient.SetAttribute("dob", dob);                                   //   mm/dd/yyyy (short format)

           patient.SetAttribute("insorder", "");
           patient.SetAttribute("deceased", "");
           patient.SetAttribute("fclass", "fclass16");
           patient.SetAttribute("additionalmrn", "");
           patient.SetAttribute("title", "");
           patient.SetAttribute("employer", "");
           patient.SetAttribute("maritalstatus", "");
           patient.SetAttribute("language", "");
           
           patient.SetAttribute("sex", gender);
           
           XmlNode importNode = el.OwnerDocument.ImportNode(usercontext, true);
           contactinfo.SetAttribute("email", email);
           contactinfo.SetAttribute("emailverificationstatus", "1");
           contactinfo.SetAttribute("homephone",cellno);
           contactinfo.SetAttribute("officephone", "");
           contactinfo.SetAttribute("officetext", "");
           contactinfo.SetAttribute("otherphone", "");
           contactinfo.SetAttribute("othertype", "");
           contactinfo.SetAttribute("preferredcommunicationfid", "");
           contactinfo.SetAttribute("confidentialcommunicationfid", "");
           contactinfo.SetAttribute("communicationnote", "");



           address.SetAttribute("address1", "");                    //change it
           address.SetAttribute("address2", "");
           address.SetAttribute("state", state);
           address.SetAttribute("zip", zip);
           address.SetAttribute("city", city);
           patient.AppendChild(address.Clone());
           patient.AppendChild(contactinfo.Clone());
           patientlist.AppendChild(patient.Clone());
           el.AppendChild(patientlist.Clone());
           el.AppendChild(resppartylist.Clone());
           el.AppendChild(importNode);
           writer2.WriteRaw(doc2.InnerXml);
           writer2.Flush();
           writer2.Close();


           HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
           StreamReader reader2 = new StreamReader(response2.GetResponseStream());
           XmlDocument getpatientID = new XmlDocument();
           getpatientID.Load(reader2);

           XmlNodeList patid = getpatientID.GetElementsByTagName("patient");
           if (patid != null)
           {
               foreach (XmlNode i in patid)
               {
                   id = i.Attributes["id"].Value;

               }

               return id;

           }

           return null;


       }

       public void SavePatientLocalDB(string id,string email,string pass,string autolock)
       {
           profile.SavePatientLocalDB(id, email, pass, autolock);

       }

       public void  UpdatePatient(XmlNode n,string url,string patientid,string first,string middle,string last,string dob,string sex,string cell,string home,string add,string zip,string citykey,string statekey)
       {
           HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(url);
           request2.Method = "POST";
           request2.ContentType = "text/xml";
           request2.CookieContainer = new CookieContainer();
           XmlTextWriter writer2 = new
           XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
           writer2.Namespaces = false;
           XmlDocument doc2 = new XmlDocument();

           XmlElement patientlist = doc2.CreateElement("patientlist");
           XmlElement patient = doc2.CreateElement("patient");

           XmlElement el = (XmlElement)doc2.AppendChild(doc2.CreateElement("ppmdmsg"));
           XmlElement address = doc2.CreateElement("address");
           XmlElement contactinfo = doc2.CreateElement("contactinfo");

           el.SetAttribute("action", "updatepatient");
           el.SetAttribute("class", "api");

           el.SetAttribute("msgtime", DateTime.Now.ToString());
           el.SetAttribute("nocookie", "1");
           el.SetAttribute("force", "1");





           //Use usercontext while making API calls
           //Save password locally

        
               if (middle == "")
               {
                   patient.SetAttribute("name", last + "," + first);
               }

               else
               {
                   patient.SetAttribute("name", last + "," + first + " " + middle);

               }
        
           //CultureInfo us = new CultureInfo("en-US", true);
           // yyyy-MM-dd (2016-10-06) recieved from text box
           if (dob != "")
           {
               DateTime mydate = new DateTime();
               DateTimeFormatInfo us = new CultureInfo("en-US", false).DateTimeFormat;
               mydate = DateTime.ParseExact(dob, "yyyy-MM-dd", null);
               string dob1 = mydate.ToString("MM/dd/yyyy");
               patient.SetAttribute("dob", dob1);                                   //   mm/dd/yyyy (short format)

           }



           patient.SetAttribute("id", patientid);

           if (sex == "Male")
           {

               patient.SetAttribute("sex", "M");
           }

           else 
           {

               patient.SetAttribute("sex", "F");
           }


           XmlNode importNode = el.OwnerDocument.ImportNode(n, true);






           if (cell != "")
           {
               contactinfo.SetAttribute("homephone", cell);
           }
           if (home != "")
           {
               contactinfo.SetAttribute("otherphone", home);
           }

          
           string a = "500 Lukonkierikka C 24 Yrttika";

           if (add.Length < a.Length && add!="")
           {
               address.SetAttribute("address1", add);
           }


           if (statekey != " ")
           {
               address.SetAttribute("state", statekey);
           }

           if (zip != "")
           {

               address.SetAttribute("zip", zip);
           }

           if (citykey != " ")
           {

               address.SetAttribute("city", citykey);
           }

           patient.AppendChild(address.Clone());
           patient.AppendChild(contactinfo.Clone());
           patientlist.AppendChild(patient.Clone());
           el.AppendChild(patientlist.Clone());
           el.AppendChild(importNode);
           writer2.WriteRaw(doc2.InnerXml);
           writer2.Flush();
           writer2.Close();


           HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
           StreamReader reader2 = new StreamReader(response2.GetResponseStream());
     
       }

       public string getEmail(string patientid)
       {

           return profile.getEmail(patientid);
       }

       public string getAutoLock(string patientid)
       {

           return profile.getAutoLock(patientid);
       }

       public List<string> LoadPatient(XmlNode usercontext, string url,string patientid)
       {

           List<string> patientinfo = new List<string>();
           Uri uri2 = new Uri(url);
           HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uri2.ToString());
           request2.Method = "POST";
           request2.ContentType = "text/xml";
           request2.CookieContainer = new CookieContainer();
           XmlTextWriter writer2 = new
           XmlTextWriter(request2.GetRequestStream(), System.Text.Encoding.UTF8);
           writer2.Namespaces = false;
           XmlDocument patientprofile = new XmlDocument();
           XmlElement ppmdmsg = (XmlElement)patientprofile.AppendChild(patientprofile.CreateElement("ppmdmsg"));
           ppmdmsg.SetAttribute("action", "getdemographic");
           ppmdmsg.SetAttribute("class", "api");
           ppmdmsg.SetAttribute("msgtime", DateTime.Now.ToString());
           ppmdmsg.SetAttribute("nocookie", "1");
           ppmdmsg.SetAttribute("patientid", patientid);


           XmlNode importNode = ppmdmsg.OwnerDocument.ImportNode(usercontext, true);
           ppmdmsg.AppendChild(importNode);
           writer2.WriteRaw(patientprofile.InnerXml);
           writer2.Flush();
           writer2.Close();


           HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
           StreamReader reader2 = new StreamReader(response2.GetResponseStream());
           XmlDocument getdemographics = new XmlDocument();
           getdemographics.Load(reader2);
           XmlNodeList nodeList = getdemographics.GetElementsByTagName("patient");
           if (nodeList != null)
           {
               foreach (XmlNode x in nodeList)
               {

                   patientinfo.Add( x.Attributes["name"].Value);
                   patientinfo.Add( x.Attributes["dob"].Value);
                   patientinfo.Add( x.Attributes["sex"].Value);
                   foreach (XmlNode childNode in x.ChildNodes)
                   {

                       if (childNode.Name == "address")
                       {
                           patientinfo.Add(  childNode.Attributes["address1"].Value);
                           patientinfo.Add(childNode.Attributes["city"].Value);
                           patientinfo.Add(childNode.Attributes["zip"].Value);
                           patientinfo.Add (childNode.Attributes["state"].Value);
                          
                       }
                       if (childNode.Name == "contactinfo")
                       {
                           patientinfo.Add(childNode.Attributes["homephone"].Value);
                           patientinfo.Add( childNode.Attributes["otherphone"].Value);
                          

                       }
                   }

               }
               return patientinfo;
           }


           return null;
        
       }

    }
}
