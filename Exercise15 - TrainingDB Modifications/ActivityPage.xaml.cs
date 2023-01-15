using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrainingDB {
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityPage : ContentPage {
        public ActivityPage() {
            InitializeComponent();
            for (int h = 0; h < 12; h++)
                hours.Items.Add(h.ToString());
            hours.SelectedIndex = 0;
            for (int m = 0; m < 60; m++)
                minutes.Items.Add(m.ToString());
            minutes.SelectedIndex = 21;
            lvActivities.ItemsSource = DB.conn.Table<Activity>().ToList();
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            ResetListViewSources();
        }
        private void ResetListViewSources() {
            lvActivities.ItemsSource = DB.conn.Table<Activity>().ToList();
        }
        private void AddClicked(object sender, EventArgs e) {
            Activity activity = new Activity {
                DatePerformed = date.Date,
                Sport = (string)sport.SelectedItem,
                Duration = new TimeSpan(Int32.Parse((string)hours.SelectedItem),
                                        Int32.Parse((string)minutes.SelectedItem), 0)
            };
            DB.conn.Insert(activity);
            ResetListViewSources();
        }
        private void UpdateClicked(object sender, EventArgs e) {
            Activity oldActivity = lvActivities.SelectedItem as Activity;
            Activity newActivity = new Activity {
                DatePerformed = date.Date,
                Sport = (string)sport.SelectedItem,
                Duration = new TimeSpan(Int32.Parse((string)hours.SelectedItem),
                                        Int32.Parse((string)minutes.SelectedItem), 0)
            };
            newActivity.Id = oldActivity.Id;
            DB.conn.Update(newActivity);
            ResetListViewSources();
        }

        private void DeleteClicked(object sender, EventArgs e) {
            Activity activity = lvActivities.SelectedItem as Activity;
            if (activity != null) {
                int v = DB.conn.Delete(activity);
                if (v > 0) {
                    lvActivities.SelectedItem = null;
                    ResetListViewSources();
                }
            }
        }

        private void ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            Activity activity = lvActivities.SelectedItem as Activity;
            if (activity != null) {
                date.Date = activity.DatePerformed;
                hours.SelectedItem = activity.Duration.Hours.ToString();
                minutes.SelectedItem = activity.Duration.Minutes.ToString();
                sport.SelectedItem = activity.Sport;
            }
        }
    }
}