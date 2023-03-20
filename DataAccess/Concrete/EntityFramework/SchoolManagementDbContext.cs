using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccess.Concrete.EntityFramework
{
    public class SchoolManagementDbContext : DbContext
    {
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options) : base(options)
        {
        }

        public SchoolManagementDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                        .Build().GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Assembly assemblyConfiguration = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyConfiguration);

            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Parent>().ToTable("Parents");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");


            modelBuilder.Entity<Student>().HasOne(x => x.Parent)
                .WithMany(x => x.Students);

            /////////////
            ///
            modelBuilder.Entity<ExamGrade>().HasOne(x => x.Student)
                .WithMany(x => x.ExamGrades);

            /////////////
            modelBuilder.Entity<Teacher>().HasOne(x => x.Lesson)
                .WithMany(x => x.Teachers);

            //////////
            modelBuilder.Entity<StudentLesson>()
                .HasKey(x => new { x.StudentId, x.LessonId });

            modelBuilder.Entity<StudentLesson>()
                .HasOne(x => x.Student)
                .WithMany(x => x.Lessons)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<StudentLesson>()
                .HasOne(x => x.Lesson)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.LessonId);

            /////////////
            modelBuilder.Entity<StudentTeacher>()
                .HasKey(x => new { x.StudentId, x.TeacherId });

            modelBuilder.Entity<StudentTeacher>()
                .HasOne(x => x.Student)
                .WithMany(x => x.Teachers)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<StudentTeacher>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.TeacherId);
        }

        public DbSet<Student> Students { get; set; }
        //public DbSet<StudentLesson> StudentLessons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<ExamGrade> ExamGrades { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }



    }
}
