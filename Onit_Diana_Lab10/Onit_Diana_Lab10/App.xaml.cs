﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using Onit_Diana_Lab10.Data;
using System.IO;

namespace Onit_Diana_Lab10
{
    public partial class App : Application
    {

        static ShoppingListDatabase database;

        public static ShoppingListDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new 
                    ShoppingListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ShoppingList.db3"));
                }
                return database;
            }
        }



        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListEntryPage());
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
