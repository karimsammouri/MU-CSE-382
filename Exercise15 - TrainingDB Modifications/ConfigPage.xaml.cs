using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrainingDB {
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigPage : ContentPage {
        public ConfigPage() {
            InitializeComponent();
        }
        private void ResetListViewSources() {
            lvActivities.ItemsSource = DB.conn.Table<Activity>().ToList();
            lvLongDefs.ItemsSource = DB.conn.Table<LongActivityDefinition>().ToList();
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            ResetListViewSources();
        }
        private void ResetClicked(object sender, EventArgs e) {
            DB.RepopulateTables();
            ResetListViewSources();
        }
    }
}