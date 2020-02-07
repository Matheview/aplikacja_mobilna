using System.Collections.Generic;

namespace MotoMobile.Models
{
    public static class Types
    {
        public static List<VehicleType> VehicleTypes = new List<VehicleType>()
        {
            new VehicleType() { ID = 0, Description = "Motocykl", ImageSource = "moto.png" },
            new VehicleType() { ID = 1, Description = "Samochód osobowy", ImageSource = "car.png" },
            new VehicleType() { ID = 2, Description = "Samochód dostawczy", ImageSource = "truck.png" },
        };

        public static List<ExpenseType> ExpenseTypes = new List<ExpenseType>()
        {
            new ExpenseType() { ID = 0, Description = "Paliwo" },
            new ExpenseType() { ID = 1, Description = "Części" },
            new ExpenseType() { ID = 2, Description = "Mechanik" },
            new ExpenseType() { ID = 3, Description = "Ubezpieczenie" },
            new ExpenseType() { ID = 4, Description = "Inne" },
        };
    }
}
