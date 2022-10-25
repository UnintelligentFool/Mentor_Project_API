using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIA_1_ITHS_Project_Mentor.Migrations
{
    public partial class UpdatingLectureAndLectureFileWithDateTimeUploadedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LectureCreatedDateTime",
                table: "Lectures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LectureFileUploadedDateTime",
                table: "LectureFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LectureCreatedDateTime",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "LectureFileUploadedDateTime",
                table: "LectureFiles");
        }
    }
}
