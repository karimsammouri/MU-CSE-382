using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.SimpleAudioPlayer;
using SQLite;
using Xamarin.Essentials;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace FormulaStandings
{
    public partial class MainPage : TabbedPage
    {
        ISimpleAudioPlayer player;
        SQLiteConnection conn;
        RestService _restService;

        public MainPage(ISimpleAudioPlayer player)
        {
            InitializeComponent();

            this.player = player;

            if (!Preferences.ContainsKey("MusicMode"))
                Preferences.Set("MusicMode", true);
            musicSwitch.IsToggled = Preferences.Get("MusicMode", true);
            if (!Preferences.ContainsKey("VolumeMode"))
                Preferences.Set("VolumeMode", 0.5);
            volumeStepper.Value = Preferences.Get("VolumeMode", 0.5);

            string libFolder = FileSystem.AppDataDirectory;
            string fname = System.IO.Path.Combine(libFolder, "FormulaData.db");
            conn = new SQLiteConnection(fname);
            conn.CreateTable<RaceInfo>();
            conn.CreateTable<DriverInfo>();
            conn.CreateTable<ConstructorInfo>();

            _restService = new RestService();

            LoadRaceData();
            LoadDriverData();
            LoadConstructorData();
        }

        public async void LoadRaceData()
        {
            try
            {
                RaceData.Root raceData = await _restService.GetRaceData();
                List<RaceData.Race> races = raceData.MRData.RaceTable.Races;
                conn.DeleteAll<RaceInfo>();
                foreach (RaceData.Race race in races)
                {
                    RaceInfo raceInfo = new RaceInfo();
                    raceInfo.round = race.round;
                    raceInfo.dateMonth = race.date.ToString("MMM").ToUpper();
                    raceInfo.dateDay = String.Format("{0}-{1}",
                        race.date.AddDays(-2).Day, race.date.Day);
                    raceInfo.country = race.Circuit.Location.country;
                    raceInfo.circuit = race.Circuit.circuitName;
                    conn.Insert(raceInfo);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            races.ItemsSource = conn.Table<RaceInfo>().ToList();
            loading.IsVisible = false;
        }

        public async void LoadDriverData()
        {
            try
            {
                DriverData.Root driverData = await _restService.GetDriverData();
                List<DriverData.DriverStanding> driverStandings =
                    driverData.MRData.StandingsTable.StandingsLists[0].DriverStandings;
                conn.DeleteAll<DriverInfo>();
                foreach (DriverData.DriverStanding driverStanding in driverStandings)
                {
                    DriverInfo driverInfo = new DriverInfo();
                    driverInfo.position = driverStanding.position;
                    driverInfo.points = driverStanding.points;
                    driverInfo.name = String.Format("{0} {1}",
                        driverStanding.Driver.givenName,
                        driverStanding.Driver.familyName);
                    driverInfo.nationality = driverStanding.Driver.nationality;
                    driverInfo.constructor = driverStanding.Constructors[0].name;
                    conn.Insert(driverInfo);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            drivers.ItemsSource = conn.Table<DriverInfo>().ToList();
            loading2.IsVisible = false;
        }

        public async void LoadConstructorData()
        {
            try
            {
                ConstructorData.Root constructorData = await _restService.GetConstructorData();
                List<ConstructorData.ConstructorStanding> constructorStandings =
                    constructorData.MRData.StandingsTable.StandingsLists[0].ConstructorStandings;
                conn.DeleteAll<ConstructorInfo>();
                foreach (ConstructorData.ConstructorStanding constructorStanding in constructorStandings)
                {
                    ConstructorInfo constructorInfo = new ConstructorInfo();
                    constructorInfo.position = constructorStanding.position;
                    constructorInfo.points = constructorStanding.points;
                    constructorInfo.name = constructorStanding.Constructor.name;
                    constructorInfo.wins = constructorStanding.wins;
                    conn.Insert(constructorInfo);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            constructors.ItemsSource = conn.Table<ConstructorInfo>().ToList();
            loading3.IsVisible = false;
        }

        async void RaceTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            RacePage racePage = new RacePage(conn, e.Item.ToString());
            await Navigation.PushAsync(racePage, true);
        }

        async void DriverTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            DriverPage driverPage = new DriverPage(conn, e.Item.ToString());
            await Navigation.PushAsync(driverPage, true);
        }

        async void ConstructorTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            ConstructorPage constructorPage = new ConstructorPage(conn, e.Item.ToString());
            await Navigation.PushAsync(constructorPage, true);
        }

        void MusicSwitchToggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            Preferences.Set("MusicMode", musicSwitch.IsToggled);
            if (e.Value.Equals(true))
            {
                player.Volume = Preferences.Get("VolumeMode", 0.5);
                player.Play();
            }
            else
            {
                player.Stop();
            }
        }

        void VolumeStepperClicked(System.Object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            Preferences.Set("VolumeMode", volumeStepper.Value);
            player.Volume = e.NewValue;
        }

        async void AboutTapped(System.Object sender, System.EventArgs e)
        {
            AboutPage aboutPage = new AboutPage();
            await Navigation.PushAsync(aboutPage, true);
        }

        async void FeedbackTapped(System.Object sender, System.EventArgs e)
        {
            FeedbackPage feedbackPage = new FeedbackPage();
            await Navigation.PushAsync(feedbackPage, true);
        }

        async void F1SiteTapped(System.Object sender, System.EventArgs e)
        {
            await Browser.OpenAsync("https://www.formula1.com/", BrowserLaunchMode.SystemPreferred);
        }
    }
}

