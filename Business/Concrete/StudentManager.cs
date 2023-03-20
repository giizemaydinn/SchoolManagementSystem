using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Responses;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Student;

namespace Business.Concrete
{
    public partial class StudentManager : IStudentService
    {
        IStudentDal _studentDal;
        IParentService _parentService;
        IStudentLessonDal _studentLessonDal;
        IStudentTeacherDal _studentTeacherDal;
        private IMapper _mapper;

        public StudentManager(IStudentDal studentDal, IParentService parentService, IStudentLessonDal studentLessonDal, IStudentTeacherDal studentTeacherDal, IMapper mapper)
        {
            _studentDal = studentDal;
            _parentService = parentService;
            _studentLessonDal = studentLessonDal;
            _studentTeacherDal= studentTeacherDal;
            _mapper = mapper;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UserForRegisterDtoValidator))]
        [ValidationAspect(typeof(AddStudentDtoValidator))]
        [CacheRemoveAspect("IStudentService.Get")]
        public async Task<IResponse> Add(AddStudentDto studentAddDto)
        {
            IResponse result = await BusinessRules.Run(
                CheckIfEmailAddressExists(studentAddDto.Email), 
                CheckIfParentExists(studentAddDto.ParentId));

            if (result != null)
            {
                return result;
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(studentAddDto.Password, out passwordHash, out passwordSalt);

            var student = _mapper.Map<Student>(studentAddDto);
            student.PasswordSalt = passwordSalt;
            student.PasswordHash = passwordHash;

            await _studentDal.Add(student);

            return new SuccessResponse(Messages.AddStudent, 200);

        }

        public async Task<IResponse> AddLessonToStudent(AddLessonToStudentDto addLessonToStudentDto)
        {
            var studentLesson = _mapper.Map<StudentLesson>(addLessonToStudentDto);

            await _studentLessonDal.Add(studentLesson);
            return new SuccessResponse(Messages.AddStudent, 200);

        }

        public async Task<IResponse> AddTeacherToStudent(AddTeacherToStudentDto addTeacherToStudentDto)
        {
            var studentTeacher = _mapper.Map<StudentTeacher>(addTeacherToStudentDto);

            await _studentTeacherDal.Add(studentTeacher);
            return new SuccessResponse(Messages.AddStudent, 200);

        }

        public async Task<IResponse> Delete(int id)
        {
            IResponse result = await BusinessRules.Run(CheckIfExamGradeExists(id));

            if(result != null)
            {
                return result;
            }
            await _studentDal.Delete(id);
            return new SuccessResponse("Ok", 200);
        }

        public async Task<IDataResponse<IEnumerable<StudentDetailDto>>> GetAll()
        {
            var students =  await _studentDal.Include(null, x => x.Parent, x=>x.Lessons, x=> x.Teachers, x => x.ExamGrades);
            var studentDto = _mapper.Map<IEnumerable<StudentDetailDto>>(students);
            
            return new SuccessDataResponse<IEnumerable<StudentDetailDto>>(studentDto, Messages.GetAllStudent, 200);
        }

        public async Task<IDataResponse<StudentDetailDto>> GetById(int studentId)
        {
            var student = (await _studentDal.Include(x => x.Id == studentId, x => x.Parent, x => x.Lessons, x => x.Teachers, x=>x.ExamGrades)).FirstOrDefault();

            if(student != null)
            {
                var studentDetailDto = _mapper.Map<StudentDetailDto>(student);
                return new SuccessDataResponse<StudentDetailDto>(studentDetailDto, Messages.GetStudent, 200);

            }
            return new ErrorDataResponse<StudentDetailDto>(Messages.GetStudentError, 404);

        }

        public async Task<IResponse> Update(UpdateStudentDto updateStudentDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(updateStudentDto.Password, out passwordHash, out passwordSalt);

            var student = _mapper.Map<Student>(updateStudentDto);
            student.PasswordSalt = passwordSalt;
            student.PasswordHash = passwordHash;

            await _studentDal.Update(student);

            return new SuccessResponse("Ok", 200);

        }


    }
}
