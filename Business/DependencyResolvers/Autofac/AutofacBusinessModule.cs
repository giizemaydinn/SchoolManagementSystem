using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region User

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            #endregion User

            #region Student

            builder.RegisterType<StudentManager>().As<IStudentService>().SingleInstance();
            builder.RegisterType<EfStudentDal>().As<IStudentDal>().SingleInstance();
            builder.RegisterType<EfStudentTeacherDal>().As<IStudentTeacherDal>().SingleInstance();
            builder.RegisterType<EfStudentLessonDal>().As<IStudentLessonDal>().SingleInstance();

            #endregion Student

            #region Parent

            builder.RegisterType<ParentManager>().As<IParentService>().SingleInstance();
            builder.RegisterType<EfParentDal>().As<IParentDal>().SingleInstance();

            #endregion Parent

            #region Teacher

            builder.RegisterType<TeacherManager>().As<ITeacherService>().SingleInstance();
            builder.RegisterType<EfTeacherDal>().As<ITeacherDal>().SingleInstance();

            #endregion Teacher

            #region Lesson

            builder.RegisterType<LessonManager>().As<ILessonService>().SingleInstance();
            builder.RegisterType<EfLessonDal>().As<ILessonDal>().SingleInstance();

            #region Lesson

            builder.RegisterType<LessonManager>().As<ILessonService>().SingleInstance();
            builder.RegisterType<EfLessonDal>().As<ILessonDal>().SingleInstance();

            #endregion Lesson
            #endregion Lesson

            #region ExamGrade

            builder.RegisterType<ExamGradeManager>().As<IExamGradeService>().SingleInstance();
            builder.RegisterType<EfExamGradeDal>().As<IExamGradeDal>().SingleInstance();

            #endregion ExamGrade


            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}