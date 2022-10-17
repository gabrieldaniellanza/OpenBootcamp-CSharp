using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApiBackend.Migrations
{
    public partial class updateUSERTABLE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charpters_Courses_CurseId",
                table: "Charpters");

            migrationBuilder.DropIndex(
                name: "IX_Charpters_CurseId",
                table: "Charpters");

            migrationBuilder.AddColumn<int>(
                name: "Rol",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Charpters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Charpters_CourseId",
                table: "Charpters",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Charpters_Courses_CourseId",
                table: "Charpters",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charpters_Courses_CourseId",
                table: "Charpters");

            migrationBuilder.DropIndex(
                name: "IX_Charpters_CourseId",
                table: "Charpters");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Charpters");

            migrationBuilder.CreateIndex(
                name: "IX_Charpters_CurseId",
                table: "Charpters",
                column: "CurseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Charpters_Courses_CurseId",
                table: "Charpters",
                column: "CurseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
