using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hik.JTable.Models;
using Hik.JTable.Repositories.Memory;
using System.Xml;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using drchrono.Patients;

namespace jTableWithAspNetWebForms
{
    public partial class SimplePeopleList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        [WebMethod(EnableSession = true)]
        public static object PersonList()
        {
            return DemoMethods.PersonList();
        }

        [WebMethod(EnableSession = true)]
        public static object PersonMedicationList()
        {
            return DemoMethods.PersonMedicationList();
        }

        [WebMethod(EnableSession = true)]
        public static object CreatePerson(Person record)
        {

            return DemoMethods.CreatePerson(record);
            
        }

        [WebMethod(EnableSession = true)]
        public static object CreatePersonMedication(PersonMedication record)
        {

            return DemoMethods.CreatePersonMedication(record);

        }

        [WebMethod(EnableSession = true)]
        public static object DeletePerson(int AllergyId)
        {
           
            return DemoMethods.DeletePerson(AllergyId);
        }

        [WebMethod(EnableSession = true)]
        public static object DeletePersonMedication(int MedicationId)
        {

            return DemoMethods.DeletePersonMedication(MedicationId);
        }


        [WebMethod(EnableSession = true)]
        public static object UpdatePerson(Person record)
        {
            return DemoMethods.UpdatePerson(record);
        }

        [WebMethod(EnableSession = true)]
        public static object UpdatePersonMedication(PersonMedication record)
        {
            return DemoMethods.UpdatePersonMedication(record);
        }


        [WebMethod(EnableSession = true)]
        public static Object PopulateAllergy()
        {
            return DemoMethods.PopulateAllergy();

        }

        [WebMethod(EnableSession = true)]
        public static Object PopulateMedication()
        {
            return DemoMethods.PopulateMedication();

        }
       

    
    }
}