using System;
using System.Collections.Generic;
using System.Diagnostics;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace FormulaStandings
{
    public partial class DriverPage : ContentPage
    {
        SQLiteConnection conn;
        RestService _restService;
        string link;

        public DriverPage(SQLiteConnection conn, string driver)
        {
            InitializeComponent();

            this.conn = conn;
            conn.CreateTable<DriverDetailsInfo>();

            _restService = new RestService();

            string driverName = driver.Substring(0, driver.IndexOf(","));
            string driverNationality = driver.Substring(driver.IndexOf(",") + 1,
                driver.IndexOf("-") - driver.IndexOf(",") - 1);
            string driverConstructor = driver.Substring(driver.IndexOf("-") + 1);
            LoadDriverData(driverName, driverNationality, driverConstructor);
        }

        public async void LoadDriverData(string driverName,
            string driverNationality, string driverConstructor)
        {
            try
            {
                DriverData.Root driverData = await _restService.GetDriverData();
                List<DriverData.DriverStanding> driverStandings =
                    driverData.MRData.StandingsTable.StandingsLists[0].DriverStandings;
                conn.DeleteAll<DriverDetailsInfo>();
                foreach (DriverData.DriverStanding driverStanding in driverStandings)
                {
                    if (String.Format("{0} {1}",
                        driverStanding.Driver.givenName,
                        driverStanding.Driver.familyName).Equals(driverName))
                    {
                        DriverDetailsInfo driverDetailsInfo = new DriverDetailsInfo();
                        driverDetailsInfo.constructor =
                            driverStanding.Constructors[0].name;
                        driverDetailsInfo.permanentNumber =
                            driverStanding.Driver.permanentNumber;
                        driverDetailsInfo.code = driverStanding.Driver.code;
                        driverDetailsInfo.position = driverStanding.position;
                        driverDetailsInfo.wins = driverStanding.wins;
                        driverDetailsInfo.points = driverStanding.points;
                        driverDetailsInfo.dateOfBirth =
                            driverStanding.Driver.dateOfBirth;
                        driverDetailsInfo.nationality =
                            driverStanding.Driver.nationality;
                        link = driverStanding.Driver.url;
                        conn.Insert(driverDetailsInfo);
                    }
                }
                driver.ItemsSource = conn.Table<DriverDetailsInfo>().ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            name.Text = driverName;
            flag.Source = driverNationality;
            constructor.Source = driverConstructor;
            driverShot.Source = driverName;
            loading.IsVisible = false;
        }

        async void MoreInfoTapped(System.Object sender, System.EventArgs e)
        {
            await Browser.OpenAsync(link, BrowserLaunchMode.SystemPreferred);
        }
    }
}