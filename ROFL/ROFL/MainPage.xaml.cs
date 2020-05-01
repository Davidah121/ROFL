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
        int stars = 0;
        int money = 0;


        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Loot(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new LootMenu(this));
        }
        private void Button_Find(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new FindMenu(this));
        }
        private void Button_Run(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RunMenu(this));
        }
        //bonk
        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        public void Add_Stars(int i)
        {
            this.stars += i;
            String sString = stars.ToString();
            sString = sString.PadLeft(sString.Length + (4 - sString.Length), '0');

            starLabel.Text = ": " + sString;
        }
        
        public int Get_Stars()
        {
            return stars;
        }
        
        public void Spend_Stars(int i)
        {
            this.stars -= i;
            String sString = stars.ToString();
            sString = sString.PadLeft(sString.Length + (4 - sString.Length), '0');

            starLabel.Text = ": " + sString;
        }

        public void Add_Cash(int i)
        {
            this.money += i;
            String sString = money.ToString();
            sString = sString.PadLeft(sString.Length + (4 - sString.Length), '0');

            starLabel.Text = ": " + sString;
        }
        public void Spend_Cash(int i)
        {
            this.money -= i;
            String sString = money.ToString();
            sString = sString.PadLeft(sString.Length + (4 - sString.Length), '0');

            starLabel.Text = ": " + sString;
        }
        public int Get_Cash()
        {
            return this.money;
        }
    }
}
