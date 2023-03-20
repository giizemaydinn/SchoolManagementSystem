using Core.Entities;

namespace Entities.Dtos.Student
{
    public class AddLessonToStudentDto : IDto
    {
        public int LessonId { get; set; }
        public int StudentId { get; set; }
    }
}
