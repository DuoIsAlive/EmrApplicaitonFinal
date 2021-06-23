using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMRAppV3.Models
{
    public class MedicalInfo
    {
        public int Id { get; set; }
        public string ClinicRemarks { get; set; }
        public string Diagnosis { get; set; }
        public string Therapy { get; set; }
        public DateTime Date{ get; set; }
        public int PatientId { get; set; }
        public PatientInfo Patient { get; set; }

    }
}
