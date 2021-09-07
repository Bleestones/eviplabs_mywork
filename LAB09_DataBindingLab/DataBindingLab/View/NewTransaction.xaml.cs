using DataBindingLab.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DataBindingLab.View
{
    public sealed partial class NewTransaction : UserControl
    {
        private TransactionList transactions;

        public CategoryList Categories { get; set; }

        #region Values entered into the form
        public int SelectedCategoryIndex { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        #endregion

        public NewTransaction()
        {
            this.InitializeComponent();
        }

        internal void SetModel(ExpenseManager expenseManager)
        {
            this.transactions = expenseManager.Transactions;
            this.Categories = expenseManager.Categories;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
