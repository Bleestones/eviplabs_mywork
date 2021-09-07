using System.ComponentModel;

namespace DataBindingLab.Model
{
    public class Transaction : ObservableObjectBase
    {
        private int value;
        public int Value
        {
            get => value;
            set => SetAndNotifyIfChanged(ref this.value, value);
        }

        private string description;
        public string Description
        {
            get => description;
            set => SetAndNotifyIfChanged(ref this.description, value);
        }

        private Category category;
        public Category Category
        {
            get => category;
            set => SetAndNotifyIfChanged(ref this.category, value);
        }
    }
}
