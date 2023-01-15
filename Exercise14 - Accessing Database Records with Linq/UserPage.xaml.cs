using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DBSetup {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserPage : ContentPage {
		public UserPage() {
			InitializeComponent();
		}

		private void OnQueryClicked(object sender, EventArgs e) {
			Button b = (Button)sender;
			var theTable = MainPage.conn.Table<CreateDB.User>();
			switch (b.Text) {
				case "Q1":
					lv.ItemsSource = theTable.ToList();
                    break;
				case "Q2":
					DateTime date = new DateTime(2010, 1, 1);
                    lv.ItemsSource = theTable.Where(s => s.DateCreated >= date).ToList();
                    break;
                case "Q3":
					lv.ItemsSource = theTable.AsEnumerable().Where(s => s.Username[0] == 'j').ToList();
					break;
			}

		}
	}
}