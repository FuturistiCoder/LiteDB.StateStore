using LiteDB.Realtime;
using LiteDB.StateStore;
using System;
using System.IO;
using Todo.Models;
using Todo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Todo
{
    public partial class App : Application
    {
        internal static RealtimeLiteDatabase DB;
        private readonly NavigationPage _nav;
        private SubscriptionManager _subscriptions = new SubscriptionManager();

        public App()
        {
            InitializeComponent();

            _nav = new NavigationPage(new TodoListPage())
            {
                BarBackgroundColor = Color.Chocolate,
                BarTextColor = Color.White
            };

            MainPage = _nav;

            SubscribeBarColor();
        }

        private void SubscribeBarColor()
        {
            _subscriptions += DB.StateStore<ColorItem>(Constants.SelectedColor).Subscribe(colorItem =>
                Dispatcher.BeginInvokeOnMainThread(() =>
                {
                    _nav.BarBackgroundColor = colorItem?.Color ?? Color.Default;
                }));
        }

        static App()
        {
            DB = new RealtimeLiteDatabase(Constants.DatabasePath);
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

        ~App()
        {
            _subscriptions.Dispose();
        }
    }
}

