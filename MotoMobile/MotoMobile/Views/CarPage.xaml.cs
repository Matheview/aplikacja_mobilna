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
    public partial class CarPage : ContentPage
    {
        readonly Car Car;

        public CarPage(Car car)
        {
            InitializeComponent();

            Car = car;

            BindingContext = Car;
        }
    }
}