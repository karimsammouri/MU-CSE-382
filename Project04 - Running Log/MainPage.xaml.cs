using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Xamarin.Essentials;

namespace RunningApp
{
    public partial class MainPage : TabbedPage
    {
        SQLiteConnection conn;
        public static bool kilometers = false;

        public MainPage()
        {
            InitializeComponent();
            string libFolder = FileSystem.AppDataDirectory;
            string fname = System.IO.Path.Combine(libFolder, "Activities.db");
            conn = new SQLiteConnection(fname);
            conn.CreateTable<Activity>();
            conn.CreateTable<Total>();
            databaseView.ItemsSource = conn.Table<Activity>().ToList();
            totalView.ItemsSource = conn.Table<Total>().ToList();

            if (!Preferences.ContainsKey("MetricMode"))
                Preferences.Set("MetricMode", false);
            metricSwitch.IsToggled = Preferences.Get("MetricMode", false);
            if (!Preferences.ContainsKey("GenderPicker"))
                Preferences.Set("GenderPicker", "Male");
            genderPicker.SelectedItem = Preferences.Get("GenderPicker", "Male");
            if (!Preferences.ContainsKey("DatePicker"))
                Preferences.Set("DatePicker", new DateTime(2000, 1, 1));
            birthDatePicker.Date = Preferences.Get("DatePicker", new DateTime(2000, 1, 1));
        }

        void metricSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            Preferences.Set("MetricMode", metricSwitch.IsToggled);
            kilometers = Preferences.Get("MetricMode", false);
            databaseView.ItemsSource = conn.Table<Activity>().ToList();
            totalView.ItemsSource = conn.Table<Total>().ToList();
            if (!kilometers)
            {
                distanceLabel.Text = "Distance (Miles): ";
            }
            else
            {
                distanceLabel.Text = "Distance (Kilometers): ";
            }
        }

        void genderPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            Preferences.Set("GenderPicker", genderPicker.SelectedItem.ToString());
        }

        void birthDatePicker_DateSelected(System.Object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            Preferences.Set("DatePicker", birthDatePicker.Date);
        }

        public static DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        void addButton_Clicked(System.Object sender, System.EventArgs e)
        {
            double distance = Convert.ToDouble(distanceEntry.Text);
            int heartRate = Convert.ToInt32(rateEntry.Text);
            if (!(distance <= 0 || heartRate <= 0))
            {
                String date = datePicker.Date.ToString("MM/dd/yy");
                int hours = Convert.ToInt32(timeEntry1.Text);
                int minutes = Convert.ToInt32(timeEntry2.Text);
                String timeSpan = new TimeSpan(hours, minutes, 0).ToString(@"hh\:mm");
                Activity activity = new Activity
                {
                    Date = date,
                    Distance = distance,
                    TimeSpan = timeSpan,
                    HeartRate = heartRate
                };
                conn.Insert(activity);
                databaseView.ItemsSource = conn.Table<Activity>().ToList();

                String week = StartOfWeek(datePicker.Date, DayOfWeek.Monday).ToString("MM/dd/yy");
                Total total;
                try
                {
                    total = conn.Get<Total>(week);
                    TimeSpan totalTimeSpan = TimeSpan.Parse(total.TotalTimeSpan);
                    TimeSpan activityTimeSpan = TimeSpan.Parse(activity.TimeSpan);
                    TimeSpan newTotalTimeSpan = totalTimeSpan + activityTimeSpan;
                    total.TotalTimeSpan = newTotalTimeSpan.ToString(@"hh\:mm");
                    total.TotalDistance = total.TotalDistance + activity.Distance;
                    total.AverageHeartRate =
                        ((total.AverageHeartRate * totalTimeSpan.TotalMinutes) +
                        (activity.HeartRate * activityTimeSpan.TotalMinutes)) /
                        (totalTimeSpan.TotalMinutes + activityTimeSpan.TotalMinutes);
                    conn.Update(total);
                }
                catch
                {
                    TimeSpan activityTimeSpan = TimeSpan.Parse(activity.TimeSpan);
                    string totalTimeSpan = activityTimeSpan.ToString(@"hh\:mm");
                    double totalDistance = activity.Distance;
                    double averageHeartRate = Convert.ToDouble(activity.HeartRate);
                    total = new Total
                    {
                        Week = week,
                        TotalTimeSpan = totalTimeSpan,
                        TotalDistance = totalDistance,
                        AverageHeartRate = averageHeartRate
                    };
                    conn.Insert(total);
                }
                totalView.ItemsSource = conn.Table<Total>().ToList();
            }
        }

        void updateButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Activity activity = (Activity)databaseView.SelectedItem;
            double distance = Convert.ToDouble(distanceEntry.Text);
            int heartRate = Convert.ToInt32(rateEntry.Text);
            if (!(distance <= 0 || heartRate <= 0)) {
                activity.Distance = distance;
                activity.HeartRate = heartRate;
                activity.Date = datePicker.Date.ToString("MM/dd/yy");
                int hours = Convert.ToInt32(timeEntry1.Text);
                int minutes = Convert.ToInt32(timeEntry2.Text);
                activity.TimeSpan = new TimeSpan(hours, minutes, 0).ToString(@"hh\:mm");
                conn.Update(activity);
                databaseView.ItemsSource = conn.Table<Activity>().ToList();

                conn.DeleteAll<Total>();
                String week = StartOfWeek(datePicker.Date, DayOfWeek.Monday).ToString("MM/dd/yy");
                Total total;
                foreach (Activity act in conn.Table<Activity>().ToList())
                {
                    try
                    {
                        total = conn.Get<Total>(week);
                        TimeSpan totalTimeSpan = TimeSpan.Parse(total.TotalTimeSpan);
                        TimeSpan activityTimeSpan = TimeSpan.Parse(act.TimeSpan);
                        TimeSpan newTotalTimeSpan = totalTimeSpan + activityTimeSpan;
                        total.TotalTimeSpan = newTotalTimeSpan.ToString();
                        total.TotalDistance = total.TotalDistance + act.Distance;
                        total.AverageHeartRate =
                            ((total.AverageHeartRate * totalTimeSpan.TotalMinutes) +
                            (activity.HeartRate * activityTimeSpan.TotalMinutes)) /
                            (totalTimeSpan.TotalMinutes + activityTimeSpan.TotalMinutes);
                        conn.Update(total);
                    }
                    catch
                    {
                        TimeSpan activityTimeSpan = TimeSpan.Parse(act.TimeSpan);
                        string totalTimeSpan = activityTimeSpan.ToString(@"hh\:mm");
                        double totalDistance = act.Distance;
                        double averageHeartRate = Convert.ToDouble(act.HeartRate);
                        total = new Total
                        {
                            Week = week,
                            TotalTimeSpan = totalTimeSpan,
                            TotalDistance = totalDistance,
                            AverageHeartRate = averageHeartRate
                        };
                        conn.Insert(total);
                    }
                }
                totalView.ItemsSource = conn.Table<Total>().ToList();
            }
        }

        void deleteButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Activity activity = (Activity)databaseView.SelectedItem;
            conn.Delete(activity);
            databaseView.ItemsSource = conn.Table<Activity>().ToList();

            conn.DeleteAll<Total>();
            String week = StartOfWeek(datePicker.Date, DayOfWeek.Monday).ToString("MM/dd/yy");
            Total total;
            foreach (Activity act in conn.Table<Activity>().ToList())
            {
                try
                {
                    total = conn.Get<Total>(week);
                    TimeSpan totalTimeSpan = TimeSpan.Parse(total.TotalTimeSpan);
                    TimeSpan activityTimeSpan = TimeSpan.Parse(act.TimeSpan);
                    TimeSpan newTotalTimeSpan = totalTimeSpan + activityTimeSpan;
                    total.TotalTimeSpan = newTotalTimeSpan.ToString();
                    total.TotalDistance = total.TotalDistance + act.Distance;
                    total.AverageHeartRate =
                        ((total.AverageHeartRate * totalTimeSpan.TotalMinutes) +
                        (activity.HeartRate * activityTimeSpan.TotalMinutes)) /
                        (totalTimeSpan.TotalMinutes + activityTimeSpan.TotalMinutes);
                    conn.Update(total);
                }
                catch
                {
                    TimeSpan activityTimeSpan = TimeSpan.Parse(act.TimeSpan);
                    string totalTimeSpan = activityTimeSpan.ToString(@"hh\:mm");
                    double totalDistance = act.Distance;
                    double averageHeartRate = Convert.ToDouble(act.HeartRate);
                    total = new Total
                    {
                        Week = week,
                        TotalTimeSpan = totalTimeSpan,
                        TotalDistance = totalDistance,
                        AverageHeartRate = averageHeartRate
                    };
                    conn.Insert(total);
                }
            }
            totalView.ItemsSource = conn.Table<Total>().ToList();
        }

        async void creditsButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Browser.OpenAsync("https://www.miamioh.edu");
        }
    }
}

