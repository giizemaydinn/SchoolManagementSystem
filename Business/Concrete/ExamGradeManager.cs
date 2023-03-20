using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Responses;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.ExamGrade;

namespace Business.Concrete
{
    public class ExamGradeManager : IExamGradeService
    {
        IExamGradeDal _examGradeDal;
        private IMapper _mapper;

        public ExamGradeManager(IExamGradeDal examGradeDal, IMapper mapper)
        {
            _examGradeDal = examGradeDal;
            _mapper = mapper;
        }
        public async Task<IResponse> Add(AddExamGradeDto addExamGradeDto)
        {
            
            var examGrade = _mapper.Map<ExamGrade>(addExamGradeDto);

            await _examGradeDal.Add(examGrade);
            return new SuccessResponse(Messages.AddExamGrade, 200);

        }

        public async Task<IResponse> Delete(int id)
        {
            await _examGradeDal.Delete(id);
            return new SuccessResponse("Ok", 200);
        }

        public async Task<IDataResponse<IEnumerable<ExamGradeDetailDto>>> GetAll()
        {
            var examGrades = await _examGradeDal.Include(null, x => x.Lesson, x => x.Student);

            var examGradeDto = _mapper.Map<IEnumerable<ExamGradeDetailDto>>(examGrades);

            return new SuccessDataResponse<IEnumerable<ExamGradeDetailDto>>(examGradeDto, Messages.GetAllExamGrade, 200);
        }

        public async Task<IDataResponse<ExamGrade>> GetById(int examGradeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IResponse> Update(ExamGrade examGrade)
        {
            throw new NotImplementedException();
        }

        
    }
}
