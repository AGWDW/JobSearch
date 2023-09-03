using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearch.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JobSeeker",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeeker", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JobListing",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListingEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobListing", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JobListing_Employer_EmployerID",
                        column: x => x.EmployerID,
                        principalTable: "Employer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobListingJobSeeker",
                columns: table => new
                {
                    AppliedID = table.Column<int>(type: "int", nullable: false),
                    JobsApplyedForID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobListingJobSeeker", x => new { x.AppliedID, x.JobsApplyedForID });
                    table.ForeignKey(
                        name: "FK_JobListingJobSeeker_JobListing_JobsApplyedForID",
                        column: x => x.JobsApplyedForID,
                        principalTable: "JobListing",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobListingJobSeeker_JobSeeker_AppliedID",
                        column: x => x.AppliedID,
                        principalTable: "JobSeeker",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobListing_EmployerID",
                table: "JobListing",
                column: "EmployerID");

            migrationBuilder.CreateIndex(
                name: "IX_JobListingJobSeeker_JobsApplyedForID",
                table: "JobListingJobSeeker",
                column: "JobsApplyedForID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobListingJobSeeker");

            migrationBuilder.DropTable(
                name: "JobListing");

            migrationBuilder.DropTable(
                name: "JobSeeker");

            migrationBuilder.DropTable(
                name: "Employer");
        }
    }
}
