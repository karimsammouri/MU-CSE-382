using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrainingDB {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RetrievalPage : ContentPage {
		public RetrievalPage() {
			InitializeComponent();
		}
        protected override void OnAppearing() {
            base.OnAppearing();
            lvActivities.ItemsSource = null;
        }
        private void SportSelected(object sender, EventArgs e) {
            string S = (string)sport.SelectedItem;
            lvActivities.ItemsSource = DB.conn.Table<Activity>().Where(a => a.Sport.Equals(S));
        }

    }
}