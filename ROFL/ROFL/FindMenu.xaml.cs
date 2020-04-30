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
        String[] people = { "Coolfightingstickman.png", "Cowboystickman.png", "hatstickman.png", "johnstickman.png", "Shadystickman.png", "tshirtstickman.png" };
        public FindMenu()
        {
            InitializeComponent();
        }

        private async void FindMenu_BackButton(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void Find_Button(object sender, EventArgs e)
        {
            var rand = new Random();
            int bumbo = rand.Next(0, people.Length);
            await Navigation.PushModalAsync(new PersonGet(people[bumbo]), false);
            
        }
    }
}