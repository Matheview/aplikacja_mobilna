using MotoMobile.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotoMobile.Models
{
    [Table("VehicleTypes")]
    public class VehicleType : IDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Description { get; set; }
    }
}
