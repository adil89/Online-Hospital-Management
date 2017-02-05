using System;

namespace Hik.JTable.Models
{
    public class Person
    {
        public int AllergyId { get; set; }

        public string Allergies { get; set; }

        public string Reaction { get; set; }

        public DateTime Since_when { get; set; }

        public string Status { get; set; }

        public Person()
        {
            //RecordDate = DateTime.Now;
        }
    }
}