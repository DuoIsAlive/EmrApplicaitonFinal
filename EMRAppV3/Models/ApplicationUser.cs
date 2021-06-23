using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EMRAppV3.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public bool IsDoctor { get; set; }
        public ApplicationUser() { }
        public ICollection<FileOnDatabaseModel> FileOnDatabaseModels { get; set; }

        ////null for patient
        //public int? PatientId { get; set; }
        //public virtual Patient Patient { get; set;}

        //public int? DoctorId { get; set; }
        //public virtual Doctor Doctor { get; set; }





    }
}
