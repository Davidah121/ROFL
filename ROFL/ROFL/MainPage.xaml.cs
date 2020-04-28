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
            RunMenu.TranslateTo(0, 0, 0);
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


        #region RUN_MENU

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

        private void RunMenu_DoneButtonClicked(object sender, EventArgs e)
        {

        }

        #endregion

        #region LOOT_MENU
        Button LootMenu_c1Selected = null;
        Button LootMenu_c2Selected = null;

        bool LootMenu_swap = true;
        bool[] LootMenu_locationValid = new bool[10] { true, true, true, true, true, true, false, false, false, false };
        string[] LootMenu_sourceFiles = new string[10] { "hatstickman.png", "johnstickman.png", "Shadystickman.png", "Coolfightingstickman.png", "Cowboystickman.png", "tshirtstickman.png", "qmark.png", "qmark.png", "qmark.png", "qmark.png"};

        string char1Source = "";
        string char2Source = "";

        private void LootMenu_CharacterPicked(object sender, EventArgs e)
        {
            string id = ((Button)sender).ClassId;
            string selectImage = id + "Select";

            int num = int.Parse(id.Substring(9, id.Length-9));

            Image objToEnable = (Image)FindByName(selectImage);

            if (LootMenu_locationValid[num])
            {
                if (objToEnable.IsVisible == false)
                {
                    objToEnable.IsVisible = true;

                    if (LootMenu_c1Selected == null)
                    {
                        LootMenu_c1Selected = (Button)sender;
                        char1Source = LootMenu_sourceFiles[num];
                    }
                    else if (LootMenu_c2Selected == null)
                    {
                        LootMenu_c2Selected = (Button)sender;
                        char2Source = LootMenu_sourceFiles[num];
                    }
                    else
                    {
                        if (LootMenu_swap)
                        {
                            string oldSelectImage = LootMenu_c1Selected.ClassId + "Select";
                            ((Image)FindByName(oldSelectImage)).IsVisible = false;

                            LootMenu_c1Selected = ((Button)sender);

                            char1Source = LootMenu_sourceFiles[num];
                        }
                        else
                        {
                            string oldSelectImage = LootMenu_c2Selected.ClassId + "Select";
                            ((Image)FindByName(oldSelectImage)).IsVisible = false;

                            LootMenu_c2Selected = ((Button)sender);
                            char2Source = LootMenu_sourceFiles[num];
                        }

                        LootMenu_swap = !LootMenu_swap;
                    }
                }
                else
                {
                    objToEnable.IsVisible = false;
                    if (LootMenu_c1Selected == (Button)sender)
                    {
                        LootMenu_c1Selected = null;
                        char1Source = "";
                    }
                    else if (LootMenu_c2Selected == (Button)sender)
                    {
                        LootMenu_c2Selected = null;
                        char2Source = "";
                    }
                }
            }

        }

        private void LootMenu_setCharacterGot(int index, bool got)
        {
            if (index < 10)
            {
                LootMenu_locationValid[index] = got;
                string ne = "character" + index.ToString() + "Image";
                Image characterImage = (Image)FindByName(ne);

                if(got==true)
                {
                    characterImage.Source = LootMenu_sourceFiles[index];
                }
                else
                {
                    characterImage.Source = "qmark.png";
                }
            }
        }

        private void LootMenu_BackButton(object sender, EventArgs e)
        {
            LootMenu_setCharacterGot(0, false);
        }

        private void LootMenu_ReadyButton(object sender, EventArgs e)
        {
            LootMenu_setCharacterGot(0, true);
        }
        #endregion

        #region LOOTING_MENU

        private void LootingMenu_CheerButton(object sender, EventArgs e)
        {

        }

        private void LootingMenu_BackButton(object sender, EventArgs e)
        {

        }

        #endregion


    }
}
