using MotoMobile.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

            RefreshList();
        }

        private void DeleteVehicle_Clicked(object sender, EventArgs e)
        {
            Vehicles.Remove(((Button)sender).BindingContext as Vehicle);

            RefreshList();
        }

        private async void EditVehicle_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EditVehicle(ref VehicleListView, ((Button)sender).BindingContext as Vehicle));
        }

        public void RefreshList()
        {
            VehicleListView.ItemsSource = null;
            VehicleListView.ItemsSource = Vehicles;
        }
    }
}
