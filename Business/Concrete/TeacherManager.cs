using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Responses;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Teacher;

namespace Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        ITeacherDal _teacherDal;
        private IMapper _mapper;

        public TeacherManager(ITeacherDal teacherDal, IMapper mapper)
        {
            _teacherDal = teacherDal;
            _mapper = mapper;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UserForRegisterDtoValidator))]
        public async Task<IResponse> Add(AddTeacherDto teacherAddDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(teacherAddDto.Password, out passwordHash, out passwordSalt);

            var teacher = _mapper.Map<Teacher>(teacherAddDto);

            teacher.PasswordSalt = passwordSalt;
            teacher.PasswordHash = passwordHash;

            await _teacherDal.Add(teacher);

            return new SuccessResponse(Messages.AddTeacher, 200);

        }

        public async Task<IResponse> Delete(int id)
        {
            await _teacherDal.Delete(id);
            return new SuccessResponse("Ok", 200);
        }

        public async Task<IDataResponse<IEnumerable<TeacherDetailDto>>> GetAll()
        {
            var teachers = await _teacherDal.Include(null, x=>x.Lesson);

            var teacherDto = _mapper.Map<IEnumerable<TeacherDetailDto>>(teachers);

            return new SuccessDataResponse<IEnumerable<TeacherDetailDto>>(teacherDto, Messages.GetAllTeacher, 200);
        }

        public async Task<IDataResponse<TeacherDetailDto>> GetById(int teacherId)
        {
            var teacher = await _teacherDal.Include(x => x.Id == teacherId, x => x.Lesson);

            if(teacher.Count() > 0)
            {
                var teacherDetailDto = _mapper.Map<IEnumerable<TeacherDetailDto>>(teacher).FirstOrDefault();
                return new SuccessDataResponse<TeacherDetailDto>(teacherDetailDto, Messages.GetTeacher, 200);
            }
            
            return new ErrorDataResponse<TeacherDetailDto>(Messages.GetTeacherError, 404);


        }

        public async Task<IResponse> Update(UpdateTeacherDto updateTeacherDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(updateTeacherDto.Password, out passwordHash, out passwordSalt);

            var teacher = _mapper.Map<Teacher>(updateTeacherDto);
            teacher.PasswordSalt = passwordSalt;
            teacher.PasswordHash = passwordHash;

            await _teacherDal.Update(teacher);

            return new SuccessResponse("Ok", 200);
        }

        
    }
}
