using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassroomApi.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Announcements",
                newName: "PostedOn");

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedOn",
                table: "Quizzes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedOn",
                table: "Assignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostedOn",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "PostedOn",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "PostedOn",
                table: "Announcements",
                newName: "CreatedAt");
        }
    }
}
