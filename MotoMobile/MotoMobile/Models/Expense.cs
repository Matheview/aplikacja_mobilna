using SQLite;
using System;

namespace MotoMobile.Models
{
    [Table("Expenses")]
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(128)]
        public string Title { get; set; }

        public Vehicle Vehicle { get; set; }

        public ExpenseType ExpenseType { get; set; }

        public float Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
