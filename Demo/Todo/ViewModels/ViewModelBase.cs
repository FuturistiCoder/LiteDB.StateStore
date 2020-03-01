using LiteDB.StateStore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Todo.ViewModels
{
    internal abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected SubscriptionManager Subscriptions { get; } = new SubscriptionManager();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ~ViewModelBase()
        {
            Subscriptions.Dispose();
        }
    }
}
