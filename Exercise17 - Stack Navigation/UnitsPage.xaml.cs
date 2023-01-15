using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace StackNavigation
{
    public partial class UnitsPage : ContentPage
    {
        public UnitsPage()
        {
            InitializeComponent();
            if (!Preferences.ContainsKey("MetricMode"))
                Preferences.Set("MetricMode", false);
            metricSwitch.IsToggled = Preferences.Get("MetricMode", false);
        }

        void MetricSwitchToggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            Preferences.Set("MetricMode", metricSwitch.IsToggled);
        }
    }
}

