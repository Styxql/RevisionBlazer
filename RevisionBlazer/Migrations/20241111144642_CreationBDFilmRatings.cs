using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RevisionBlazer.Migrations
{
    /// <inheritdoc />
    public partial class CreationBDFilmRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_e_course",
                columns: table => new
                {
                    idcourse = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    duration = table.Column<int>(type: "integer", nullable: true),
                    startdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    enddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_course", x => x.idcourse);
                });

            migrationBuilder.CreateTable(
                name: "t_e_instructor",
                columns: table => new
                {
                    idinstructor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    expertise = table.Column<string>(type: "text", nullable: false),
                    phonenumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_instructor", x => x.idinstructor);
                });

            migrationBuilder.CreateTable(
                name: "t_e_student",
                columns: table => new
                {
                    idstudent = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    dateofbirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    phonenumber = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    enrollmentdate = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_student", x => x.idstudent);
                });

            migrationBuilder.CreateTable(
                name: "Assesments",
                columns: table => new
                {
                    assessmentid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idcourse = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    totalmarks = table.Column<string>(type: "text", nullable: false),
                    duedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assesments", x => x.assessmentid);
                    table.ForeignKey(
                        name: "FK_Assesments_t_e_course_idcourse",
                        column: x => x.idcourse,
                        principalTable: "t_e_course",
                        principalColumn: "idcourse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_module",
                columns: table => new
                {
                    idmodule = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idcourse = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    duration = table.Column<int>(type: "integer", nullable: false),
                    startdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    enddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_module", x => x.idmodule);
                    table.ForeignKey(
                        name: "FK_t_e_module_t_e_course_idcourse",
                        column: x => x.idcourse,
                        principalTable: "t_e_course",
                        principalColumn: "idcourse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "joincourseinstructor",
                columns: table => new
                {
                    idinstructor = table.Column<int>(type: "integer", nullable: false),
                    idcourse = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_joincourseinstructor", x => new { x.idcourse, x.idinstructor });
                    table.ForeignKey(
                        name: "FK_joincourseinstructor_t_e_course_idcourse",
                        column: x => x.idcourse,
                        principalTable: "t_e_course",
                        principalColumn: "idcourse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_joincourseinstructor_t_e_instructor_idinstructor",
                        column: x => x.idinstructor,
                        principalTable: "t_e_instructor",
                        principalColumn: "idinstructor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    enrollmentid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idstudent = table.Column<int>(type: "integer", nullable: false),
                    idcourse = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    finalgrade = table.Column<double>(type: "double precision", nullable: true),
                    progress = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.enrollmentid);
                    table.ForeignKey(
                        name: "FK_Enrollments_t_e_course_idcourse",
                        column: x => x.idcourse,
                        principalTable: "t_e_course",
                        principalColumn: "idcourse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_t_e_student_idstudent",
                        column: x => x.idstudent,
                        principalTable: "t_e_student",
                        principalColumn: "idstudent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    idgrade = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enrollmentid = table.Column<int>(type: "integer", nullable: false),
                    assessmentid = table.Column<string>(type: "text", nullable: false),
                    score = table.Column<string>(type: "text", nullable: false),
                    feedback = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.idgrade);
                    table.ForeignKey(
                        name: "FK_Grades_Enrollments_enrollmentid",
                        column: x => x.enrollmentid,
                        principalTable: "Enrollments",
                        principalColumn: "enrollmentid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assesments_idcourse",
                table: "Assesments",
                column: "idcourse");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_idcourse",
                table: "Enrollments",
                column: "idcourse");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_idstudent",
                table: "Enrollments",
                column: "idstudent");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_enrollmentid",
                table: "Grades",
                column: "enrollmentid");

            migrationBuilder.CreateIndex(
                name: "IX_joincourseinstructor_idinstructor",
                table: "joincourseinstructor",
                column: "idinstructor");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_module_idcourse",
                table: "t_e_module",
                column: "idcourse");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assesments");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "joincourseinstructor");

            migrationBuilder.DropTable(
                name: "t_e_module");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "t_e_instructor");

            migrationBuilder.DropTable(
                name: "t_e_course");

            migrationBuilder.DropTable(
                name: "t_e_student");
        }
    }
}
