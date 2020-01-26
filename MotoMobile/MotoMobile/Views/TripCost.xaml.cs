using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MotoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TripCost : ContentPage
    {
        public TripCost()
        {
            InitializeComponent();
        }

        void OnCalculateClick(object sender, EventArgs args)
        {
            float distance = float.Parse(Distance.Text, CultureInfo.InvariantCulture);
            float price = float.Parse(Price.Text, CultureInfo.InvariantCulture);
            float fuelUsage = float.Parse(FuelUsage.Text, CultureInfo.InvariantCulture);

            float totalCost = (distance / 100) * fuelUsage * price;

            TotalCost.Text = totalCost.ToString("0.00") + " zł";
        }
    }
}