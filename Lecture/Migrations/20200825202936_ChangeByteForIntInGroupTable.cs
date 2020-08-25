using Microsoft.EntityFrameworkCore.Migrations;

namespace Lecture.Migrations
{
    public partial class ChangeByteForIntInGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Professors_ProfessorId1",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Subjects_SubjectId1",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ProfessorId1",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_SubjectId1",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ProfessorId1",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SubjectId1",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Groups",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "Groups",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ProfessorId",
                table: "Groups",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SubjectId",
                table: "Groups",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Professors_ProfessorId",
                table: "Groups",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Subjects_SubjectId",
                table: "Groups",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Professors_ProfessorId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Subjects_SubjectId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ProfessorId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_SubjectId",
                table: "Groups");

            migrationBuilder.AlterColumn<byte>(
                name: "SubjectId",
                table: "Groups",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<byte>(
                name: "ProfessorId",
                table: "Groups",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId1",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId1",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ProfessorId1",
                table: "Groups",
                column: "ProfessorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SubjectId1",
                table: "Groups",
                column: "SubjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Professors_ProfessorId1",
                table: "Groups",
                column: "ProfessorId1",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Subjects_SubjectId1",
                table: "Groups",
                column: "SubjectId1",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
