using System.Runtime.Serialization;

namespace WeeklyStatus_Prj
{
    [DataContract]
    internal class issuetype
    {
        [DataMember]
        public string name = string.Empty;
        [DataMember]
        public string subtask = string.Empty;
    }
}
