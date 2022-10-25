﻿// <auto-generated />
using System;
using LIA_1_ITHS_Project_Mentor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LIA_1_ITHS_Project_Mentor.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AdministratorCourse", b =>
                {
                    b.Property<int>("AdministratorsId")
                        .HasColumnType("int");

                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.HasKey("AdministratorsId", "CoursesId");

                    b.HasIndex("CoursesId");

                    b.ToTable("AdministratorCourse");
                });

            modelBuilder.Entity("AdministratorEducation", b =>
                {
                    b.Property<int>("AdministratorsId")
                        .HasColumnType("int");

                    b.Property<int>("EducationsId")
                        .HasColumnType("int");

                    b.HasKey("AdministratorsId", "EducationsId");

                    b.HasIndex("EducationsId");

                    b.ToTable("AdministratorEducation");
                });

            modelBuilder.Entity("AdministratorLecture", b =>
                {
                    b.Property<int>("AdministratorsId")
                        .HasColumnType("int");

                    b.Property<int>("LecturesId")
                        .HasColumnType("int");

                    b.HasKey("AdministratorsId", "LecturesId");

                    b.HasIndex("LecturesId");

                    b.ToTable("AdministratorLecture");
                });

            modelBuilder.Entity("AdministratorLectureFile", b =>
                {
                    b.Property<int>("AdministratorsId")
                        .HasColumnType("int");

                    b.Property<int>("LectureFilesId")
                        .HasColumnType("int");

                    b.HasKey("AdministratorsId", "LectureFilesId");

                    b.HasIndex("LectureFilesId");

                    b.ToTable("AdministratorLectureFile");
                });

            modelBuilder.Entity("AdministratorSchool", b =>
                {
                    b.Property<int>("AdministratorsId")
                        .HasColumnType("int");

                    b.Property<int>("SchoolsId")
                        .HasColumnType("int");

                    b.HasKey("AdministratorsId", "SchoolsId");

                    b.HasIndex("SchoolsId");

                    b.ToTable("AdministratorSchool");
                });

            modelBuilder.Entity("AdministratorSchoolContactPerson", b =>
                {
                    b.Property<int>("AdministratorsId")
                        .HasColumnType("int");

                    b.Property<int>("SchoolContactPersonsId")
                        .HasColumnType("int");

                    b.HasKey("AdministratorsId", "SchoolContactPersonsId");

                    b.HasIndex("SchoolContactPersonsId");

                    b.ToTable("AdministratorSchoolContactPerson");
                });

            modelBuilder.Entity("AdministratorStudent", b =>
                {
                    b.Property<int>("AdministratorsId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("AdministratorsId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("AdministratorStudent");
                });

            modelBuilder.Entity("AdministratorTeacher", b =>
                {
                    b.Property<int>("AdministratorsId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("AdministratorsId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("AdministratorTeacher");
                });

            modelBuilder.Entity("CourseTeacher", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("CourseTeacher");
                });

            modelBuilder.Entity("EducationStudent", b =>
                {
                    b.Property<int>("EducationsId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("EducationsId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("EducationStudent");
                });

            modelBuilder.Entity("EducationTeacher", b =>
                {
                    b.Property<int>("EducationsId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("EducationsId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("EducationTeacher");
                });

            modelBuilder.Entity("LectureTeacher", b =>
                {
                    b.Property<int>("LecturesId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("LecturesId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("LectureTeacher");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.AdminCreator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdminCreatorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminCreatorPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdminCreators");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdminCreatorId")
                        .HasColumnType("int");

                    b.Property<string>("AdministratorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdministratorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdministratorPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdministratorPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminCreatorId");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EducationId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EducationId");

                    b.HasIndex("StudentId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EducationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("LectureCreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LectureCreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LectureDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LectureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.LectureFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LectureFileUploadedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LectureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.ToTable("LectureFiles");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("SchoolEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SchoolOrganisationNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.SchoolContactPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("SchoolContactPersonEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolContactPersonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolContactPersonPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("SchoolContactPersons");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TeacherEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SchoolStudent", b =>
                {
                    b.Property<int>("SchoolsId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("SchoolsId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("SchoolStudent");
                });

            modelBuilder.Entity("SchoolTeacher", b =>
                {
                    b.Property<int>("SchoolsId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("SchoolsId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("SchoolTeacher");
                });

            modelBuilder.Entity("StudentTeacher", b =>
                {
                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("StudentsId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("StudentTeacher");
                });

            modelBuilder.Entity("AdministratorCourse", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Administrator", null)
                        .WithMany()
                        .HasForeignKey("AdministratorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdministratorEducation", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Administrator", null)
                        .WithMany()
                        .HasForeignKey("AdministratorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Education", null)
                        .WithMany()
                        .HasForeignKey("EducationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdministratorLecture", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Administrator", null)
                        .WithMany()
                        .HasForeignKey("AdministratorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Lecture", null)
                        .WithMany()
                        .HasForeignKey("LecturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdministratorLectureFile", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Administrator", null)
                        .WithMany()
                        .HasForeignKey("AdministratorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.LectureFile", null)
                        .WithMany()
                        .HasForeignKey("LectureFilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdministratorSchool", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Administrator", null)
                        .WithMany()
                        .HasForeignKey("AdministratorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.School", null)
                        .WithMany()
                        .HasForeignKey("SchoolsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdministratorSchoolContactPerson", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Administrator", null)
                        .WithMany()
                        .HasForeignKey("AdministratorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.SchoolContactPerson", null)
                        .WithMany()
                        .HasForeignKey("SchoolContactPersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdministratorStudent", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Administrator", null)
                        .WithMany()
                        .HasForeignKey("AdministratorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdministratorTeacher", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Administrator", null)
                        .WithMany()
                        .HasForeignKey("AdministratorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseTeacher", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EducationStudent", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Education", null)
                        .WithMany()
                        .HasForeignKey("EducationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EducationTeacher", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Education", null)
                        .WithMany()
                        .HasForeignKey("EducationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LectureTeacher", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Lecture", null)
                        .WithMany()
                        .HasForeignKey("LecturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.Administrator", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.AdminCreator", "AdminCreator")
                        .WithMany("Administrators")
                        .HasForeignKey("AdminCreatorId");

                    b.Navigation("AdminCreator");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.Course", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Education", "Education")
                        .WithMany("Courses")
                        .HasForeignKey("EducationId");

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentId");

                    b.Navigation("Education");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.Education", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.School", "School")
                        .WithMany("Educations")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.Lecture", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Course", "Course")
                        .WithMany("Lectures")
                        .HasForeignKey("CourseId");

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Student", "Student")
                        .WithMany("Lectures")
                        .HasForeignKey("StudentId");

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.LectureFile", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Lecture", "Lecture")
                        .WithMany("LectureFiles")
                        .HasForeignKey("LectureId");

                    b.Navigation("Lecture");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.SchoolContactPerson", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.School", "School")
                        .WithMany("SchoolContactPersons")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("SchoolStudent", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.School", null)
                        .WithMany()
                        .HasForeignKey("SchoolsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolTeacher", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.School", null)
                        .WithMany()
                        .HasForeignKey("SchoolsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentTeacher", b =>
                {
                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIA_1_ITHS_Project_Mentor.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.AdminCreator", b =>
                {
                    b.Navigation("Administrators");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.Course", b =>
                {
                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.Education", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.Lecture", b =>
                {
                    b.Navigation("LectureFiles");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.School", b =>
                {
                    b.Navigation("Educations");

                    b.Navigation("SchoolContactPersons");
                });

            modelBuilder.Entity("LIA_1_ITHS_Project_Mentor.Models.Student", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Lectures");
                });
#pragma warning restore 612, 618
        }
    }
}
