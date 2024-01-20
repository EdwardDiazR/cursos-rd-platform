﻿// <auto-generated />
using System;
using CursosRDApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CursosRDApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240120025138_lala")]
    partial class lala
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CursosRDApi.Models.CourseModels.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("course_creation_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("course_descrption");

                    b.Property<int>("EnrolledStudents")
                        .HasColumnType("int")
                        .HasColumnName("course_enrolled_students");

                    b.Property<bool>("HasBeenPublished")
                        .HasColumnType("bit")
                        .HasColumnName("course_has_been_published");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit")
                        .HasColumnName("course_is_public");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("course_language");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("course_last_updated_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("course_name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("course_price");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("course_published_date");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int")
                        .HasColumnName("course_teacher_id");

                    b.Property<string>("ThumbnailImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("thumbnail_image_url");

                    b.Property<string>("UrlTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("course-url-title");

                    b.HasKey("Id");

                    b.ToTable("course");
                });

            modelBuilder.Entity("CursosRDApi.Models.CourseModels.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("lesson_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("lesson_description");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit")
                        .HasColumnName("is_visible");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("lesson_name");

                    b.Property<int>("SectionId")
                        .HasColumnType("int")
                        .HasColumnName("section_id");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("video_url");

                    b.HasKey("Id");

                    b.ToTable("lesson");
                });

            modelBuilder.Entity("CursosRDApi.Models.CourseModels.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("section_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("section_description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("section_name");

                    b.Property<int>("SectionLessons")
                        .HasColumnType("int")
                        .HasColumnName("section_lessons_qty");

                    b.HasKey("Id");

                    b.ToTable("course_lessons_section");
                });

            modelBuilder.Entity("CursosRDApi.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role_name");

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("CursosRDApi.Models.StudentModels.CourseSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("enroll_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Coupon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("enroll_coupon");

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("enroll_course_id");

                    b.Property<decimal>("CoursePrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("enroll_course_price");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("enroll_discount");

                    b.Property<DateTime>("EnrollDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("enroll_date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("enroll_is_active");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("enroll_student_id");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("enroll_total");

                    b.HasKey("Id");

                    b.ToTable("course_enroll");
                });

            modelBuilder.Entity("CursosRDApi.Models.StudentModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("student_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("student_country");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("student_email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("student_first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("student_gender");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit")
                        .HasColumnName("is_banned");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("is_email_confirmed");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("student_last_name");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("student_middle_name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("student_phone_number");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("student_role_id");

                    b.Property<string>("SecondLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("student_second_last_name");

                    b.HasKey("Id");

                    b.ToTable("student");
                });

            modelBuilder.Entity("CursosRDApi.Models.TeacherModels.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("teacher_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("teacher_display_name");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2")
                        .HasColumnName("teacher_dob");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("teacher_email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("teacher_first_name");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit")
                        .HasColumnName("is_banned");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("is_email_confirmed");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("teacher_last_name");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("teacher_middle_name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("teacher_profile_image_url");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("teacher_role_id");

                    b.Property<string>("SecondLastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("teacher_second_last_name");

                    b.HasKey("Id");

                    b.ToTable("teacher");
                });

            modelBuilder.Entity("CursosRDApi.Models.UserModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_password");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int")
                        .HasColumnName("user_profile_id");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("user_role");

                    b.HasKey("Id");

                    b.ToTable("user");
                });
#pragma warning restore 612, 618
        }
    }
}
