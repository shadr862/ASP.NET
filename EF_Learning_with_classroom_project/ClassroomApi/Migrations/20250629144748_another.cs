using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassroomApi.Migrations
{
    /// <inheritdoc />
    public partial class another : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "ClassroomDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ClassroomDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "ClassroomDetails",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "ClassroomDetails");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ClassroomDetails");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "ClassroomDetails");
        }
    }
}
