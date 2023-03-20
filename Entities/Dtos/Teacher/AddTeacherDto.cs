using Entities.Dtos.User;

namespace Entities.Dtos.Teacher
{
    public class AddTeacherDto : UserForRegisterDto
    {
        public int LessonId { get; set; }
    }
}
