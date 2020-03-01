using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Todo.Models
{
    public class ColorItem : IEquatable<ColorItem>
    {
        public string Name { get; set; }
        public Color Color { get; set; }

        public bool Equals(ColorItem other)
            => Color == other?.Color;
    }
}
