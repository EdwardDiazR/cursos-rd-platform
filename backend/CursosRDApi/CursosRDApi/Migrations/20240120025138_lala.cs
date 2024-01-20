using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursosRDApi.Migrations
{
    /// <inheritdoc />
    public partial class lala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    course_descrption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    courseurltitle = table.Column<string>(name: "course-url-title", type: "nvarchar(max)", nullable: false),
                    course_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    course_creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    course_published_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    course_last_updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    course_has_been_published = table.Column<bool>(type: "bit", nullable: false),
                    course_enrolled_students = table.Column<int>(type: "int", nullable: false),
                    course_is_public = table.Column<bool>(type: "bit", nullable: false),
                    course_language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    course_teacher_id = table.Column<int>(type: "int", nullable: false),
                    thumbnail_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.course_id);
                });

            migrationBuilder.CreateTable(
                name: "course_enroll",
                columns: table => new
                {
                    enroll_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    enroll_course_id = table.Column<int>(type: "int", nullable: false),
                    enroll_student_id = table.Column<int>(type: "int", nullable: false),
                    enroll_is_active = table.Column<bool>(type: "bit", nullable: false),
                    enroll_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    enroll_course_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    enroll_discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    enroll_coupon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enroll_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_enroll", x => x.enroll_id);
                });

            migrationBuilder.CreateTable(
                name: "course_lessons_section",
                columns: table => new
                {
                    section_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    section_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    section_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    section_lessons_qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_lessons_section", x => x.section_id);
                });

            migrationBuilder.CreateTable(
                name: "lesson",
                columns: table => new
                {
                    lesson_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lesson_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lesson_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    section_id = table.Column<int>(type: "int", nullable: false),
                    video_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lesson", x => x.lesson_id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_first_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    student_middle_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    student_last_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    student_second_last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    student_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_email_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_banned = table.Column<bool>(type: "bit", nullable: false),
                    student_phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    student_country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    student_gender = table.Column<int>(type: "int", nullable: false),
                    student_role_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.student_id);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacher_first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacher_middle_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teacher_last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacher_second_last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teacher_display_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacher_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_email_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_banned = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacher_dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    teacher_profile_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teacher_role_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.teacher_id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_role = table.Column<int>(type: "int", nullable: false),
                    user_profile_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_key);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "course_enroll");

            migrationBuilder.DropTable(
                name: "course_lessons_section");

            migrationBuilder.DropTable(
                name: "lesson");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "teacher");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
