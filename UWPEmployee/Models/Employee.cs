using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace UWPEmployee.Models
{
    [DataContract]
    public class RootObject
    {
        [DataMember]
        public int EmpNo { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public string EMedia { get; set; }

        [DataMember]
        public string FatherName { get; set; }

        [DataMember]
        public string MotherName { get; set; }

        [DataMember]
        public DateTime Dob { get; set; }

        [DataMember]
        public string Personalemail { get; set; }

        [DataMember]
        public string ProffesionalEmail { get; set; }

        [DataMember]
        public string MobileNum { get; set; }

        [DataMember]
        public string Department { get; set; }


        public string DepartmentImage { get; set; }

        public RootObject(string department)
        {
            Department = department;
            DepartmentImage = String.Format("/Assets/Logos/{0}.png",department);
            
        }

    }
}
