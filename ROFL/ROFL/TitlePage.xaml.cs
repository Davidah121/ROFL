using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ROFL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TitlePage : ContentPage
    {
        ISimpleAudioPlayer player = CrossSimpleAudioPlayer.Current;
        public TitlePage()
        {
            InitializeComponent();
        }
        public void OnTapped(object sender, EventArgs e)
        {
            player.Stop();
            Navigation.PushModalAsync(new MainPage());
        }
        override
        protected void OnAppearing()
        {
            player.Load("cutandrun.mp3");
            player.Play();
        }
    }
}