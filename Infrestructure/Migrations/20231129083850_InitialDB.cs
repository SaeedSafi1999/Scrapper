using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CitiesLatAndLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lang = table.Column<float>(type: "real", nullable: false),
                    Lat = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitiesLatAndLangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ejucations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSite = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Academy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beginning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgrammeDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeCourseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isElearning = table.Column<bool>(type: "bit", nullable: true),
                    isCompleteOnlinePossible = table.Column<bool>(type: "bit", nullable: true),
                    badgeLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    structuredResearch = table.Column<bool>(type: "bit", nullable: true),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lat = table.Column<float>(type: "real", nullable: true),
                    lang = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejucations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jobid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    publishedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jobUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    postedTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    applicationsCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contractType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experienceLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    workType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    posterProfileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    posterFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lang = table.Column<float>(type: "real", nullable: true),
                    lat = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitiesLatAndLangs");

            migrationBuilder.DropTable(
                name: "Ejucations");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
