﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ROFL
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TitlePage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
