using Entities.Dtos.User;

namespace Entities.Dtos.Student
{
    public class AddStudentDto : UserForRegisterDto
    {
        public int ParentId { get; set; }

    }
}
