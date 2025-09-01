using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_FrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Man_Salary",
                table: "Managers");

            migrationBuilder.RenameColumn(
                name: "Man_Name",
                table: "Managers",
                newName: "Man_LName");

            migrationBuilder.RenameColumn(
                name: "Man_Email",
                table: "Managers",
                newName: "Man_FName");

            migrationBuilder.RenameColumn(
                name: "Emp_Name",
                table: "Employees",
                newName: "Emp_LName");

            migrationBuilder.RenameColumn(
                name: "Emp_Email",
                table: "Employees",
                newName: "Emp_FName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.CreateTable(
                name: "EmployeeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_EmployeeId",
                table: "EmployeeDetails",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDetails");

            migrationBuilder.RenameColumn(
                name: "Man_LName",
                table: "Managers",
                newName: "Man_Name");

            migrationBuilder.RenameColumn(
                name: "Man_FName",
                table: "Managers",
                newName: "Man_Email");

            migrationBuilder.RenameColumn(
                name: "Emp_LName",
                table: "Employees",
                newName: "Emp_Name");

            migrationBuilder.RenameColumn(
                name: "Emp_FName",
                table: "Employees",
                newName: "Emp_Email");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Man_Salary",
                table: "Managers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
