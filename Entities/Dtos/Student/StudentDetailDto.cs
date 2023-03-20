using Entities.Dtos.ExamGrade;
using Entities.Dtos.Lesson;
using Entities.Dtos.Parent;
using Entities.Dtos.Teacher;
using Entities.Dtos.User;

namespace Entities.Dtos.Student
{
    public class StudentDetailDto : UserDto
    {
        public ParentDetailDto Parent { get; set; }
        public virtual ICollection<LessonDto> Lessons { get; set; }
        public virtual ICollection<TeacherDto> Teachers { get; set; }
        public virtual ICollection<ExamGradeForStudentDto> ExamGrades { get; set; }


    }
}
