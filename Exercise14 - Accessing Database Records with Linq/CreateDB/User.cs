using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;

namespace CreateDB {
    [Table("user")]
    public class User {
        // PrimaryKey is typically numeric 
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Username { get; set; }
        public DateTime DateCreated { get; set; }
        public override string ToString() {
            return String.Format("{0} {1} [{2}]", Username, DateCreated, Id);
        }
        public static void CreateDB(SQLiteConnection conn) {
            conn.CreateTable<User>();
            conn.DeleteAll<User>();

            conn.Insert(new User { Username = "jsmith", DateCreated = new DateTime(1997, 8, 1) } );
            conn.Insert(new User { Username = "jgonzales", DateCreated = new DateTime(2000, 8, 1) });
            conn.Insert(new User { Username = "gpierce", DateCreated = new DateTime(2000, 8, 1) });
            conn.Insert(new User { Username = "ahinojsa", DateCreated = new DateTime(2005, 8, 1) });
            conn.Insert(new User { Username = "jlin", DateCreated = new DateTime(2005, 8, 1) });
            conn.Insert(new User { Username = "lsmith", DateCreated = new DateTime(2005, 10, 1) });
            conn.Insert(new User { Username = "akaline", DateCreated = new DateTime(2010, 7, 1) });
            conn.Insert(new User { Username = "prose", DateCreated = new DateTime(2020, 8, 1) });
        }
    }
}
