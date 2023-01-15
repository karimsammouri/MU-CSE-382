using System;
using SQLite;

namespace DBIntro
{
    [Table("person")]
    public class Person
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(250)]
        public String Name { get; set; }

        [MaxLength(250)]
        public DateTime DOB { get; set; }

        [MaxLength(250), Unique]
        public String SSN { get; set; }

        public override string ToString()
        {
            return string.Format("{1} ({0}) {2} {3}", Id, Name, DOB, SSN);
        }
    }

}