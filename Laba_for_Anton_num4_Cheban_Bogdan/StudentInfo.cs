using System.Collections.Generic;

namespace Laba_for_Anton_num4_Cheban_Bogdan
{
    public class StudentInfo
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Cafedra { get; set; }
        public string Specialty { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public List<Facultet> Facultet { get; set; } = new List<Facultet>();
        
    }
}
