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
    public partial class RunMenu : ContentPage
    {
        MainPage m;
        bool timerContinue = true;
        int timeCount = 0;
        int mult = 1;
        int steps = 0;
        DetectShakeTest dt;
        public RunMenu(MainPage m)
        {
            this.m = m;
            dt = new DetectShakeTest(this);
            dt.ToggleAccelerometer();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                timeCount++;
                RunMenu_TimerText.Text = "Timer: " + timeCount + " seconds";
                if ((timeCount % 30) == 0)
                {
                    mult++;
                }
                RunMenu_MultiplierText.Text = "Multiplier: " + mult + "x";
                RunMenu_StarsText.Text = (mult * steps).ToString();
                return timerContinue;
            });
            InitializeComponent();
        }
        private async void Leave(object sender, EventArgs e)
        {
            timerContinue = false;
            m.Add_Stars(mult * steps);
            dt.ToggleAccelerometer();
            await Navigation.PopModalAsync();
        }

        public void setSteps(int s)
        {
            steps = s;
            String k = s.ToString();
            String originalText = "Steps: ";

            RunMenu_StepsText.Text = originalText + k;
        }

    }
}