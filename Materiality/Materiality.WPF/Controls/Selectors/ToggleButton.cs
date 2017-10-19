using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Materiality.WPF.Controls
{
    public class ToggleButton : Button
    {
        public static readonly DependencyProperty HoverBrushProperty = DependencyProperty.Register("HoverBrush", typeof(Brush), typeof(ToggleButton), new UIPropertyMetadata(Brushes.White));
        public Brush HoverBrush
        {
            get { return (Brush)GetValue(HoverBrushProperty); }
            set { SetValue(HoverBrushProperty, value); }
        }

        public static readonly DependencyProperty RippleBrushProperty = DependencyProperty.Register("RippleBrush", typeof(Brush), typeof(ToggleButton), new UIPropertyMetadata(Brushes.White));
        public Brush RippleBrush
        {
            get { return (Brush)GetValue(RippleBrushProperty); }
            set { SetValue(RippleBrushProperty, value); }
        }

        public static readonly DependencyProperty CheckedBrushProperty = DependencyProperty.Register("CheckedBrush", typeof(Brush), typeof(ToggleButton), new UIPropertyMetadata(Brushes.Black));
        public Brush CheckedBrush
        {
            get { return (Brush)GetValue(CheckedBrushProperty); }
            set { SetValue(CheckedBrushProperty, value); }
        }

        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(ToggleButton), new FrameworkPropertyMetadata(false));
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        static ToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleButton), new FrameworkPropertyMetadata(typeof(ToggleButton)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.AddHandler(MouseDownEvent, new RoutedEventHandler((o, e) =>
            {
                IsChecked = !IsChecked;
            }), true);
        }
    }
}
