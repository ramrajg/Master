using System.Runtime.Serialization;

namespace WeeklyStatus_Prj
{

    [DataContract]
    internal class searchUrlprop
    {
        [DataMember]
        public string searchUrl = string.Empty;
    }
}
