using System;
using SQLite;

namespace RunningApp
{
    [Table("activity")]
    public class Activity
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Date { get; set; }

        public double Distance { get; set; }

        public string TimeSpan { get; set; }

        public int HeartRate { get; set; }

        public override string ToString()
        {
            if (!MainPage.kilometers)
            {
                return String.Format("{0} Time={1} Dist.={2:0} BPM={3}",
                    Date, TimeSpan, Distance, HeartRate);
            }
            else
            {
                return String.Format("{0} Time={1} Dist.={2:0} BPM={3}",
                    Date, TimeSpan, Distance * 1.61, HeartRate);
            }
        }
    }
}

