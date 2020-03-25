using Register.Data.Layer.Interfaces;

namespace Register.Data.Layer.Models
{
    public class Homework : IEntity
    {
        public int Id { get; set; }
        public int MaxPoints { get; set; }
        public int StudentPoints { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }

    }
}