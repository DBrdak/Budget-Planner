using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBudgetAccessor
    {
        Task<string> GetBudgetName();

        Task<Guid> GetBudgetId();

        Task<Budget> GetBudget();
    }
}