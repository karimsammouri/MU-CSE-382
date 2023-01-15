using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DBSetup {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StudentPage : ContentPage {
		public StudentPage() {
			InitializeComponent();
		}

		private void OnQueryClicked(object sender, EventArgs e) {
			Button b = (Button)sender;
			var theTable = MainPage.conn.Table<CreateDB.Student>();
			switch (b.Text) {
				case "Q1":
					lv.ItemsSource = theTable.ToList();
					break;
				case "Q2":
					lv.ItemsSource = theTable.Where(s => s.GPA >= 3.0).ToList();
					break;
				case "Q3":
					lv.ItemsSource = theTable.Where(s => s.GPA >= 3.0).Select(s => s.LastName).ToList();
					break;
				case "Q4":
					lv.ItemsSource = theTable.Select(s => new Tuple<string, string>(s.FirstName, s.LastName)).ToList();
					break;
				case "Q5":
					lv.ItemsSource = theTable.AsEnumerable().Where(s => s.GPA >= 3.0 && s.LastName[0] == 'S').ToList();
					break;
				case "Q6":
					lv.ItemsSource = theTable.OrderBy(s => s.GPA).ToList();
					break;
				case "Q7":
					lv.ItemsSource = (from s in theTable where s.GPA >= 3.0 select s).ToList();
					break;
				case "Q8":
					lv.ItemsSource = theTable.Where(s => s.Legacy == true).ToList();
					break;
				case "Q9":
                    lv.ItemsSource = theTable.Where(s => s.Legacy == true).Select(s => s.LastName).ToList();
                    break;
				case "Q10":
                    lv.ItemsSource = theTable.Where(s => s.Legacy == true || s.GPA >= 3.0).Select(s => s.LastName).ToList();
                    break;
			}
		}
	}
}