using System.Collections.Generic;
using Hik.JTable.Models;
using drchrono.Patients;

namespace Hik.JTable.Repositories
{
    public interface IPersonRepository
    {
        List<Person> GetAllPeople();
        Person AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(int AllergyId);

        List<PersonMedication> GetAllPeopleMedication();
        PersonMedication AddPersonMedication(PersonMedication person);
        void UpdatePersonMedication(PersonMedication person);
        void DeletePersonMedication(int MedicationId);
        
        object GetAllAllergies();
        object GetAllMedication();
    }
}
