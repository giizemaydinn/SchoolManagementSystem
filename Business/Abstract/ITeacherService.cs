using Core.Utilities.Responses;
using Entities.Dtos.Teacher;

namespace Business.Abstract
{
    public interface ITeacherService
    {
        Task<IDataResponse<IEnumerable<TeacherDetailDto>>> GetAll();
        Task<IDataResponse<TeacherDetailDto>> GetById(int teacherId);
        Task<IResponse> Add(AddTeacherDto teacherAddDto);
        Task<IResponse> Delete(int id);
        Task<IResponse> Update(UpdateTeacherDto updateTeacherDto);
    }
}
