using MotoMobile.Interfaces;
using SQLite;

namespace MotoMobile.Models
{
    [Table("Vehicles")]
    public class Vehicle : IDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int VehicleType { get; set; }
    }
}
