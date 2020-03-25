using System;

public class Json
{
    public string CourseName { get; set; }
    public string TeacherName { get; set; }
    public DateTime CourseDateOfStart { get; set; }
    public int HomeworkThreshold { get; set; }
    public int PresenceThreshold { get; set; }
    public string TextPresence { get; set; }
    public string TextHomework { get; set; }
    public string[] PresenceList { get; set; }
    public string[] HomeworkList { get; set; }
}
