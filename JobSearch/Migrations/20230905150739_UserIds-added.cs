using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearch.Migrations
{
    /// <inheritdoc />
    public partial class UserIdsadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployerID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_JobSeekerID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "JobSeeker",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Employer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployerID",
                table: "AspNetUsers",
                column: "EmployerID",
                unique: true,
                filter: "[EmployerID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_JobSeekerID",
                table: "AspNetUsers",
                column: "JobSeekerID",
                unique: true,
                filter: "[JobSeekerID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployerID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_JobSeekerID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "JobSeeker");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Employer");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployerID",
                table: "AspNetUsers",
                column: "EmployerID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_JobSeekerID",
                table: "AspNetUsers",
                column: "JobSeekerID");
        }
    }
}
