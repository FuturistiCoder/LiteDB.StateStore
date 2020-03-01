using LiteDB.StateStore;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Models;
using Xamarin.Forms;

namespace Todo.ViewModels
{
    internal class SettingsViewModel : ViewModelBase
    {
        public ColorItem[] Colors { get; } =
        { 
            new ColorItem
            {
                Name = "Blue",
                Color = Color.Blue
            },
            new ColorItem
            {
                Name = "Green",
                Color = Color.Green
            },
            new ColorItem
            {
                Name = "Red",
                Color = Color.Red
            }
        };

        private ColorItem _selectedColor = App.DB.StateStore<ColorItem>(Constants.SelectedColor).Get();
        public ColorItem SelectedColor
        { 
            get => _selectedColor;
            set
            {
                _selectedColor = value;
                App.DB.StateStore<ColorItem>(Constants.SelectedColor).Set(value);
                OnPropertyChanged();
            }
        }

        public string _selectedColorName;
        public string SelectedColorName
        {
            get => _selectedColorName;
            set
            {
                _selectedColorName = value;
                OnPropertyChanged();
            }
        }

        public SettingsViewModel()
        {
            SubscribeSelectedColor();
        }

        private void SubscribeSelectedColor()
        {
            App.DB.StateStore<ColorItem>(Constants.SelectedColor).Subscribe(colorItem =>
            {
                SelectedColorName = colorItem?.Name;
            });
        }
    }
}
