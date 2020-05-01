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
        int stepsAdd = 0;
        int previousSteps = 0;
        int totalPointsGot = 0;
        DetectShakeTest dt;
        public RunMenu(MainPage m)
        {
            this.m = m;
            dt = new DetectShakeTest(this);
            dt.ToggleAccelerometer();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                timeCount++;
                setTimerText(timeCount);

                //RunMenu_TimerText.Text = "Timer: " + timeCount + " seconds";
                if ((timeCount % 30) == 0)
                {
                    mult++;
                }

                mult = Math.Min(mult, 8);

                setMultiplierText(mult);

                int amountToAdd = 0;

                stepsAdd += steps - previousSteps;
                previousSteps = steps;
                if (stepsAdd >= 4)
                {
                    amountToAdd = stepsAdd / 4;
                    stepsAdd -= amountToAdd * 4;
                }

                totalPointsGot += mult * amountToAdd;

                setStarPointsText(totalPointsGot);

                //RunMenu_MultiplierText.Text = "Multiplier: " + mult + "x";
                //RunMenu_StarsText.Text = (mult * steps).ToString();

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
            String originalText = "Steps: ";

            String sString = s.ToString();
            sString = sString.PadLeft(sString.Length + (4 - sString.Length), '0');


            RunMenu_StepsText.Text = originalText + sString;
        }

        public void setStarPointsText(int s)
        {
            String originalText = ": ";

            String sString = s.ToString();
            sString = sString.PadLeft(sString.Length + (4 - sString.Length), '0');

            RunMenu_StarsText.Text = originalText + sString;
        }


        public void setMultiplierText(int s)
        {
            mult = s;
            String k = s.ToString();
            String originalText = "Multiplier: ";
            String originalText2 = "x";

            RunMenu_MultiplierText.Text = originalText + k + originalText2;
        }


        public void setTimerText(int s)
        {
            //getTime in hour:min:sec format
            int mins = (s / 60) % 60;
            int hours = s / 3600 % 24;
            int seconds = s % 60;

            String k = s.ToString();
            String originalText = "Timer: ";

            String sString = seconds.ToString();
            sString = sString.PadLeft(sString.Length + (2 - sString.Length), '0');

            String mString = mins.ToString();
            mString = mString.PadLeft(mString.Length + (2 - mString.Length), '0');

            String hString = hours.ToString();
            hString = hString.PadLeft(hString.Length + (2 - hString.Length), '0');


            RunMenu_TimerText.Text = originalText + hString + ":" + mString + ":" + sString;
        }
    }
}