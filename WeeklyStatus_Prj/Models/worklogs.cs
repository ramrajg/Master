using System;
using System.Runtime.Serialization;

namespace WeeklyStatus_Prj
{
    [DataContract]
    internal class worklogs
    {
        [DataMember]
        public string timeSpent { get; set; }
        [DataMember]
        public string comment { get; set; }
        [DataMember]
        public DateTime updated { get; set; }
        [DataMember]
        public DateTime started { get; set; }
    }
}
