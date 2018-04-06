using Newtonsoft.Json;
using System;

namespace WeeklyStatus_Prj
{
    internal class fields
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }
        [JsonProperty]
        public status Status { get; set; }
        [JsonProperty]
        public issuetype IssueType { get; set; }
        [JsonProperty]
        public assignee Assignee { get; set; }
        [JsonProperty]
        public creator Creator { get; set; }
        [JsonProperty]
        public reporter Reporter { get; set; }
        [JsonProperty]
        public priority Priority { get; set; }
        [JsonProperty]
        public DateTime created { get; set; }
        //[DataMember]
        //public string resolution { get; set; }
        [JsonProperty(PropertyName = "updated")]
        public DateTime Updated { get; set; }
        [JsonProperty(PropertyName = "duedate")]
        public string Duedate { get; set; }
        [JsonProperty(PropertyName = "timespent")]
        public string Timespent { get; set; }

        [JsonProperty(PropertyName = "customfield_13760")]
        public string[] Sprint { get; set; }

    }
}
