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
    public partial class LootMenu : ContentPage
    {
        public LootMenu()
        {
            InitializeComponent();
        }

        Button LootMenu_c1Selected = null;
        Button LootMenu_c2Selected = null;

        bool LootMenu_swap = true;
        bool[] LootMenu_locationValid = new bool[10] { true, true, true, true, true, true, false, false, false, false };
        string[] LootMenu_sourceFiles = new string[10] { "hatstickman.png", "johnstickman.png", "Shadystickman.png", "Coolfightingstickman.png", "Cowboystickman.png", "tshirtstickman.png", "qmark.png", "qmark.png", "qmark.png", "qmark.png" };

        string char1Source = "";
        string char2Source = "";

        private void LootMenu_CharacterPicked(object sender, EventArgs e)
        {
            string id = ((Button)sender).ClassId;
            string selectImage = id + "Select";

            int num = int.Parse(id.Substring(9, id.Length - 9));

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

                if (got == true)
                {
                    characterImage.Source = LootMenu_sourceFiles[index];
                }
                else
                {
                    characterImage.Source = "qmark.png";
                }
            }
        }

        private async void LootMenu_BackButton(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void LootMenu_ReadyButton(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Looting(char1Source, char2Source));
        }
    }
}