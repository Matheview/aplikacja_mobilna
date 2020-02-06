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
        public List<Vehicle> Vehicles { get; set; }

        public CarList()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();

            Vehicles = new List<Vehicle>();
            VehicleListView.ItemsSource = Vehicles;
        }

        async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            
            await DisplayAlert(Vehicles[e.ItemIndex].Make, Vehicles[e.ItemIndex].Model, "OK");
            ((ListView)sender).SelectedItem = null;
        }

        private void AddNewVehicle_Clicked(object sender, EventArgs e)
        {
            Vehicle newVehicle = new Vehicle();
            newVehicle.Make = "Nowy pojazd";

            Vehicles.Add(newVehicle);

            VehicleListView.ItemsSource = null;
            VehicleListView.ItemsSource = Vehicles;
        }

        private void DeleteVehicle_Clicked(object sender, EventArgs e)
        {
            Vehicles.Remove(((Button)sender).BindingContext as Vehicle);

            VehicleListView.ItemsSource = null;
            VehicleListView.ItemsSource = Vehicles;
        }
    }
}
