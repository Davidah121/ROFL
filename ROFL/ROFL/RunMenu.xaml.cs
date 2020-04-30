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
        DetectShakeTest dt;
        public RunMenu()
        {
            dt = new DetectShakeTest(this);
            dt.ToggleAccelerometer();
            InitializeComponent();
        }
        private async void Leave(object sender, EventArgs e)
        {
            dt.ToggleAccelerometer();
            await Navigation.PopModalAsync();
        }


        //Mostly getters and setters
        int steps = 0;
        int time = 0; //in seconds
        int multiplier = 0;
        int startPoints = 0;
        public int getSteps()
        {
            return steps;
        }

        public void setSteps(int s)
        {
            steps = s;
            String k = s.ToString();
            String originalText = "Steps: ";

            RunMenu_StepsText.Text = originalText + k;
        }

        public int getStarPoints()
        {
            return startPoints;
        }

        public void setStarPoints(int s)
        {
            startPoints = s;
            String k = s.ToString();
            String originalText = ": ";

            RunMenu_StepsText.Text = originalText + k;
        }

        public int getMultiplier()
        {
            return multiplier;
        }

        public void setMultiplier(int s)
        {
            String k = s.ToString();
            String originalText = "Multiplier: ";
            String originalText2 = "x";

            RunMenu_StepsText.Text = originalText + k + originalText2;
        }

        public int getTimer()
        {
            return time;
        }

        public void setTimer(int s)
        {
            time = s;
            //getTime in hour:min:sec format
            int mins = (time / 60) % 60;
            int hours = time / 3600 % 24;
            int seconds = time % 60;

            String k = s.ToString();
            String originalText = "Timer: ";

            RunMenu_StepsText.Text = originalText + hours.ToString() + ":" + mins.ToString() + ":" + seconds.ToString();
        }
    }
}