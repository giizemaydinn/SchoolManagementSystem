using Core.Entities;
using Entities.Dtos.Lesson;
using Entities.Dtos.Student;

namespace Entities.Dtos.ExamGrade
{
    public class ExamGradeDetailDto : IDto
    {
        public int Id { get; set; }
        public StudentDto Student { get; set; } 
        public LessonDto Lesson { get; set; } 
        public int Grade { get; set; }
    }
}
