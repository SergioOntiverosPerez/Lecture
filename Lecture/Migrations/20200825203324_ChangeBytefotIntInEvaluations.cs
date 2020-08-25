using Microsoft.EntityFrameworkCore.Migrations;

namespace Lecture.Migrations
{
    public partial class ChangeBytefotIntInEvaluations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Groups_GroupId1",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Students_StudentId1",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_GroupId1",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_StudentId1",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "GroupId1",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Evaluations");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Evaluations",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Evaluations",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_GroupId",
                table: "Evaluations",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_StudentId",
                table: "Evaluations",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Groups_GroupId",
                table: "Evaluations",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Students_StudentId",
                table: "Evaluations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Groups_GroupId",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Students_StudentId",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_GroupId",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_StudentId",
                table: "Evaluations");

            migrationBuilder.AlterColumn<byte>(
                name: "StudentId",
                table: "Evaluations",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<byte>(
                name: "GroupId",
                table: "Evaluations",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "GroupId1",
                table: "Evaluations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "Evaluations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_GroupId1",
                table: "Evaluations",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_StudentId1",
                table: "Evaluations",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Groups_GroupId1",
                table: "Evaluations",
                column: "GroupId1",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Students_StudentId1",
                table: "Evaluations",
                column: "StudentId1",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
