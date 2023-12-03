using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerSide_GameRater.Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    gameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ratingCount = table.Column<int>(type: "int", nullable: true),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating = table.Column<float>(type: "real", nullable: false),
                    genreOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genreTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genreThree = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.gameID);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    ratingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gameID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.ratingID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
