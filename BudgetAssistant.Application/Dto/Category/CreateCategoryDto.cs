using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAssistant.Application.Dto.Category
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
