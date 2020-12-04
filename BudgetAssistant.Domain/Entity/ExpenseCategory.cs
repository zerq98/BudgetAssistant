namespace BudgetAssistant.Domain.Entity
{
    public class ExpenseCategory : BaseEntity
    {
        public string Name { get; set; }

        public bool CanRemove { get; set; }
    }
}