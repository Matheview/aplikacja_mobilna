using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MotoMobile.Models
{
    /*public class Car
    {
        public string Make { get; }

        public string Model { get; }

        public short Year { get; }

        public string ListModel
        {
            get
            {
                return $"{Model} {Year}";
            }
        }

        public Car(string make, string model, short year)
        {
            Make = make;
            Model = model;
            Year = year;
        }
    }*/
    [Table("Car")]
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(64)]
        public string Make { get; set; }
        [MaxLength(64)]
        public string Model { get; set; }
        public int Year { get; set; }

    }

    [Table("Spends")]
    public class Spends
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(128)]
        public string Title { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.CascadeDelete)]
        public List<Car> Car { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.CascadeDelete)]
        public List<SpendType> SpendType { get; set; }

        public float Spend { get; set; }

        public DateTime Date { get; set; }

    }

    [Table("SpendType")]
    public class SpendType
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(128)]
        public string Spenddesc { get; set; }
    }

}
