using Core.Entities;
using Entities.Dtos.Lesson;

namespace Entities.Dtos.ExamGrade
{
    public class ExamGradeForStudentDto : IDto
    {
        public int Id { get; set; }
        public LessonDto Lesson { get; set; } 
        public int Grade { get; set; }
    }
}
