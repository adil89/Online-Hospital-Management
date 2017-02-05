using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hik.JTable.Models;
using drchrono.Patients;

namespace Hik.JTable.Repositories.Memory
{
    public class MemoryPersonRepository : IPersonRepository
    {
        private readonly MemoryDataSource _dataSource;

        public MemoryPersonRepository(MemoryDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public List<Person> GetAllPeople()
        {
            return _dataSource.People.OrderBy(p => p.Allergies).ToList();
        }


        public List<PersonMedication> GetAllPeopleMedication()
        {
            return _dataSource.PeopleMedication.OrderBy(p => p.MedicationId).ToList();
        }


        public Person AddPerson(Person person)
        {
            person.AllergyId = _dataSource.People.Count > 0 ? (_dataSource.People[_dataSource.People.Count - 1].AllergyId + 1) : 1;
            _dataSource.People.Add(person);
            return person;
        }

        public PersonMedication AddPersonMedication(PersonMedication person)
        {
            person.MedicationId = _dataSource.PeopleMedication.Count > 0 ? (_dataSource.PeopleMedication[_dataSource.PeopleMedication.Count - 1].MedicationId + 1) : 1;
            _dataSource.PeopleMedication.Add(person);
            return person;
        }

        public void UpdatePerson(Person person)
        {
            var foundPerson = _dataSource.People.Find(p => p.AllergyId == person.AllergyId);
            if (foundPerson == null)
            {
                return;
            }

            foundPerson.Allergies = person.Allergies;
            foundPerson.Reaction = person.Reaction;
            foundPerson.Since_when = person.Since_when;
            foundPerson.Status = person.Status;
        }

        public void UpdatePersonMedication(PersonMedication person)
        {
            var foundPerson = _dataSource.PeopleMedication.Find(p => p.MedicationId == person.MedicationId);
            if (foundPerson == null)
            {
                return;
            }

            foundPerson.Medication = person.Medication;
            foundPerson.dose = person.dose;
            foundPerson.Since = person.Since;
            foundPerson.Prescribed = person.Prescribed;
            foundPerson.frequency = person.frequency;
        }

        public void DeletePerson(int AllergyId)
        {
            _dataSource.People.RemoveAll(person => person.AllergyId == AllergyId);
        }

        public void DeletePersonMedication(int MedicationId)
        {
            _dataSource.PeopleMedication.RemoveAll(person => person.MedicationId == MedicationId);
        }

        public Object GetAllAllergies()
        {

          return _dataSource.Al.Select(c => new { DisplayText = c.name, Value = c.id }).OrderBy(s => s.DisplayText);
        }
        public Object GetAllMedication()
        {

            return _dataSource.Med.Select(c => new { DisplayText = c.name, Value = c.id }).OrderBy(s => s.DisplayText);
        }
    }
}
