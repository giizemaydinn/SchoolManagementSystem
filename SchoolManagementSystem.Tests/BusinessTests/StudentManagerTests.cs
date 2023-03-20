using AutoFixture;
using AutoMapper;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Responses;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Student;
using FluentAssertions;
using Moq;

namespace Tests.Controller
{
    public class StudentManagerTests
    {
        readonly IFixture _fixture;

        Mock<IStudentDal> _studentDal;
        Mock<IStudentTeacherDal> _studentTeacherDal;

        Mock<IStudentLessonDal> _studentLessonDal;
        private IMapper _mapper;
        readonly StudentManager _studentManager;

        public StudentManagerTests()
        {
            _fixture = new Fixture();

            _studentTeacherDal = new Fixture().Freeze<Mock<IStudentTeacherDal>>();
            _studentLessonDal = new Fixture().Freeze<Mock<IStudentLessonDal>>();
            _studentDal = _fixture.Freeze<Mock<IStudentDal>>();


            _studentManager = new StudentManager(
                _studentDal.Object, _studentLessonDal.Object, _studentTeacherDal.Object, _mapper);
        }

        [Fact]
        public async Task GetById_ShouldReturnGetStudentError()
        {
            // Arrange
            var studentId = _fixture.Create<int>();
            var students = _fixture.Freeze<Mock<IEnumerable<Student>>>();

            var studentDetail = _fixture.Create<StudentDetailDto>();

            _studentDal
                .Setup(x => x.Include(x => x.Id == studentId, x => x.Parent, x => x.Lessons, x => x.Teachers, x => x.ExamGrades))
                .ReturnsAsync(students.Object);

            // Act
            var result = await _studentManager.GetById(studentDetail.Id);

            // Assert
            result.Should().NotBeNull();

            result.Should().BeAssignableTo<IDataResponse<StudentDetailDto>>();
            result.Message.Should().BeEquivalentTo(Messages.GetStudentError);
        }




    }
}
