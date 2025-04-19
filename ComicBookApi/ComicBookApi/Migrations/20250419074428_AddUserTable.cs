using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComicBookApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Characters",
            //    columns: table => new
            //    {
            //        CharacterId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Alias = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Characters", x => x.CharacterId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Creators",
            //    columns: table => new
            //    {
            //        CreatorId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Creators", x => x.CreatorId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Events",
            //    columns: table => new
            //    {
            //        EventId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Events", x => x.EventId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Series",
            //    columns: table => new
            //    {
            //        SeriesId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Series", x => x.SeriesId);
            //    });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            //migrationBuilder.CreateTable(
            //    name: "Comics",
            //    columns: table => new
            //    {
            //        ComicId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IssueNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        SeriesId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Comics", x => x.ComicId);
            //        table.ForeignKey(
            //            name: "FK_Comics_Series_SeriesId",
            //            column: x => x.SeriesId,
            //            principalTable: "Series",
            //            principalColumn: "SeriesId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ComicCharacters",
            //    columns: table => new
            //    {
            //        ComicId = table.Column<int>(type: "int", nullable: false),
            //        CharacterId = table.Column<int>(type: "int", nullable: false),
            //        Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ComicCharacters", x => new { x.ComicId, x.CharacterId });
            //        table.ForeignKey(
            //            name: "FK_ComicCharacters_Characters_CharacterId",
            //            column: x => x.CharacterId,
            //            principalTable: "Characters",
            //            principalColumn: "CharacterId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ComicCharacters_Comics_ComicId",
            //            column: x => x.ComicId,
            //            principalTable: "Comics",
            //            principalColumn: "ComicId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ComicCreators",
            //    columns: table => new
            //    {
            //        ComicId = table.Column<int>(type: "int", nullable: false),
            //        CreatorId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ComicCreators", x => new { x.ComicId, x.CreatorId });
            //        table.ForeignKey(
            //            name: "FK_ComicCreators_Comics_ComicId",
            //            column: x => x.ComicId,
            //            principalTable: "Comics",
            //            principalColumn: "ComicId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ComicCreators_Creators_CreatorId",
            //            column: x => x.CreatorId,
            //            principalTable: "Creators",
            //            principalColumn: "CreatorId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ComicEvents",
            //    columns: table => new
            //    {
            //        ComicId = table.Column<int>(type: "int", nullable: false),
            //        EventId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ComicEvents", x => new { x.ComicId, x.EventId });
            //        table.ForeignKey(
            //            name: "FK_ComicEvents_Comics_ComicId",
            //            column: x => x.ComicId,
            //            principalTable: "Comics",
            //            principalColumn: "ComicId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ComicEvents_Events_EventId",
            //            column: x => x.EventId,
            //            principalTable: "Events",
            //            principalColumn: "EventId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Stories",
            //    columns: table => new
            //    {
            //        StoryId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ComicId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Stories", x => x.StoryId);
            //        table.ForeignKey(
            //            name: "FK_Stories_Comics_ComicId",
            //            column: x => x.ComicId,
            //            principalTable: "Comics",
            //            principalColumn: "ComicId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_ComicCharacters_CharacterId",
            //    table: "ComicCharacters",
            //    column: "CharacterId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ComicCreators_CreatorId",
            //    table: "ComicCreators",
            //    column: "CreatorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ComicEvents_EventId",
            //    table: "ComicEvents",
            //    column: "EventId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Comics_SeriesId",
            //    table: "Comics",
            //    column: "SeriesId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Stories_ComicId",
            //    table: "Stories",
            //    column: "ComicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ComicCharacters");

            //migrationBuilder.DropTable(
            //    name: "ComicCreators");

            //migrationBuilder.DropTable(
            //    name: "ComicEvents");

            //migrationBuilder.DropTable(
            //    name: "Stories");

            //migrationBuilder.DropTable(
            //    name: "Users");

            //migrationBuilder.DropTable(
            //    name: "Characters");

            //migrationBuilder.DropTable(
            //    name: "Creators");

            //migrationBuilder.DropTable(
            //    name: "Events");

            //migrationBuilder.DropTable(
            //    name: "Comics");

            //migrationBuilder.DropTable(
            //    name: "Series");
        }
    }
}
