using System;

namespace BudgetAssistant.Domain.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastModified { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}