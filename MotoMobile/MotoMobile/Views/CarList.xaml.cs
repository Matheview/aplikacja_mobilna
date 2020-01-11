using MotoMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MotoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarList : ContentPage
    {
        public List<Car> Cars { get; set; }

        public CarList()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            Car car = new Car("Citroen", "Xsara", 2003);
            Car car1 = new Car("Audi", "S3", 2003);
            Car car2 = new Car("BMW", "M3", 2006);
            Cars = new List<Car>
            {
                car,
                car1,
                car2
            };

            BindingContext = this;
        }

        async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await Navigation.PushAsync(new CarPage(Cars[e.ItemIndex]));
            ((ListView)sender).SelectedItem = null;
        }
    }
}
