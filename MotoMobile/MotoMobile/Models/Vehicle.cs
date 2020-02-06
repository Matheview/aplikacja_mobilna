using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MotoMobile.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(64)]
        public string Make { get; set; }
        [MaxLength(64)]
        public string Model { get; set; }
        public int Year { get; set; }

        public VehicleType VehicleType { get; set; }
    }
}
