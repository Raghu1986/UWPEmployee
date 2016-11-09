using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UWPEmployee.Models
{
    [DataContract]
    public class Course
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CourseType { get; set; }

        [DataMember]
        public string LogoUri { get; set; }
    }
}
