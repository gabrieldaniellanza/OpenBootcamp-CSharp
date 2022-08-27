using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApiBachend.Migrations
{
    public partial class NewTableCharpter4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Charpters_CharptersId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CharptersId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CharptersId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CurseId",
                table: "Charpters",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charpters_Courses_CurseId",
                table: "Charpters");

            migrationBuilder.DropIndex(
                name: "IX_Charpters_CurseId",
                table: "Charpters");

            migrationBuilder.DropColumn(
                name: "CurseId",
                table: "Charpters");

            migrationBuilder.AddColumn<int>(
                name: "CharptersId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CharptersId",
                table: "Courses",
                column: "CharptersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Charpters_CharptersId",
                table: "Courses",
                column: "CharptersId",
                principalTable: "Charpters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
