using System;
using System.Collections.Generic;
using System.Text;

namespace MotoMobile.Models
{
    public class VehicleUI
    {
        public int ID { get; }

        public string Name { get; }

        public VehicleUI(Vehicle vehicle)
        {
            ID = vehicle.ID;
            Name = $"{vehicle.Make} {vehicle.Model}";
        }
    }
}
