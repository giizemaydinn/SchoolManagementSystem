using Core.Utilities.Responses;
using Entities.Concrete;
using Entities.Dtos.Lesson;

namespace Business.Abstract
{
    public interface ILessonService
    {
        Task<IDataResponse<IEnumerable<LessonDto>>> GetAll();
        Task<IDataResponse<LessonDto>> GetById(int lessonId);
        Task<IResponse> Add(AddLessonDto addLessonDto);
        Task<IResponse> Delete(int id);
        Task<IResponse> Update(LessonDto lesson);
    }
}
