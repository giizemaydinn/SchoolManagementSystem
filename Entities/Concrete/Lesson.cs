using Core.Entities;

namespace Entities.Concrete
{
    public class Lesson : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StudentLesson> Students { get; set; } 
        public virtual ICollection<Teacher> Teachers { get; set; } 
        public virtual ICollection<ExamGrade> ExamGrades { get; set; } 

        public Lesson()
        {
            Students = new HashSet<StudentLesson>();
            Teachers= new HashSet<Teacher>();
            ExamGrades= new HashSet<ExamGrade>();
        }

    }
}