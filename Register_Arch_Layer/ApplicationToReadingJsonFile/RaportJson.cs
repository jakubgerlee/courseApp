using System;
using System.Collections.Generic;


namespace ApplicationToReadingJsonFile
{
        public class RaportJson
        {
            public string CourseName { get; set; }
            public DateTime CourseDateOfStart { get; set; }
            public int HomeworkThreshold { get; set; }
            public int PresenceThreshold { get; set; }
            public string TextPresence { get; set; }
            public string TextHomework { get; set; }

            public List<string> PresenceList { get; set; }
            public List<string> HomeworkList { get; set; }
        
        }
}
