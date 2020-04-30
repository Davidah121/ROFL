using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace ROFL
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Loot(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new LootMenu());
        }
        private void Button_Find(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new FindMenu());
        }
        private void Button_Run(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RunMenu());
        }
        //bonk
        private void Button_Clicked(object sender, EventArgs e)
        {

        }

    }
}
