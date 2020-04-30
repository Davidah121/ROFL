using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.SimpleAudioPlayer;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ROFL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonGet : ContentPage
    {
        ISimpleAudioPlayer player = CrossSimpleAudioPlayer.Current;
        String person;
        public PersonGet(String guy)
        {
            player.Load("drumroll.mp3");
            this.person = guy;
            InitializeComponent();
        }
        override
        protected void OnAppearing()
        {
            player.Play();
            ShowPerson();
        }
        
        private async void ShowPerson()
        {
            await Task.Delay(4000);
            Person.Source = this.person;
            Person.IsVisible = true;
            Got.IsVisible = true;
            LeaveButton.IsVisible = true;
        }

        private async void Leave(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}