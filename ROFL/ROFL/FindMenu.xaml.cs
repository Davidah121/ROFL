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
    public partial class FindMenu : ContentPage
    {
        int money = 0;
        int stars = 0;
        MainPage m;
        String[] people = { "Coolfightingstickman.png", "Cowboystickman.png", "hatstickman.png", "johnstickman.png", "Shadystickman.png", "tshirtstickman.png" };
        public FindMenu(MainPage m)
        {
            this.m = m;
            money = m.Get_Cash();
            stars = m.Get_Stars();
            InitializeComponent();

            String sString = stars.ToString();
            sString = sString.PadLeft(sString.Length + (4 - sString.Length), '0');

            Starcount.Text = sString;

            sString = money.ToString();
            sString = sString.PadLeft(sString.Length + (4 - sString.Length), '0');

            Money.Text = sString;

        }

        private async void FindMenu_BackButton(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void Find_Button(object sender, EventArgs e)
        {
            if (m.Get_Cash() >= 10)
            {
                var rand = new Random();
                int bumbo = rand.Next(0, people.Length);
                m.Spend_Cash(10);
                Money.Text = m.Get_Cash().ToString();
                await Navigation.PushModalAsync(new PersonGet(people[bumbo]), false);
            }
            else
            {
                //TODO: TELL THE PLAYER THEY AREN'T RICH ENOUGH
                await DisplayAlert("", "Not enough Funds", "OK");
            }
        }
    }
}