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
    public partial class Looting : ContentPage
    {
        public Looting(String source1, String source2)
        {
            InitializeComponent();
            img1.Source = source1;
            img2.Source = source2;
        }

        private void LootingMenu_CheerButton(object sender, EventArgs e)
        {

        }

        private async void LootingMenu_BackButton(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}