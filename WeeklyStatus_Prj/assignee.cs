using System.Runtime.Serialization;


namespace WeeklyStatus_Prj
{
    [DataContract]
    internal class assignee
    {
        [DataMember(Order = 1)]
        public string name = string.Empty;
        [DataMember]
        public string displayName = string.Empty;
    }
}
