using AutoMapper;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos.ExamGrade;
using Entities.Dtos.Lesson;
using Entities.Dtos.Parent;
using Entities.Dtos.Student;
using Entities.Dtos.Teacher;
using Entities.Dtos.User;

namespace Entities.Mappings
{
    /// <summary>
    /// Manage NuGet --> AutoMapper, AutoMapper.Extensions.Microsoft.DependencyInjection
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region UserMap

            CreateMap<User, UserForRegisterDto>().ReverseMap();
            CreateMap<User, UserForLoginDto>().ReverseMap();

            #endregion UserMap

            #region StudentMap

            CreateMap<Student, AddStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();
            CreateMap<Student, StudentDetailDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<StudentLesson, AddLessonToStudentDto>().ReverseMap();
            CreateMap<StudentTeacher, AddTeacherToStudentDto>().ReverseMap();

            #endregion StudentMap

            #region ParentMap

            CreateMap<Parent, ParentAddDto>().ReverseMap();
            CreateMap<Parent, UpdateParentDto>().ReverseMap();
            CreateMap<Parent, ParentDetailDto>().ReverseMap();

            #endregion ParentMap

            #region TeacherMap

            CreateMap<Teacher, AddTeacherDto>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDto>().ReverseMap();
            CreateMap<Teacher, TeacherDetailDto>().ReverseMap();

            CreateMap<StudentTeacher, TeacherDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.TeacherId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(source => source.Teacher.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(source => source.Teacher.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(source => source.Teacher.Email));

            CreateMap<StudentTeacher, TeacherDetailDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.TeacherId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(source => source.Teacher.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(source => source.Teacher.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(source => source.Teacher.Email))
                .ForMember(dest => dest.Lesson, opt => opt.MapFrom(src => src.Teacher.Lesson));

            #endregion TeacherMap

            #region LessonMap

            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<Lesson, AddLessonDto>().ReverseMap();
            CreateMap<StudentLesson, LessonDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.LessonId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Lesson.Name));
            #endregion LessonMap

            #region ExamGradeMap

            CreateMap<ExamGrade, AddExamGradeDto>().ReverseMap();
            CreateMap<ExamGrade, ExamGradeForStudentDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                .ForPath(dest => dest.Lesson.Id, opt => opt.MapFrom(source => source.Lesson.Id))
                .ForPath(dest => dest.Lesson.Name, opt => opt.MapFrom(source => source.Lesson.Name))
                .ForMember(dest => dest.Grade, opt => opt.MapFrom(source => source.Grade));

            CreateMap<ExamGrade, ExamGradeDetailDto>().ReverseMap();

            

            #endregion ExamGradeMap

        }
    }
}
