using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace ROFL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Looting : ContentPage
    {
        MainPage m;
        public Looting(String source1, String source2, MainPage m)
        {
            this.m = m;
            InitializeComponent();
            img1.Source = source1;
            img2.Source = source2;
            Stars.Text = m.Get_Stars().ToString();
        }

        private async void LootingMenu_CheerButton(object sender, EventArgs e)
        {
            if (m.Get_Stars() >= 50)
            {
                m.Spend_Stars(50);
                Stars.Text = m.Get_Stars().ToString();
                m.Add_Cash(10); //50 stars is a cheer, a cheer is 10 cash
            }
            else
            {
                //TODO: TELL THE PLAYER THEY AREN'T RICH ENOUGH
                await DisplayAlert("", "Not Enough Stars", "OK");
            }
        }

        private async void LootingMenu_BackButton(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}