namespace DataBindingLab.Model
{
    public class Category :ObservableObjectBase
    {
        private string name;
        public string Name
        {
            get => name;
            set => SetAndNotifyIfChanged(ref name, value);
        }

        private bool isLuxury;
        public bool IsLuxury
        {
            get => isLuxury;
            set => SetAndNotifyIfChanged(ref isLuxury, value);
        }

        private string IsLuxuryAsString => IsLuxury ? "LUXURY" : "";
        public override string ToString() => $"{Name} {IsLuxuryAsString}";
    }
}
