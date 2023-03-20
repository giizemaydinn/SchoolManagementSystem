using Entities.Dtos.Lesson;
using Entities.Dtos.User;

namespace Entities.Dtos.Teacher
{
    public class TeacherDetailDto : UserDto
    {
        public LessonDto Lesson { get; set; }
    }
}
