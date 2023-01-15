using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;

namespace CreateDB {
    [Table("student")]
    public class Student {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public double GPA { set; get; }
        public bool Legacy { set; get; }
        public override string ToString() {
            return string.Format("{0}, {1} ({2}) {3} {4} [{5}]", LastName, FirstName, GPA, SSN, Legacy ? "(L)" : "", Id);
        }
    }
   public class LooneyTunes {
        public static void CreateDB(SQLiteConnection conn) {
            conn.CreateTable<Student>();
            conn.DeleteAll<Student>();

            conn.Insert(new Student { FirstName = "Bugs", LastName = "Bunny", SSN = "111-11-1111", GPA = 3.4, Legacy = false });
            conn.Insert(new Student { FirstName = "Marvin", LastName = "Martian", SSN = "222-22-2222", GPA = 3.2, Legacy = false });
            conn.Insert(new Student { FirstName = "Homer", LastName = "Simpson", SSN = "333-33-3333", GPA = 0.4, Legacy = true });
            conn.Insert(new Student { FirstName = "Yosemite", LastName = "Sam", SSN = "444-44-4444", GPA = 1.4, Legacy = false });
            conn.Insert(new Student { FirstName = "Bart", LastName = "Simpson", SSN = "555-55-5555", GPA = 0.9, Legacy = true });
            conn.Insert(new Student { FirstName = "Jim", LastName = "Kiper", SSN = "666-66-6666", GPA = 2.4, Legacy = true });
            conn.Insert(new Student { FirstName = "Elmer", LastName = "Fudd", SSN = "777-77-7777", GPA = 2.0, Legacy = false });
            conn.Insert(new Student { FirstName = "SpongeBob", LastName = "SquarePants", SSN = "888-88-8888", GPA = 3.2, Legacy = false });
            conn.Insert(new Student { FirstName = "Shaggy", LastName = "Rogers", SSN = "999-99-9999", GPA = 2.7, Legacy = false });
            conn.Insert(new Student { FirstName = "Bobby", LastName = "Hill", SSN = "000-00-0000", GPA = 2.7, Legacy = false });
        }
    }
}
