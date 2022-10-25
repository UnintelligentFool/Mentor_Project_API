using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIA_1_ITHS_Project_Mentor.Migrations
{
    public partial class MakingStudentEducationRelationshipManyToManyInstead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Students_StudentId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_StudentId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Educations");

            migrationBuilder.CreateTable(
                name: "EducationStudent",
                columns: table => new
                {
                    EducationsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationStudent", x => new { x.EducationsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_EducationStudent_Educations_EducationsId",
                        column: x => x.EducationsId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationStudent_StudentsId",
                table: "EducationStudent",
                column: "StudentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationStudent");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Educations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_StudentId",
                table: "Educations",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Students_StudentId",
                table: "Educations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
