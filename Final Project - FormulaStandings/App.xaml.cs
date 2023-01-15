using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.SimpleAudioPlayer;
using System.IO;
using System.Reflection;
using Xamarin.Essentials;
using SQLite;
using System.Xml.Linq;
using System.Numerics;

namespace FormulaStandings
{
    public partial class App : Application
    {
        ISimpleAudioPlayer player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage(player));
            LoadMusic("FormulaTheme.mp3");
        }

        protected override void OnStart()
        {
            if (Preferences.Get("MusicMode", true) == true)
            {
                player.Volume = Preferences.Get("VolumeMode", 0.5);
                player.Play();
            }
        }

        protected override void OnSleep()
        {
            player.Stop();
        }

        protected override void OnResume()
        {
            if (Preferences.Get("MusicMode", true) == true)
            {
                player.Volume = Preferences.Get("VolumeMode", 0.5);
                player.Play();
            }
        }

        private void LoadMusic(string file)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            String ns = "FormulaStandings";
            Stream audioStream = assembly.GetManifestResourceStream(ns + "." + file);
            player.Load(audioStream);
            player.Loop = true;
            player.Volume = 0.5;
        }
    }
}

