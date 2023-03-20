using Core.Entities;

namespace Entities.Concrete
{
    public class ExamGrade : IEntity
    {
        public int Id { get; set; }
        public Student Student { get; set; } //++
        public Lesson Lesson { get; set; } //++
        public int Grade { get; set;}
    }
}