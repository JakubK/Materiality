using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Materiality.WPF.Controls
{
    public class FloatingButton : Button
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(FloatingButton), new PropertyMetadata("NEW BUTTON"));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty HoverBrushProperty = DependencyProperty.Register("HoverBrush", typeof(Brush), typeof(FloatingButton), new UIPropertyMetadata(Brushes.LightGray));
        public Brush HoverBrush
        {
            get { return (Brush)GetValue(HoverBrushProperty); }
            set { SetValue(HoverBrushProperty, value); }
        }

        static FloatingButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FloatingButton), new FrameworkPropertyMetadata(typeof(FloatingButton)));
        }
    }
}
