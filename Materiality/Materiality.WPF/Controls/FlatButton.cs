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
    public class FlatButton : Button
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(FlatButton), new PropertyMetadata("NEW BUTTON"));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty HoverBrushProperty = DependencyProperty.Register("HoverBrush", typeof(Brush), typeof(FlatButton), new UIPropertyMetadata(Brushes.LightGray));
        public Brush HoverBrush
        {
            get { return (Brush)GetValue(HoverBrushProperty); }
            set { SetValue(HoverBrushProperty, value); }
        }

        public static readonly DependencyProperty HoverTextBrushProperty = DependencyProperty.Register("HoverTextBrush", typeof(Brush), typeof(FlatButton), new UIPropertyMetadata(Brushes.Black));
        public Brush HoverTextBrush
        {
            get { return (Brush)GetValue(HoverTextBrushProperty); }
            set { SetValue(HoverTextBrushProperty, value); }
        }

        static FlatButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlatButton), new FrameworkPropertyMetadata(typeof(FlatButton)));
        }

    }
}
