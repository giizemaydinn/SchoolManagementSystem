using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Responses;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Lesson;

namespace Business.Concrete
{
    public partial class LessonManager : ILessonService
    {
        ILessonDal _lessonDal;
        private IMapper _mapper;

        public LessonManager(ILessonDal lessonDal, IMapper mapper)
        {
            _lessonDal = lessonDal;
            _mapper = mapper;
        }

        [SecuredOperation("admin")]
        public async Task<IResponse> Add(AddLessonDto addLessonDto)
        {
            
            var lesson = _mapper.Map<Lesson>(addLessonDto);

            await _lessonDal.Add(lesson);
            return new SuccessResponse(Messages.AddLesson, 200);

        }

        public async Task<IResponse> Delete(int id)
        {
            await _lessonDal.Delete(id);
            return new SuccessResponse("Ok", 200);
        }

        public async Task<IDataResponse<IEnumerable<LessonDto>>> GetAll()
        {
            var lesson = await _lessonDal.GetAll();
            var lessonDto = _mapper.Map<IEnumerable<LessonDto>>(lesson);

            return new SuccessDataResponse<IEnumerable<LessonDto>>(lessonDto, Messages.GetAllLesson, 200);
        }

        public async Task<IDataResponse<LessonDto>> GetById(int lessonId)
        {
            var lesson = await _lessonDal.Get(x => x.Id == lessonId);

            if (lesson != null)
            {
                var lessonDto = _mapper.Map<LessonDto>(lesson);
                return new SuccessDataResponse<LessonDto>(lessonDto, Messages.GetLesson, 200);
            }
            return new ErrorDataResponse<LessonDto>(Messages.GetLessonError, 404);
        }

        public async Task<IResponse> Update(LessonDto updateLessonDto)
        {
            IResponse result = await BusinessRules.Run(CheckIfLessonNameExists(updateLessonDto.Name));

            if (result != null)
            {
                return result;
            }

            var lesson = _mapper.Map<Lesson>(updateLessonDto);

            await _lessonDal.Update(lesson);

            return new SuccessResponse("Ok", 200);
        }

        
    }
}
