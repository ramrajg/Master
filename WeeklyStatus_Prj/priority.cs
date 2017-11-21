using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WeeklyStatus_Prj
{

    [DataContract]
    internal class priority
    {
        [DataMember]
        public string name { get; set; }
    }
}
