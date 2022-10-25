using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIA_1_ITHS_Project_Mentor.Migrations
{
    public partial class AddingLectureFileManyToManyWithAdministratorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministratorLectureFile",
                columns: table => new
                {
                    AdministratorsId = table.Column<int>(type: "int", nullable: false),
                    LectureFilesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministratorLectureFile", x => new { x.AdministratorsId, x.LectureFilesId });
                    table.ForeignKey(
                        name: "FK_AdministratorLectureFile_Administrators_AdministratorsId",
                        column: x => x.AdministratorsId,
                        principalTable: "Administrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdministratorLectureFile_LectureFiles_LectureFilesId",
                        column: x => x.LectureFilesId,
                        principalTable: "LectureFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorLectureFile_LectureFilesId",
                table: "AdministratorLectureFile",
                column: "LectureFilesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministratorLectureFile");
        }
    }
}
