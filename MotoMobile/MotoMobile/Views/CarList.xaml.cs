using MotoMobile.Database;
using MotoMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MotoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarList : ContentPage
    {
        public CarList()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();

            VehicleListView.ItemsSource = Data.Vehicles;
        }

        async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await Navigation.PushModalAsync(new EditVehicle(ref VehicleListView, Data.Vehicles[e.ItemIndex]));
            ((ListView)sender).SelectedItem = null;
        }

        private void AddNewVehicle_Clicked(object sender, EventArgs e)
        {
            Vehicle newVehicle = new Vehicle();
            newVehicle.ID = Data.Vehicles.Max(x => x.ID) + 1;
            newVehicle.Make = "Nowy pojazd";

            Data.Vehicles.Add(newVehicle);

            VehicleListView.ItemsSource = null;
            VehicleListView.ItemsSource = Data.Vehicles;
        }
    }
}
