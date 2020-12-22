using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetAssistant.Infrastructure.Migrations
{
    public partial class AddValueColumnInExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "Expenses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Expenses",
                table: "ExpenseCategories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Expenses",
                table: "ExpenseCategories");
        }
    }
}
