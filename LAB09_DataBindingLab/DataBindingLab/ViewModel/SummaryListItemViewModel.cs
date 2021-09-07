using DataBindingLab.Model;
using System;
using System.ComponentModel;

namespace DataBindingLab.ViewModel
{
    public class SummaryListItemViewModel : ObservableObjectBase
    {
        public Transaction Model { get; private set; }

        public SummaryListItemViewModel(Transaction model)
        {
            Model = model;
            model.PropertyChanged += Model_PropertyChanged;
        }

        public SummaryListItemViewModel()
        {
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Model.Description) ||
                e.PropertyName == nameof(Model.Value))
            {
                Notify(nameof(Summary));
            }
            if (e.PropertyName == nameof(Model.Value))
            {
                Notify(nameof(IsExpense));
            }
            if (e.PropertyName == nameof(Model.Category))
            {
                Notify(nameof(Summary));
                Notify(nameof(IsLuxury));
            }
        }

        public string Summary => $"{Model.Description} ({Model.Category.Name}): {Math.Abs(Model.Value)}";

        public bool IsExpense => Model.Value < 0;

        public bool IsLuxury => Model.Category.IsLuxury;
    }
}
