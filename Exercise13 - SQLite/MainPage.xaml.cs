using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Xamarin.Essentials;

namespace DBIntro
{
    public partial class MainPage : ContentPage
    {
        SQLiteConnection conn;
        public MainPage()
        {
            InitializeComponent();
            string libFolder = FileSystem.AppDataDirectory;
            string fname = System.IO.Path.Combine(libFolder, "Personnel.db");
            conn = new SQLiteConnection(fname);
            conn.CreateTable<User>();
            conn.CreateTable<Person>();
            lv.ItemsSource = conn.Table<User>().ToList();
            lv2.ItemsSource = conn.Table<Person>().ToList();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            User newUser = new User { Username = name.Text };
            conn.Insert(newUser);
            lv.ItemsSource = conn.Table<User>().ToList();
        }

        void Button_Clicked_2(System.Object sender, System.EventArgs e)
        {
            Person newPerson = new Person { Name = name2.Text,
                DOB = dob.Date, SSN = ssn.Text };
            conn.Insert(newPerson);
            lv2.ItemsSource = conn.Table<Person>().ToList();
        }
    }
}

