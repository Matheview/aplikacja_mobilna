using MotoMobile.Database;
using MotoMobile.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MotoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditVehicle : ContentPage
    {
        private ListView VehicleList;
        private Vehicle Vehicle;

        public EditVehicle(ref ListView vehicleList, Vehicle vehicle)
        {
            VehicleList = vehicleList;
            Vehicle = vehicle;

            InitializeComponent();

            LoadValues();
        }

        private void LoadValues()
        {
            VehicleTypePick.ItemsSource = Data.VehicleTypes;

            Make.Text = Vehicle.Make;
            Model.Text = Vehicle.Model;
            
            if(Vehicle.Year > 0)
            {
                Year.Text = Vehicle.Year.ToString();
            }
            
            if(Vehicle.VehicleType != null)
            {
                VehicleTypePick.SelectedIndex = Vehicle.VehicleType.ID;
            }
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            Vehicle.Make = Make.Text;
            Vehicle.Model = Model.Text;
            Vehicle.Year = Convert.ToInt32(Year.Text);
            Vehicle.VehicleType = VehicleTypePick.SelectedItem as VehicleType;

            CloseView();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            Data.Vehicles.Remove(Vehicle);

            CloseView();
        }

        private async void CloseView()
        {
            VehicleList.ItemsSource = null;
            VehicleList.ItemsSource = Data.Vehicles;

            await Navigation.PopModalAsync();
        }
    }
}