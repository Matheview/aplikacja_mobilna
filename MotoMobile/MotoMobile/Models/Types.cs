using System.Collections.Generic;

namespace MotoMobile.Models
{
    public static class Types
    {
        public static List<VehicleType> VehicleTypes = new List<VehicleType>()
        {
            new VehicleType() { Description = "Motocykl" },
            new VehicleType() { Description = "Samochód osobowy" },
            new VehicleType() { Description = "Samochód dostawczy" },
        };

        public static List<ExpenseType> ExpenseTypes = new List<ExpenseType>()
        {
            new ExpenseType() { Description = "Paliwo" },
            new ExpenseType() { Description = "Części" },
            new ExpenseType() { Description = "Mechanik" },
            new ExpenseType() { Description = "Ubezpieczenie" },
            new ExpenseType() { Description = "Inne" },
        };
    }
}
