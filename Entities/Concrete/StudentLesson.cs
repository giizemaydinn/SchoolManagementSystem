using Core.Entities;

namespace Entities.Concrete
{
    public class StudentLesson : IEntity
    {
        public int StudentId { get; set; }
        public int LessonId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
