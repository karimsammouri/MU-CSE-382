using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TrainingDB {
    [Table("longdefs")]
    public class LongActivityDefinition {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string Sport { get; set; }
        public TimeSpan Duration { get; set; }
        public static LongActivityDefinition ParseCSV(string line) {
            string[] toks = line.Split(',');
            LongActivityDefinition longDef = new LongActivityDefinition {
                Sport = toks[0],
                Duration = TimeSpan.Parse(toks[1])
            };
            return longDef;
        }
        public override string ToString() {
            return string.Format("{0}-{1}", Sport, Duration.ToString());
        }
    }
}
