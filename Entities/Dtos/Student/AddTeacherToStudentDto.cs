using Core.Entities;

namespace Entities.Dtos.Student
{
    public class AddTeacherToStudentDto : IDto
    {
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
    }
}
