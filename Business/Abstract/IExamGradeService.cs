using Core.Utilities.Responses;
using Entities.Concrete;
using Entities.Dtos.ExamGrade;

namespace Business.Abstract
{
    public interface IExamGradeService
    {
        Task<IDataResponse<IEnumerable<ExamGradeDetailDto>>> GetAll();
        Task<IDataResponse<ExamGrade>> GetById(int examGradeId);
        Task<IResponse> Add(AddExamGradeDto addExamGradeDto);
        Task<IResponse> Delete(int id);
        Task<IResponse> Update(ExamGrade examGrade);
    }
}
