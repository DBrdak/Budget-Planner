﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FutureTransaction
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Frequency { get; set; }
        public Account Account { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}