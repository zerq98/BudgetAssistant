using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetAssistant.Infrastructure.Migrations
{
    public partial class AddExpenseList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Expenses",
                table: "ExpenseCategories",
                newName: "TotalExpensesValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalExpensesValue",
                table: "ExpenseCategories",
                newName: "Expenses");
        }
    }
}
