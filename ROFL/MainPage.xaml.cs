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
        public MainPage()
        {
            InitializeComponent();
            MainThread.BeginInvokeOnMainThread(initStuff);
        }

        private void initStuff()
        {
            dt = new DetectShakeTest(Label1);
            dt.ToggleAccelerometer();
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
    }
}
