using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WeeklyStatus_Prj
{
 
    [DataContract]
    internal class issues
    {
        [DataMember]
        public string key { get; set; }
        [DataMember]
        public fields Fields { get; set; }
       
    }
}
