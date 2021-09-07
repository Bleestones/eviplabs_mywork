using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LAB07_UWP_Basics
{
    public class ObservableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, INotifyPropertyChanged
    {
        private const string IndexerName = "Item[]";

        public new TValue this[TKey key]
        {
            get
            {
                return base[key];
            }
            set
            {
                base[key] = value;
                NotifyPropertyChanged(IndexerName);
                UpdatePolynomDiagram?.Invoke();
                // Update Source manually: ((TextBox)sender).GetBindingExpression(TextBox.TextProperty).UpdateSource();
            }
        }

        public Action UpdatePolynomDiagram;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
