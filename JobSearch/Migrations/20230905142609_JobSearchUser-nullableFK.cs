using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearch.Migrations
{
    /// <inheritdoc />
    public partial class JobSearchUsernullableFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_JobSeeker_JobSeekerID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "JobSeekerID",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmployerID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployerID",
                table: "AspNetUsers",
                column: "EmployerID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employer_EmployerID",
                table: "AspNetUsers",
                column: "EmployerID",
                principalTable: "Employer",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_JobSeeker_JobSeekerID",
                table: "AspNetUsers",
                column: "JobSeekerID",
                principalTable: "JobSeeker",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employer_EmployerID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_JobSeeker_JobSeekerID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployerID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployerID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "JobSeekerID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_JobSeeker_JobSeekerID",
                table: "AspNetUsers",
                column: "JobSeekerID",
                principalTable: "JobSeeker",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
