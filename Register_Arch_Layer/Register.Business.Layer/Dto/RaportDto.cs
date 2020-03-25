using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Business.Layer.Dto
{
    public class RaportDto
    {
        public string CourseName;
        public DateTime CourseDateOfStart;
        public string TeacherName;
        public int HomeworkThreshold;
        public int PresenceThreshold;

        public string TextPresence;
        public string TextHomework;
       public List<string> PresenceList = new List<string>();
        public List<string> HomeworkList = new List<string>();

        

    }
}
