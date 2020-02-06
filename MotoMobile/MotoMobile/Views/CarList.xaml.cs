using MotoMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using MotoMobile.Controllers;

namespace MotoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarList : ContentPage
    {
        public List<Vehicle> Cars { get; set; }
        public List<ExpenseType> SpendType { get; set; }
        public List<Expense> Spends { get; set; }

        public CarList()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();

            //SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbname);
            //if (File.Exists(dbname))
            //{
            //    var Cars = conn.Table<Vehicle>();
            //}
            //else {
            //    ExpenseType Spendtype = new ExpenseType() { ID = 1, ExpenseDescription = "paliwo" };
            //    ExpenseType Spendtype1 = new ExpenseType() { ID = 2, ExpenseDescription = "części" };
            //    ExpenseType Spendtype2 = new ExpenseType() { ID = 3, ExpenseDescription = "mechanik" };
            //    ExpenseType Spendtype3 = new ExpenseType() { ID = 4, ExpenseDescription = "ubezpieczenie" };
            //    ExpenseType Spendtype4 = new ExpenseType() { ID = 5, ExpenseDescription = "pozostałe" };
            //    Vehicle car = new Vehicle() { Make = "BMW M3", Model = "M3", Year = 2006 };
            //    Vehicle car1 = new Vehicle() { Make = "BMW E46", Model = "E46", Year = 1999 };
            //    {
            //        Console.WriteLine("Creating table");
            //        conn.CreateTableAsync<ExpenseType>();
            //        conn.InsertAsync(Spendtype);
            //        conn.InsertAsync(Spendtype1);
            //        conn.InsertAsync(Spendtype2);
            //        conn.InsertAsync(Spendtype3);
            //        conn.InsertAsync(Spendtype4);
            //        conn.CreateTableAsync<Vehicle>();
            //        conn.InsertAsync(car);
            //    }
            //    // Car car2 = new Car("BMW", "M3", 2006);
            //    Cars = new List<Vehicle>
            //    {
            //        car,
            //        car1
            //    };
            //}

            Cars = DatabaseController.GetAllItems<Vehicle>();

            VehicleListView.ItemsSource = Cars;
        }

        async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            
            await DisplayAlert(Cars[e.ItemIndex].Make, Cars[e.ItemIndex].Model, "OK");
            ((ListView)sender).SelectedItem = null;
        }

        private void AddNewVehicle_Clicked(object sender, EventArgs e)
        {
            Vehicle newVehicle = new Vehicle();
            newVehicle.Make = "Nowy pojazd";
            DatabaseController.InsertItem(newVehicle);

            Cars = DatabaseController.GetAllItems<Vehicle>();

            VehicleListView.ItemsSource = Cars;
        }
    }
}
