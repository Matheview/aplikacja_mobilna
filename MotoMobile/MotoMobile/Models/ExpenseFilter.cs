using System;
using System.Collections.Generic;
using System.Text;

namespace MotoMobile.Models
{
    public class ExpenseFilter
    {
        public string Title { get; set; }

        public int? AmountFrom { get; set; }

        public int? AmountTo { get; set; }

        public Vehicle Vehicle { get; set; }

        public ExpenseType ExpenseType { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public ExpenseFilter()
        {
            DateFrom = DateTime.MinValue;
            DateTo = DateTime.MaxValue;
        }
    }
}
