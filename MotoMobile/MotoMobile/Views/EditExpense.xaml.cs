using MotoMobile.Database;
using MotoMobile.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MotoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditExpense : ContentPage
    {
        private ListView ExpenseList;
        private Expense Expense;
        private List<Expense> FilteredExpenses;

        public EditExpense(ref ListView expenseList, List<Expense> filteredExpenses, Expense expense)
        {
            ExpenseList = expenseList;
            Expense = expense;
            FilteredExpenses = filteredExpenses;

            InitializeComponent();

            LoadValues();
        }

        private void LoadValues()
        {
            ExpenseTypePick.ItemsSource = Data.ExpenseTypes;
            VehiclePick.ItemsSource = Data.Vehicles.ConvertAll(x => { return new VehicleUI(x); });

            Title.Text = Expense.Title;
            Amount.Text = Expense.Amount.ToString();
            
            if(Expense.Vehicle != null)
            {
                VehiclePick.SelectedIndex = Data.Vehicles.IndexOf(Expense.Vehicle);
            }

            if (Expense.ExpenseType != null)
            {
                ExpenseTypePick.SelectedIndex = Expense.ExpenseType.ID;
            }

            if (Expense.Date != null)
            {
                DatePick.Date = Expense.Date;
            }
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            Expense.Title = Title.Text;
            Expense.Amount = Convert.ToInt32(Amount.Text);
            
            if(VehiclePick.SelectedItem != null)
            {
                Expense.Vehicle = Data.Vehicles[VehiclePick.SelectedIndex];
            }

            if(ExpenseTypePick.SelectedItem != null)
            {
                Expense.ExpenseType = ExpenseTypePick.SelectedItem as ExpenseType;
            }
            
            Expense.Date = DatePick.Date;

            CloseView();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            FilteredExpenses.Remove(Expense);
            Data.Expenses.Remove(Expense);

            CloseView();
        }

        private async void CloseView()
        {
            ExpenseList.ItemsSource = null;
            ExpenseList.ItemsSource = FilteredExpenses;

            await Navigation.PopModalAsync();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            CloseView();
        }
    }
}