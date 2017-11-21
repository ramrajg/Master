using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WeeklyStatus_Prj
{
 
    [DataContract]
    internal class reporter
    {
        [DataMember]
        public string key { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string emailAddress { get; set; }
        
    }
}
