using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_FrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Managers",
                newName: "ManagerId");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Managers_ManagerId",
                table: "Employees",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Managers_ManagerId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Managers",
                newName: "Id");
        }
    }
}
