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

namespace MotoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarList : ContentPage
    {
        public List<Car> Cars { get; set; }
        public List<SpendType> SpendType { get; set; }
        public List<Spends> Spends { get; set; }

        public CarList()
        {
            string dbname = "DBSqlite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbname);
            if (File.Exists(dbname))
            {
                var Cars = conn.Table<Car>();
            }
            else {
                SpendType Spendtype = new SpendType() { ID = 1, Spenddesc = "paliwo" };
                SpendType Spendtype1 = new SpendType() { ID = 2, Spenddesc = "części" };
                SpendType Spendtype2 = new SpendType() { ID = 3, Spenddesc = "mechanik" };
                SpendType Spendtype3 = new SpendType() { ID = 4, Spenddesc = "ubezpieczenie" };
                SpendType Spendtype4 = new SpendType() { ID = 5, Spenddesc = "pozostałe" };
                Car car = new Car() { Make = "BMW M3", Model = "M3", Year = 2006 };
                Car car1 = new Car() { Make = "BMW E46", Model = "E46", Year = 1999 };
                {
                    Console.WriteLine("Creating table");
                    conn.CreateTableAsync<SpendType>();
                    conn.InsertAsync(Spendtype);
                    conn.InsertAsync(Spendtype1);
                    conn.InsertAsync(Spendtype2);
                    conn.InsertAsync(Spendtype3);
                    conn.InsertAsync(Spendtype4);
                    conn.CreateTableAsync<Car>();
                    conn.InsertAsync(car);
                }
                // Car car2 = new Car("BMW", "M3", 2006);
                Cars = new List<Car>
                {
                    car,
                    car1
                };
            }
            VehicleListView.ItemsSource = Cars;
        }

        async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            
            await DisplayAlert(Cars[e.ItemIndex].Make, Cars[e.ItemIndex].Model, "OK");
            ((ListView)sender).SelectedItem = null;
        }
    }
}
