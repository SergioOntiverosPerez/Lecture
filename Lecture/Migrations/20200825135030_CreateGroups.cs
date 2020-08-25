using Microsoft.EntityFrameworkCore.Migrations;

namespace Lecture.Migrations
{
    public partial class CreateGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SubjectId1 = table.Column<int>(nullable: true),
                    SubjectId = table.Column<byte>(nullable: false),
                    ProfessorId1 = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Professors_ProfessorId1",
                        column: x => x.ProfessorId1,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Groups_Subjects_SubjectId1",
                        column: x => x.SubjectId1,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ProfessorId1",
                table: "Groups",
                column: "ProfessorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SubjectId1",
                table: "Groups",
                column: "SubjectId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
