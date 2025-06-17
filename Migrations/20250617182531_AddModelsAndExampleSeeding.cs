using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI_Conferences.Migrations
{
    /// <inheritdoc />
    public partial class AddModelsAndExampleSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxPeople = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.IdEvent);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    IdParticipant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.IdParticipant);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    IdSpeaker = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.IdSpeaker);
                });

            migrationBuilder.CreateTable(
                name: "Participant_Event",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "int", nullable: false),
                    IdParticipant = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant_Event", x => new { x.IdEvent, x.IdParticipant });
                    table.ForeignKey(
                        name: "FK_Participant_Event_Events_IdEvent",
                        column: x => x.IdEvent,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_Event_Participants_IdParticipant",
                        column: x => x.IdParticipant,
                        principalTable: "Participants",
                        principalColumn: "IdParticipant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speaker_Event",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "int", nullable: false),
                    IdSpeaker = table.Column<int>(type: "int", nullable: false),
                    SpeakingTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker_Event", x => new { x.IdEvent, x.IdSpeaker });
                    table.ForeignKey(
                        name: "FK_Speaker_Event_Events_IdEvent",
                        column: x => x.IdEvent,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Speaker_Event_Speakers_IdSpeaker",
                        column: x => x.IdSpeaker,
                        principalTable: "Speakers",
                        principalColumn: "IdSpeaker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "Date", "Description", "MaxPeople", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "A conference about the latest tech.", 100, "Tech Conference 2025" },
                    { 2, new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hands-on workshop on AI.", 50, "AI Workshop" }
                });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "IdParticipant", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", "Doe" },
                    { 2, "anna.k@example.com", "Anna", "Kowalska" },
                    { 3, "mike.j@example.com", "Mike", "Johnson" },
                    { 4, "sara.s@example.com", "Sara", "Smith" },
                    { 5, "tom.c@example.com", "Tom", "Clark" },
                    { 6, "ewa.n@example.com", "Ewa", "Nowak" },
                    { 7, "liam.b@example.com", "Liam", "Brown" },
                    { 8, "olga.z@example.com", "Olga", "Zielińska" },
                    { 9, "peter.a@example.com", "Peter", "Adams" },
                    { 10, "marta.w@example.com", "Marta", "Wiśniewska" }
                });

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "IdSpeaker", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "alice@example.com", "Alice", "Johnson" },
                    { 2, "bob@example.com", "Bob", "Smith" },
                    { 3, "carol@example.com", "Carol", "Davis" },
                    { 4, "david@example.com", "David", "Lee" }
                });

            migrationBuilder.InsertData(
                table: "Participant_Event",
                columns: new[] { "IdEvent", "IdParticipant", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 3, new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 4, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 5, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Speaker_Event",
                columns: new[] { "IdEvent", "IdSpeaker", "SpeakingTime" },
                values: new object[,]
                {
                    { 1, 1, 45 },
                    { 1, 2, 30 },
                    { 2, 3, 60 },
                    { 2, 4, 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participant_Event_IdParticipant",
                table: "Participant_Event",
                column: "IdParticipant");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_Event_IdSpeaker",
                table: "Speaker_Event",
                column: "IdSpeaker");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participant_Event");

            migrationBuilder.DropTable(
                name: "Speaker_Event");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Speakers");
        }
    }
}
