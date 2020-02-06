using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotoMobile.Models
{
    [Table("ExpenseType")]
    public class ExpenseType
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(128)]
        public string Description { get; set; }
    }
}
