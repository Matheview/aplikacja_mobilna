using MotoMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MotoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditVehicle : ContentPage
    {
        ListView VehicleList;
        private Vehicle Vehicle;

        public EditVehicle(ref ListView vehicleList, Vehicle vehicle)
        {
            VehicleList = vehicleList;
            Vehicle = vehicle;

            InitializeComponent();

            LoadValues();
            VehicleTypePick.ItemsSource = Types.VehicleTypes;
        }

        private void LoadValues()
        {
            Make.Text = Vehicle.Make;
            Model.Text = Vehicle.Model;
            Year.Text = Vehicle.Year.ToString();
            VehicleTypePick.SelectedItem = Vehicle.VehicleType;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            Vehicle.Make = Make.Text;
            Vehicle.Model = Model.Text;
            Vehicle.Year = Convert.ToInt32(Year.Text);
            Vehicle.VehicleType = VehicleTypePick.SelectedItem as VehicleType;

            var vehicles = VehicleList.ItemsSource;
            VehicleList.ItemsSource = null;
            VehicleList.ItemsSource = vehicles;

            await Navigation.PopModalAsync();
        }
    }
}