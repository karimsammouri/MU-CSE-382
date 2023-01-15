using System;
using SQLite;

namespace RunningApp
{
    [Table("total")]
    public class Total
    {
        [PrimaryKey, Column("_id")]
        public string Week { get; set; }

        public string TotalTimeSpan { get; set; }

        public double TotalDistance { get; set; }

        public double AverageHeartRate { get; set; }

        public override string ToString()
        {
            if (!MainPage.kilometers)
            {
                return String.Format("{0} Time={1} Dist.={2:0} BPM={3}",
                    Week, TotalTimeSpan, TotalDistance, AverageHeartRate);
            } else
            {
                return String.Format("{0} Time={1} Dist.={2:0} BPM={3}",
                    Week, TotalTimeSpan, TotalDistance * 1.61, AverageHeartRate);
            }
        }
    }
}

