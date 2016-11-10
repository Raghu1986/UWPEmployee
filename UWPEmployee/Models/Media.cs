using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UWPEmployee.Models
{
    [DataContract]
    public class Media
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string MediaUri { get; set; }

        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public string SubCategory { get; set; }
    }
}
