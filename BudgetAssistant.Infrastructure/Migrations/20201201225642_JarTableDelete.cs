using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetAssistant.Infrastructure.Migrations
{
    public partial class JarTableDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseCategories_Jars_JarId",
                table: "ExpenseCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Jars_JarId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "Jars");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_JarId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseCategories_JarId",
                table: "ExpenseCategories");

            migrationBuilder.DropColumn(
                name: "JarId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "JarId",
                table: "ExpenseCategories");

            migrationBuilder.RenameColumn(
                name: "Savings",
                table: "Budgets",
                newName: "TotalSavings");

            migrationBuilder.AddColumn<double>(
                name: "MonthSavings",
                table: "Budgets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthSavings",
                table: "Budgets");

            migrationBuilder.RenameColumn(
                name: "TotalSavings",
                table: "Budgets",
                newName: "Savings");

            migrationBuilder.AddColumn<int>(
                name: "JarId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JarId",
                table: "ExpenseCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Jars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MoneyLeft = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jars_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_JarId",
                table: "Expenses",
                column: "JarId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCategories_JarId",
                table: "ExpenseCategories",
                column: "JarId");

            migrationBuilder.CreateIndex(
                name: "IX_Jars_ApplicationUserId",
                table: "Jars",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseCategories_Jars_JarId",
                table: "ExpenseCategories",
                column: "JarId",
                principalTable: "Jars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Jars_JarId",
                table: "Expenses",
                column: "JarId",
                principalTable: "Jars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}