using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace TrainingDB {

    [Table("activity")]
    public class Activity {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Sport { get; set; }
        public DateTime DatePerformed { get; set; }
        public TimeSpan Duration { get; set; }
         public int GetCalories() {
            int totalMinutes = (int)Math.Round(Duration.TotalMinutes);
            switch (Sport) {  // These are not accurate
                case "Swimming": return totalMinutes * 10;
                case "Biking": return totalMinutes * 10;
                case "Running": return totalMinutes * 12;
                case "Walking": return totalMinutes * 5;
                case "Yoga": return totalMinutes * 7;
                case "Strength Training": return totalMinutes * 10;
                default: return totalMinutes * 10;
            }
        }
        public override string ToString() {
            return string.Format("{0} {1} Time={2} Calories={3} ({4})", DatePerformed.ToString("MM/dd/yyyy"), Sport, Duration, GetCalories(), Id);
        }
        public static Activity ParseCSV(string line) {
            string[] toks = line.Split(',');
            Activity activity = new Activity {
                DatePerformed = DateTime.Parse(toks[0]),
                Sport = toks[1],
                Duration = TimeSpan.Parse(toks[2])
            };
            return activity;
        }
    }
}
