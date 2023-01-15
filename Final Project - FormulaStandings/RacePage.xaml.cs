using System;
using System.Collections.Generic;
using System.Diagnostics;
using SQLite;
using Xamarin.Forms;

namespace FormulaStandings
{
    public partial class RacePage : ContentPage
    {
        SQLiteConnection conn;
        RestService _restService;

        public RacePage(SQLiteConnection conn, string round)
        {
            InitializeComponent();

            this.conn = conn;
            conn.CreateTable<RaceResultsInfo>();

            _restService = new RestService();

            string roundNumber = round.Substring(0, round.IndexOf(","));
            string roundName = round.Substring(round.IndexOf(",") + 1,
                round.IndexOf("-") - round.IndexOf(",") - 1);
            string circuitName = round.Substring(round.IndexOf("-") + 1);
            LoadRaceData(roundNumber, roundName, circuitName);
        }

        public async void LoadRaceData(string roundNumber, string roundName, string circuitName)
        {
            try
            {
                RaceResultsData.Root raceResultsData =
                    await _restService.GetRaceResultsData(roundNumber);
                List<RaceResultsData.Result> raceResults =
                    raceResultsData.MRData.RaceTable.Races[0].Results;
                conn.DeleteAll<RaceResultsInfo>();
                foreach (RaceResultsData.Result raceResult in raceResults)
                {
                    RaceResultsInfo raceResultsInfo = new RaceResultsInfo();
                    raceResultsInfo.position = raceResult.position;
                    raceResultsInfo.points = raceResult.points;
                    raceResultsInfo.driver = raceResult.Driver.givenName + " " +
                        raceResult.Driver.familyName;
                    raceResultsInfo.driverCode = raceResult.Driver.code;
                    raceResultsInfo.nationality = raceResult.Driver.nationality;
                    raceResultsInfo.constructor = raceResult.Constructor.name;
                    try
                    {
                        raceResultsInfo.time = raceResult.Time.time;
                    }
                    catch
                    {
                        if (raceResult.status.Contains("+"))
                        {
                            raceResultsInfo.time = raceResult.status + "s";
                        }
                        else
                        {
                            raceResultsInfo.time = "DNF: " + raceResult.status;
                        }
                    }
                    conn.Insert(raceResultsInfo);
                }
                race.ItemsSource = conn.Table<RaceResultsInfo>().ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            raceName.Text = roundName;
            flag.Source = roundName;
            circuit.Source = circuitName;
            loading.IsVisible = false;
        }

        async void DriverTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            DriverPage driverPage = new DriverPage(conn, e.Item.ToString());
            await Navigation.PushAsync(driverPage, true);
        }
    }
}