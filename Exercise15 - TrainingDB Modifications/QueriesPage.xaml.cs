using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrainingDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QueriesPage : ContentPage
    {
        public QueriesPage()
        {
            InitializeComponent();
        }
        private void OnClicked(object sender, EventArgs e)
        {
            TimeSpan hour = new TimeSpan(1, 0, 0);
            Button button = (Button)sender;
            if (button.Text == "1hr Runs")
            {
                lv.ItemsSource = from activity in DB.conn.Table<Activity>()
                                 where activity.Sport.Equals("Running")
                                 where activity.Duration > hour
                                 select activity;
            }
            if (button.Text == "1hr Run (Dates Only)")
            {
                lv.ItemsSource = from activity in DB.conn.Table<Activity>()
                                 where activity.Sport.Equals("Running")
                                 where activity.Duration > hour
                                 select activity.DatePerformed;
            }
            if (button.Text == "1hr (Dates and Duration)")
            {
                lv.ItemsSource = from activity in DB.conn.Table<Activity>()
                                 where activity.Sport.Equals("Running")
                                 where activity.Duration > hour
                                 select (activity.DatePerformed, activity.Duration);
            }
            if (button.Text == "Long Run")
            {
                lv.ItemsSource = from activity in DB.conn.Table<Activity>()
                                 where activity.Sport.Equals("Running")
                                 where activity.Duration > hour
                                 select activity;
            }
            if (button.Text == "500+ Calories")
            {
                lv.ItemsSource = from activity in DB.conn.Table<Activity>().AsEnumerable()
                                 where activity.GetCalories() >= 500
                                 select activity;
            }
        }
    }
}