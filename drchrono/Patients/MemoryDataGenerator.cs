using System;
using System.Collections.Generic;
using System.Text;
using Hik.JTable.Models;
using drchrono.Patients;

namespace Hik.JTable.Repositories.Memory
{
    public class MemoryDataGenerator
    {
        private readonly Random _rnd = new Random();

        public MemoryDataSource Generate(int studentCount)
        {
            var dataSource = new MemoryDataSource();

            //BASE DATA
            var personNames = GeneratePersonNames();
      
           
            //PEOPLE ALLERGY
            dataSource.People.AddRange(
                new List<Person>
                {
                 
                    //Get Allergy here 
                    
                    new Person {AllergyId = 1, Allergies="FUCK", Reaction="drastic",Status="OK"},
                    
                
               
                });
            //People Medication
            dataSource.PeopleMedication.AddRange(

             new List<PersonMedication>
                {
                 
                    //Get Medication here 
                    
                    new PersonMedication {MedicationId = 1, Medication="FUCKMEDICATION",frequency="drastic",dose="1000",Prescribed="OK"},
                    
                
                });

            return dataSource;
        }

        
        private static PersonNameSurname[] GeneratePersonNames()
        {
            return new[]
                             {
                                 new PersonNameSurname {Name = "Halil", Surname = "Kalkan", Gender = "M"},
                                 new PersonNameSurname {Name = "Karen", Surname = "Asimov", Gender = "F"},
                                 new PersonNameSurname {Name = "Neo", Surname = "Gates", Gender = "M"},
                                 new PersonNameSurname {Name = "Trinity", Surname = "Lafore", Gender = "F"},
                                 new PersonNameSurname {Name = "Morpheus", Surname = "Maalouf", Gender = "M"},
                                 new PersonNameSurname {Name = "Suzanne", Surname = "Hayyam", Gender = "F"},
                                 new PersonNameSurname {Name = "Georghe", Surname = "Richards", Gender = "M"},
                                 new PersonNameSurname {Name = "Steeve", Surname = "Orwell", Gender = "M"},
                                 new PersonNameSurname {Name = "Agatha", Surname = "Jobs", Gender = "F"},
                                 new PersonNameSurname {Name = "Stephan", Surname = "Christie", Gender = "M"},
                                 new PersonNameSurname {Name = "Andrew", Surname = "Hawking", Gender = "M"},
                                 new PersonNameSurname {Name = "Nicole", Surname = "Brown", Gender = "F"},
                                 new PersonNameSurname {Name = "Thomas", Surname = "Garder", Gender = "M"},
                                 new PersonNameSurname {Name = "Oktay", Surname = "More", Gender = "M"},
                                 new PersonNameSurname {Name = "Paulho", Surname = "Anar", Gender = "M"},
                                 new PersonNameSurname {Name = "Carl", Surname = "Sagan", Gender = "M"},
                                 new PersonNameSurname {Name = "Daniel", Surname = "Radcliffe", Gender = "F"},
                                 new PersonNameSurname {Name = "Rupert", Surname = "Grint", Gender = "M"},
                                 new PersonNameSurname {Name = "David", Surname = "Yates", Gender = "M"},
                                 new PersonNameSurname {Name = "Hercules", Surname = "Poirot", Gender = "M"},
                                 new PersonNameSurname {Name = "Christopher", Surname = "Paolini", Gender = "M"},
                                 new PersonNameSurname {Name = "Walter", Surname = "Isaacson", Gender = "M"},
                                 new PersonNameSurname {Name = "Arda", Surname = "Turan", Gender = "M"},
                                 new PersonNameSurname {Name = "Jeniffer", Surname = "Anderson", Gender = "F"},
                                 new PersonNameSurname {Name = "Stephenie", Surname = "Mayer", Gender = "F"},
                                 new PersonNameSurname {Name = "Dan", Surname = "Brown", Gender = "M"},
                                 new PersonNameSurname {Name = "Clara", Surname = "Clayton", Gender = "F"},
                                 new PersonNameSurname {Name = "Emmett", Surname = "Brown", Gender = "M"},
                                 new PersonNameSurname {Name = "Marty", Surname = "Mcfly", Gender = "M"},
                                 new PersonNameSurname {Name = "Jane", Surname = "Fuller", Gender = "F"},
                                 new PersonNameSurname {Name = "Douglas", Surname = "Hall", Gender = "M"},
                                 new PersonNameSurname {Name = "Tom", Surname = "Jones", Gender = "M"},
                                 new PersonNameSurname {Name = "Lora", Surname = "Adams", Gender = "F"},
                                 new PersonNameSurname {Name = "Andy", Surname = "Garcia", Gender = "M"},
                                 new PersonNameSurname {Name = "Amin", Surname = "Collins", Gender = "M"},
                                 new PersonNameSurname {Name = "Elmander", Surname = "Sokrates", Gender = "M"},
                                 new PersonNameSurname {Name = "Austin", Surname = "Cleeve", Gender = "F"},
                                 new PersonNameSurname {Name = "Audrey", Surname = "Cole", Gender = "F"},
                                 new PersonNameSurname {Name = "Bella", Surname = "Clark", Gender = "F"},
                                 new PersonNameSurname {Name = "Burley", Surname = "Pugy", Gender = "M"},
                                 new PersonNameSurname {Name = "Charles", Surname = "Quiney", Gender = "M"}
                             };
        }

        
        private string GenerateRandomPhoneNumber()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sb.Append(_rnd.Next(0, 10).ToString());
            }

            return sb.ToString();
        }

        private class PersonNameSurname
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Gender { get; set; }
        }
    }
}
