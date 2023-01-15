using System;
using System.Collections.Generic;
using FormulaStandings;
using System.Xml.Linq;
using SQLite;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Essentials;

namespace FormulaStandings
{
    public partial class ConstructorPage : ContentPage
    {
        SQLiteConnection conn;
        RestService _restService;
        string link;

        public ConstructorPage(SQLiteConnection conn, string constructorName)
        {
            InitializeComponent();

            this.conn = conn;
            conn.CreateTable<ConstructorDetailsInfo>();

            _restService = new RestService();

            LoadConstructorData(constructorName);
        }

        public async void LoadConstructorData(string constructorName)
        {
            try
            {
                ConstructorData.Root constructorData =
                    await _restService.GetConstructorData();
                List<ConstructorData.ConstructorStanding> constructorStandings =
                    constructorData.MRData.StandingsTable.StandingsLists[0].ConstructorStandings;
                conn.DeleteAll<ConstructorDetailsInfo>();
                foreach (ConstructorData.ConstructorStanding constructorStanding
                    in constructorStandings)
                {
                    if (constructorStanding.Constructor.name.Equals(constructorName))
                    {
                        ConstructorDetailsInfo constructorDetailsInfo =
                            new ConstructorDetailsInfo();
                        constructorDetailsInfo.position = constructorStanding.position;
                        constructorDetailsInfo.points = constructorStanding.points;
                        constructorDetailsInfo.wins = constructorStanding.wins;
                        constructorDetailsInfo.nationality =
                            constructorStanding.Constructor.nationality;
                        link =
                            constructorStanding.Constructor.url;
                        conn.Insert(constructorDetailsInfo);
                    }
                }
                constructor.ItemsSource = conn.Table<ConstructorDetailsInfo>().ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            name.Text = constructorName;
            logo.Source = constructorName;
            team.Source = constructorName + "3";
            car.Source = constructorName + "2";
            loading.IsVisible = false;
        }

        async void MoreInfoTapped(System.Object sender, System.EventArgs e)
        {
            await Browser.OpenAsync(link, BrowserLaunchMode.SystemPreferred);
        }
    }
}
