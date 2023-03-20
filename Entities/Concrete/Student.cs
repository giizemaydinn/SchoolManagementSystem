using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Student : User
    {
        public virtual Parent Parent { get; set; }
        public virtual ICollection<StudentTeacher> Teachers { get; set; }
        public virtual ICollection<StudentLesson> Lessons { get; set; }
        public virtual ICollection<ExamGrade> ExamGrades { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public Student()
        {
            Teachers = new HashSet<StudentTeacher>();
            Lessons = new HashSet<StudentLesson>();
            ExamGrades = new HashSet<ExamGrade>();
            Books = new HashSet<Book>();
        }
    }
}
