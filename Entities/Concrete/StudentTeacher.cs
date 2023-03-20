using Core.Entities;

namespace Entities.Concrete
{
    public class StudentTeacher : IEntity
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}