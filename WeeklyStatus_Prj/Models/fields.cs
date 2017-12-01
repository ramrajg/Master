using System;
using System.Runtime.Serialization;

namespace WeeklyStatus_Prj
{
    internal class fields
    {
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string summary { get; set; }
        [DataMember]
        public status Status { get; set; }
        [DataMember]
        public issuetype IssueType { get; set; }
        [DataMember]
        public assignee Assignee { get; set; }
        [DataMember]
        public creator creator { get; set; }
        [DataMember]
        public reporter reporter { get; set; }
        [DataMember]
        public priority priority { get; set; }
        [DataMember]
        public DateTime created { get; set; }
        //[DataMember]
        //public string resolution { get; set; }
        [DataMember]
        public DateTime updated { get; set; }
        [DataMember]
        public string duedate { get; set; }
        [DataMember]
        public string timespent { get; set; }

    }
}
