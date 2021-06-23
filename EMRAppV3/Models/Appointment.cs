using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMRAppV3.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
        public int PatientId { get; set; }
        //public Patient MyProperty { get; set; }
        public int DoctorId { get; set; }
        //public Doctor Doctor { get; set; }

    }
}
