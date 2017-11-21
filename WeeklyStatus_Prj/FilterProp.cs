using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyStatus_Prj
{
    [DataContract]
    internal class FilterKopf
    {
        [DataMember]
        public List<issues> Issues { get; set; }
        [DataMember]
        public List<worklogs> WorkLogs { get; set; }
    }

}
