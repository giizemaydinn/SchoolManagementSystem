using Core.Utilities.Responses;
using Entities.Dtos.Student;

namespace Business.Abstract
{
    public interface IStudentService
    {
        Task<IDataResponse<IEnumerable<StudentDetailDto>>> GetAll();
        Task<IDataResponse<StudentDetailDto>> GetById(int studentId);
        Task<IResponse> Add(AddStudentDto studentAddDto);
        Task<IResponse> Delete(int id);
        Task<IResponse> Update(UpdateStudentDto updateStudentDto);
        Task<IResponse> AddLessonToStudent(AddLessonToStudentDto addLessonToStudentDto);
        Task<IResponse> AddTeacherToStudent(AddTeacherToStudentDto addTeacherToStudentDto);

    }
}
