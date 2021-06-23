using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace EMRAppV3.Models
{
    public class Patient 
    {
        [Key] [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        //1 to many Doctors
        public virtual ICollection<Doctor> Doctors { get; set; }
        

    }
}
