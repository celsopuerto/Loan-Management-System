using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    public partial class App : Application
    {
        private static db _database;
        public static db db
        {
            get
            {
                if (_database == null)
                {
                    _database = new db(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "electricity.db3"));
                }
                return _database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
