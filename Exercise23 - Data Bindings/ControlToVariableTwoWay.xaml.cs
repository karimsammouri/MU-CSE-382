using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bindings {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class ModelData : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public string str = "";
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Label {
            get {
                return str;
            }
            set {
                if (str != value) {
                    str = value;
                    RaisePropertyChanged();
                }
            }
        }
    }

    public partial class ControlToVariableTwoWay : ContentPage {
        public ModelData data = new ModelData();
        public ControlToVariableTwoWay() {
            InitializeComponent();
            Device.StartTimer(new TimeSpan(0, 0, 2), OnTimerExpired);
            Binding stringBinding = new Binding();
            stringBinding.Mode = BindingMode.TwoWay;
            stringBinding.Source = data;
            stringBinding.Path = "Label";
            theEntry.SetBinding(Entry.TextProperty, stringBinding);
        }
        public bool OnTimerExpired() {
            data.Label += "x";
            if (data.Label.Length >= 15)
                data.Label = "A";
            return true;
        }
    }
}