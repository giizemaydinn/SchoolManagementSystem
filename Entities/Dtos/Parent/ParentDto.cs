using Entities.Dtos.Student;
using Entities.Dtos.User;

namespace Entities.Dtos.Parent
{
    public class ParentDto : UserDto
    {
        public ICollection<StudentDto> Students { get; set; }
    }
}
