using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class SavingDto
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public string FromAccountName { get; set; }

        public string ToAccountName { get; set; }

        public string GoalName { get; set; }
    }
}