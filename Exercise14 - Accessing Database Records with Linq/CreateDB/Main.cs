using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;

namespace CreateDB {
	public class CreateDB {
		public static void Main(string fname) {
			File.Delete(fname);

			SQLiteConnection conn = new SQLiteConnection(fname);

			LooneyTunes.CreateDB(conn);
			User.CreateDB(conn);
			Person.CreateDB(conn);

			conn.Close();
		}
	}
}
