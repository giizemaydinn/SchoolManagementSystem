using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Parent : User 
    {
        public virtual ICollection<Student> Students { get; set; }
        public Parent()
        {
            Students = new HashSet<Student>();
        }

    }
}