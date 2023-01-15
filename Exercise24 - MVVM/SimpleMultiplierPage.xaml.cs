using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVM {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleMultiplierPage : ContentPage {
        public SimpleMultiplierPage() {
            InitializeComponent();
        }
    }
}