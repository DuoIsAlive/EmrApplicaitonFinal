using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMRAppV3.Models
{
    public class FileOnDatabaseModel
    {

        public int Id { get; set; }
        public byte[] Data { get; set; }
        public DateTime CreatedOn { get; internal set; }
        public string FileType { get; internal set; }
        public string Extension { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser{ get; set; }

    }
}
