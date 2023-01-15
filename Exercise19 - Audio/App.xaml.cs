using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.SimpleAudioPlayer;
using System.IO;
using System.Reflection;

namespace Audio {
    public partial class App : Application {
        public App() {
            InitializeComponent();
            MainPage = new MainPage();
        }
        private void PlaySound(string file) {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            String thisNameSpace = "Audio";
            Stream audioStream = assembly.GetManifestResourceStream(thisNameSpace + "." + file);
            ISimpleAudioPlayer player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            player.Load(audioStream);
            player.Play();
        }
        protected override void OnStart() {
        }
        protected override void OnSleep() {
        }
        protected override void OnResume() {
        }
    }
}
