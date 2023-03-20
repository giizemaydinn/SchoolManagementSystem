﻿// <auto-generated />
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(SchoolManagementDbContext))]
    partial class SchoolManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Concrete.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");
                });

            modelBuilder.Entity("Core.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LastName");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varbinary(500)")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varbinary(500)")
                        .HasColumnName("PasswordSalt");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("Users", "dbo");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOperationClaims");
                });

            modelBuilder.Entity("Entities.Concrete.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Entities.Concrete.ExamGrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentId");

                    b.ToTable("ExamGrades");
                });

            modelBuilder.Entity("Entities.Concrete.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Entities.Concrete.StudentLesson", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "LessonId");

                    b.HasIndex("LessonId");

                    b.ToTable("StudentLesson");
                });

            modelBuilder.Entity("Entities.Concrete.StudentTeacher", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("StudentTeacher");
                });

            modelBuilder.Entity("Entities.Concrete.Parent", b =>
                {
                    b.HasBaseType("Core.Entities.Concrete.User");

                    b.ToTable("Parents", (string)null);
                });

            modelBuilder.Entity("Entities.Concrete.Student", b =>
                {
                    b.HasBaseType("Core.Entities.Concrete.User");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasIndex("ParentId");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("Entities.Concrete.Teacher", b =>
                {
                    b.HasBaseType("Core.Entities.Concrete.User");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.HasIndex("LessonId");

                    b.ToTable("Teachers", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.HasOne("Core.Entities.Concrete.OperationClaim", "OperationClaim")
                        .WithMany()
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Concrete.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Concrete.Book", b =>
                {
                    b.HasOne("Entities.Concrete.Student", "Student")
                        .WithMany("Books")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Entities.Concrete.ExamGrade", b =>
                {
                    b.HasOne("Entities.Concrete.Lesson", "Lesson")
                        .WithMany("ExamGrades")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Student", "Student")
                        .WithMany("ExamGrades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Entities.Concrete.StudentLesson", b =>
                {
                    b.HasOne("Entities.Concrete.Lesson", "Lesson")
                        .WithMany("Students")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Student", "Student")
                        .WithMany("Lessons")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Entities.Concrete.StudentTeacher", b =>
                {
                    b.HasOne("Entities.Concrete.Student", "Student")
                        .WithMany("Teachers")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Teacher", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Entities.Concrete.Parent", b =>
                {
                    b.HasOne("Core.Entities.Concrete.User", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concrete.Parent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.Student", b =>
                {
                    b.HasOne("Core.Entities.Concrete.User", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concrete.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Parent", "Parent")
                        .WithMany("Students")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Entities.Concrete.Teacher", b =>
                {
                    b.HasOne("Core.Entities.Concrete.User", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concrete.Teacher", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Lesson", "Lesson")
                        .WithMany("Teachers")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("Entities.Concrete.Lesson", b =>
                {
                    b.Navigation("ExamGrades");

                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Entities.Concrete.Parent", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Entities.Concrete.Student", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("ExamGrades");

                    b.Navigation("Lessons");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Entities.Concrete.Teacher", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}