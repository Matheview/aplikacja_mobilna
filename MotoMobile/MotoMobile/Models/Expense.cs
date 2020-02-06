using MotoMobile.Interfaces;
using SQLite;

namespace MotoMobile.Models
{
    [Table("Expenses")]
    public class Expense : IDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Title { get; set; }

        public int Vehicle { get; set; }

        public int ExpenseType { get; set; }

        public double Amount { get; set; }

        public int Date { get; set; }
    }
}
