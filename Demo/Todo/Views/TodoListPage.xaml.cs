using LiteDB.StateStore;
using System;
using Todo.Models;
using Todo.Views;
using Xamarin.Forms;

namespace Todo.Views
{
    public partial class TodoListPage : ContentPage
    {
        private SubscriptionManager _subscriptions = new SubscriptionManager();
        public TodoListPage()
        {
            InitializeComponent();
            SubscribeTodoList();
            SubscribeSettingsState();
        }

        private void SubscribeSettingsState()
        {
            _subscriptions += App.DB.StateStore<ColorItem>(Constants.SelectedColor).Subscribe(colorItem =>
                    Dispatcher.BeginInvokeOnMainThread(() =>
                    {
                        HeaderColorLabel.Text = colorItem?.Name;
                    })
                );
        }

        private void SubscribeTodoList()
        {
            _subscriptions += App.DB.Realtime.Collection<TodoItem>("TodoItems").Subscribe(items =>
                Dispatcher.BeginInvokeOnMainThread(() =>
                {
                    listView.ItemsSource = items;
                })
            ); 
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem
                {
                    Id = Guid.NewGuid()
                }
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }

        ~TodoListPage()
        {
            _subscriptions.Dispose();
        }

        private async void GoSettings(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}
