using Microsoft.EntityFrameworkCore.Migrations;

namespace EduxV4.Repo.Migrations
{
    public partial class AddCourseCont : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchCourseContents_CourseContent_CourseContentId",
                table: "BranchCourseContents");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactCourseContents_CourseContent_CourseContentId",
                table: "ContactCourseContents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseContent_Courses_CourseId",
                table: "CourseContent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseContent",
                table: "CourseContent");

            migrationBuilder.RenameTable(
                name: "CourseContent",
                newName: "CourseContents");

            migrationBuilder.RenameIndex(
                name: "IX_CourseContent_CourseId",
                table: "CourseContents",
                newName: "IX_CourseContents_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseContents",
                table: "CourseContents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchCourseContents_CourseContents_CourseContentId",
                table: "BranchCourseContents",
                column: "CourseContentId",
                principalTable: "CourseContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactCourseContents_CourseContents_CourseContentId",
                table: "ContactCourseContents",
                column: "CourseContentId",
                principalTable: "CourseContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseContents_Courses_CourseId",
                table: "CourseContents",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchCourseContents_CourseContents_CourseContentId",
                table: "BranchCourseContents");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactCourseContents_CourseContents_CourseContentId",
                table: "ContactCourseContents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseContents_Courses_CourseId",
                table: "CourseContents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseContents",
                table: "CourseContents");

            migrationBuilder.RenameTable(
                name: "CourseContents",
                newName: "CourseContent");

            migrationBuilder.RenameIndex(
                name: "IX_CourseContents_CourseId",
                table: "CourseContent",
                newName: "IX_CourseContent_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseContent",
                table: "CourseContent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchCourseContents_CourseContent_CourseContentId",
                table: "BranchCourseContents",
                column: "CourseContentId",
                principalTable: "CourseContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactCourseContents_CourseContent_CourseContentId",
                table: "ContactCourseContents",
                column: "CourseContentId",
                principalTable: "CourseContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseContent_Courses_CourseId",
                table: "CourseContent",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
