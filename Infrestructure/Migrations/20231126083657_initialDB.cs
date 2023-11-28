using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrestructure.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
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
                    idSite = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Academy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beginning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgrammeDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typeCourseDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isElearning = table.Column<bool>(type: "bit", nullable: false),
                    isCompleteOnlinePossible = table.Column<bool>(type: "bit", nullable: false),
                    badgeLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    structuredResearch = table.Column<bool>(type: "bit", nullable: false),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requestLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lat = table.Column<float>(type: "real", nullable: false),
                    lang = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejucations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkHour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lang = table.Column<float>(type: "real", nullable: false),
                    lat = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
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
