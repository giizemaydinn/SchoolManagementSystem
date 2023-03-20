using Core.Entities;

namespace Entities.Dtos.Lesson
{
    public class LessonDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
