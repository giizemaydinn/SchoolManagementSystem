using Core.Entities;

namespace Entities.Dtos.ExamGrade
{
    public class AddExamGradeDto : IDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public int Grade { get; set; }
    }
}
