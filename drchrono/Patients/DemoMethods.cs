using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Hik.JTable.Models;
using Hik.JTable.Repositories;
using Hik.JTable.Sessions;
using drchrono.Patients;
using System.Web.Script.Serialization;
using System.Xml;
using System.Net;
using System.Web;
using System.IO;


namespace jTableWithAspNetWebForms
{
    public static class DemoMethods
    {

        private static IRepositoryContainer _repository { get { return RepositorySesssion.GetRepository(); } }




        #region Person methods



        public static object PersonList()
        {
            try
            {
                List<Person> peopleList = _repository.PersonRepository.GetAllPeople();
                return new { Result = "OK", Records = peopleList };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public static object PersonMedicationList()
        {
            try
            {
                List<PersonMedication> peopleList = _repository.PersonRepository.GetAllPeopleMedication();
                return new { Result = "OK", Records = peopleList };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }


        public static object CreatePerson(Person record)
        {
            try
            {
            
                var addedPerson = _repository.PersonRepository.AddPerson(record);
                return new { Result = "OK", Record = addedPerson };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public static object CreatePersonMedication(PersonMedication record)
        {
            try
            {

                var addedPerson = _repository.PersonRepository.AddPersonMedication(record);
                return new { Result = "OK", Record = addedPerson };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public static object DeletePerson(int AllergyId)
        {
            try
            {
                _repository.PersonRepository.DeletePerson(AllergyId);
                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public static object DeletePersonMedication(int MedicationId)
        {
            try
            {
                _repository.PersonRepository.DeletePersonMedication(MedicationId);
                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public static object UpdatePerson(Person record)
        {
            try
            {
                _repository.PersonRepository.UpdatePerson(record);
                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public static object UpdatePersonMedication(PersonMedication record)
        {
            try
            {
                _repository.PersonRepository.UpdatePersonMedication(record);
                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }


        public static Object PopulateAllergy()
        {


            try
            {
               var allergy =  _repository.PersonRepository.GetAllAllergies();
               return new { Result = "OK", Options = allergy};
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }

       


        }

        public static Object PopulateMedication()
        {


            try
            {
                var medication = _repository.PersonRepository.GetAllMedication();
                return new { Result = "OK", Options = medication };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }




        }

        #endregion

    }
}