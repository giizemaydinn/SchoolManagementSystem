using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Teacher : User
    {
        public Lesson Lesson { get; set; } //++
        public ICollection<StudentTeacher> Students { get; set; }
        public Teacher() 
        {
            Students= new HashSet<StudentTeacher>();
        }
    }
}