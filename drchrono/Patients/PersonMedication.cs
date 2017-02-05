using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace drchrono.Patients
{
    public class PersonMedication
    {

        public int MedicationId { get; set; }

        public string Medication { get; set; }

        public string dose { get; set; }
        public string frequency { get; set; }

        public DateTime Since { get; set; }

        public string Prescribed { get; set; }
    }
}