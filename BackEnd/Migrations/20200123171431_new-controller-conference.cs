using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class newcontrollerconference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceAttendee_Conference_ConferenceId",
                table: "ConferenceAttendee");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Conference_ConferenceId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Conference_ConferenceId",
                table: "Speakers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Conference_ConferenceId",
                table: "Tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conference",
                table: "Conference");

            migrationBuilder.RenameTable(
                name: "Conference",
                newName: "Conferences");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conferences",
                table: "Conferences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceAttendee_Conferences_ConferenceId",
                table: "ConferenceAttendee",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Conferences_ConferenceId",
                table: "Sessions",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Conferences_ConferenceId",
                table: "Speakers",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Conferences_ConferenceId",
                table: "Tracks",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceAttendee_Conferences_ConferenceId",
                table: "ConferenceAttendee");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Conferences_ConferenceId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Conferences_ConferenceId",
                table: "Speakers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Conferences_ConferenceId",
                table: "Tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conferences",
                table: "Conferences");

            migrationBuilder.RenameTable(
                name: "Conferences",
                newName: "Conference");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conference",
                table: "Conference",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceAttendee_Conference_ConferenceId",
                table: "ConferenceAttendee",
                column: "ConferenceId",
                principalTable: "Conference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Conference_ConferenceId",
                table: "Sessions",
                column: "ConferenceId",
                principalTable: "Conference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Conference_ConferenceId",
                table: "Speakers",
                column: "ConferenceId",
                principalTable: "Conference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Conference_ConferenceId",
                table: "Tracks",
                column: "ConferenceId",
                principalTable: "Conference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
