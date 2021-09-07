using DataBindingLab.Model;
using DataBindingLab.ViewModel;
using Windows.UI.Xaml.Controls;

namespace DataBindingLab.View
{
    public sealed partial class SummaryList : UserControl
    {
        public SummaryListViewModel List { get; private set; }
        public SummaryList()
        {
            this.InitializeComponent();
        }

        public void SetModel(ExpenseManager expenseManager)
        {
            this.List = new SummaryListViewModel(expenseManager.Transactions);
        }
    }
}
