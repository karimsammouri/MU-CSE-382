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
    public class MyData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int data;
        public int Value
        {
            get
            {
                return data;
            }
            set
            {
                if (data != value)
                {
                    data = value;
                    RaisePropertyChanged();
                }
            }
        }
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class MyPoint : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public double dataX;
        public double X
        {
            get
            {
                return dataX;
            }
            set
            {
                if (dataX != value)
                {
                    dataX = value;
                    RaisePropertyChanged();
                }
            }
        }
        public double dataY;
        public double Y
        {
            get
            {
                return dataY;
            }
            set
            {
                if (dataY != value)
                {
                    dataY = value;
                    RaisePropertyChanged();
                }
            }
        }
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public partial class VariableToControlBinding : ContentPage {
        MyData myData = new MyData { Value = 0 };
        Random rnd = new Random();
        MyPoint point = new MyPoint{ X = 0, Y = 0};
        public VariableToControlBinding() {
            InitializeComponent();
            varValue.SetBinding(Label.TextProperty, new Binding { Source = myData, Path = "Value" });
            x.SetBinding(Label.TextProperty, new Binding { Source = point, Path = "X" });
            y.SetBinding(Label.TextProperty, new Binding { Source = point, Path = "Y" });
            Device.StartTimer(new TimeSpan(0, 0, 1), () => { myData.Value += 1;
                point.X = rnd.NextDouble();
                point.Y = rnd.NextDouble();
                return true; });
        }
    }
}
