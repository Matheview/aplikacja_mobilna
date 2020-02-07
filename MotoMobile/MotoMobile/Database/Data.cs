using MotoMobile.Models;
using System;
using System.Collections.Generic;

namespace MotoMobile.Database
{
    public static class Data
    {
        public readonly static List<VehicleType> VehicleTypes = new List<VehicleType>()
        {
            new VehicleType() { ID = 0, Description = "Motocykl", ImageSource = "moto.png" },
            new VehicleType() { ID = 1, Description = "Samochód osobowy", ImageSource = "car.png" },
            new VehicleType() { ID = 2, Description = "Samochód dostawczy", ImageSource = "truck.png" },
        };

        public readonly static List<ExpenseType> ExpenseTypes = new List<ExpenseType>()
        {
            new ExpenseType() { ID = 0, Description = "Paliwo" },
            new ExpenseType() { ID = 1, Description = "Części" },
            new ExpenseType() { ID = 2, Description = "Mechanik" },
            new ExpenseType() { ID = 3, Description = "Ubezpieczenie" },
            new ExpenseType() { ID = 4, Description = "Inne" },
        };

        public static List<Vehicle> Vehicles = new List<Vehicle>()
        {
            new Vehicle() { ID = 0, Make = "BMW", Model = "M3", Year = 2006, VehicleType = VehicleTypes.Find(x => x.ID == 1) }
        };

        public static List<Expense> Expenses = new List<Expense>()
        {
            new Expense() { ID = 0, Title = "Paliwo", Vehicle = Vehicles.Find(x => x.ID == 0), ExpenseType = ExpenseTypes.Find(x => x.ID == 0), Amount = 400, Date = DateTime.Now.Date }
        };
    }
}
