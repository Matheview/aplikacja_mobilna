using MotoMobile.Database;
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
    public partial class FilterExpenses : ContentPage
    {
        private ListView ExpenseList;
        private List<Expense> FilteredExpenses;
        private ExpenseFilter ExpenseFilter;

        public FilterExpenses(ref ListView expenseList, ref List<Expense> filteredExpenses, ref ExpenseFilter filter)
        {
            ExpenseList = expenseList;
            FilteredExpenses = filteredExpenses;
            ExpenseFilter = filter;

            InitializeComponent();

            LoadValues();
        }

        private void LoadValues()
        {
            ExpenseTypePick.ItemsSource = Data.ExpenseTypes;
            VehiclePick.ItemsSource = Data.Vehicles.ConvertAll(x => { return new VehicleUI(x); });

            Title.Text = ExpenseFilter.Title;
            AmountFrom.Text = ExpenseFilter.AmountFrom.ToString();
            AmountTo.Text = ExpenseFilter.AmountTo.ToString();

            if (ExpenseFilter.Vehicle != null)
            {
                VehiclePick.SelectedIndex = Data.Vehicles.IndexOf(ExpenseFilter.Vehicle);
            }

            if (ExpenseFilter.ExpenseType != null)
            {
                ExpenseTypePick.SelectedIndex = ExpenseFilter.ExpenseType.ID;
            }

            DatePickFrom.Date = ExpenseFilter.DateFrom;
            DatePickTo.Date = ExpenseFilter.DateTo;
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void Filter_Clicked(object sender, EventArgs e)
        {
            FilteredExpenses = Data.Expenses;

            if(!Title.Text.Equals(""))
            {
                ExpenseFilter.Title = Title.Text;

                FilteredExpenses = FilteredExpenses.FindAll(x => x.Title.ToLower().Contains(ExpenseFilter.Title.ToLower()));
            }

            if(!AmountFrom.Text.Equals(""))
            {
                ExpenseFilter.AmountFrom = Convert.ToInt32(AmountFrom.Text);

                FilteredExpenses = FilteredExpenses.FindAll(x => x.Amount >= ExpenseFilter.AmountFrom);
            }
            else
            {
                ExpenseFilter.AmountFrom = null;
            }

            if(!AmountTo.Text.Equals(""))
            {
                ExpenseFilter.AmountTo = Convert.ToInt32(AmountTo.Text);

                FilteredExpenses = FilteredExpenses.FindAll(x => x.Amount <= ExpenseFilter.AmountTo);
            }
            else
            {
                ExpenseFilter.AmountTo = null;
            }

            if (VehiclePick.SelectedItem != null)
            {
                ExpenseFilter.Vehicle = Data.Vehicles[VehiclePick.SelectedIndex];

                FilteredExpenses = FilteredExpenses.FindAll(x => x.Vehicle == ExpenseFilter.Vehicle);
            }

            if(ExpenseTypePick.SelectedItem != null)
            {
                ExpenseFilter.ExpenseType = ExpenseTypePick.SelectedItem as ExpenseType;

                FilteredExpenses = FilteredExpenses.FindAll(x => x.ExpenseType == ExpenseFilter.ExpenseType);
            }

            if(DatePickFrom.Date != DatePickFrom.MinimumDate)
            {
                ExpenseFilter.DateFrom = DatePickFrom.Date;

                FilteredExpenses = FilteredExpenses.FindAll(x => x.Date >= ExpenseFilter.DateFrom);
            }

            if(DatePickTo.Date != DatePickTo.MaximumDate)
            {
                ExpenseFilter.DateTo = DatePickTo.Date;

                FilteredExpenses = FilteredExpenses.FindAll(x => x.Date <= ExpenseFilter.DateTo);
            }

            ExpenseList.ItemsSource = null;
            ExpenseList.ItemsSource = FilteredExpenses;

            await Navigation.PopModalAsync();
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            ExpenseFilter = new ExpenseFilter();

            Title.Text = "";
            AmountFrom.Text = "";
            AmountTo.Text = "";
            VehiclePick.SelectedItem = null;
            ExpenseTypePick.SelectedItem = null;
            DatePickFrom.Date = DatePickFrom.MinimumDate;
            DatePickTo.Date = DatePickTo.MaximumDate;

            FilteredExpenses = Data.Expenses;
        }
    }
}