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
        int count = 0;
        DetectShakeTest dt;
        bool isGroup1 = true;
        bool b2Pressed = true;

        public MainPage()
        {
            InitializeComponent();
            MainThread.BeginInvokeOnMainThread(initStuff);
        }

        private void initStuff()
        {
            dt = new DetectShakeTest(Label1);
            dt.ToggleAccelerometer();

            Group2.TranslateTo(500, 0, 0);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            count++;
            ((Button)sender).Text = "Button was pressed " + count + " Times";

            if(count%2==0)
                Label1.TranslateTo(-100, 0, 500);
            else
                Label1.TranslateTo(100, 0, 500);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (b2Pressed == true)
                Label2.Text = "This button doesn't do anything.";
            else
                Label2.Text = "THIS IS GROUP 2.";

            b2Pressed = !b2Pressed;
        }

        private async void doAnimation()
        {
            Group1.IsVisible = true;
            Group2.IsVisible = true;

            if (isGroup1 == true)
            {
                await Task.WhenAll(
                    Group1.TranslateTo(-500, 0, 500),
                    Group2.TranslateTo(0, 0, 500)
                );

                Group1.IsVisible = false;
            }
            else
            {
                await Task.WhenAll(
                    Group1.TranslateTo(0, 0, 500),
                    Group2.TranslateTo(500, 0, 500)
                );

                Group2.IsVisible = false;
            }

            isGroup1 = !isGroup1;
        }

        private void transitionStuff(object sender, EventArgs e)
        {
            doAnimation();
        }
    }
}
