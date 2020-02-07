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
    public partial class CostAnalysis : ContentPage
    {
        private List<Expense> Expenses;
        private ExpenseFilter ExpenseFilter;

        public CostAnalysis()
        {
            ExpenseFilter = new ExpenseFilter();

            InitializeComponent();

            Expenses = Data.Expenses;
            ExpenseListView.ItemsSource = Expenses;
        }

        private void AddNewExpense_Clicked(object sender, EventArgs e)
        {
            Expense newExpense = new Expense();
            newExpense.ID = Data.Expenses.Max(x => x.ID) + 1;
            newExpense.Title = "Nowy wydatek";
            newExpense.Date = DateTime.Now.Date;

            Data.Expenses.Add(newExpense);

            ExpenseListView.ItemsSource = null;
            ExpenseListView.ItemsSource = Expenses;
        }

        private async void ExpenseListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await Navigation.PushModalAsync(new EditExpense(ref ExpenseListView, Expenses, Expenses[e.ItemIndex]));
            ((ListView)sender).SelectedItem = null;
        }

        private async void Filter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new FilterExpenses(ref ExpenseListView, ref Expenses, ref ExpenseFilter));
        }
    }
}