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
    public class MaterialRadioButton : RadioButton
    {
        static MaterialRadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MaterialRadioButton), new FrameworkPropertyMetadata(typeof(MaterialRadioButton)));
        }

        public static readonly DependencyProperty RippleBrushProperty = DependencyProperty.Register("RippleBrush", typeof(Brush), typeof(MaterialRadioButton), new UIPropertyMetadata(Brushes.White));
        public Brush RippleBrush
        {
            get { return (Brush)GetValue(RippleBrushProperty); }
            set { SetValue(RippleBrushProperty, value); }
        }

        public static readonly DependencyProperty ActiveBrushProperty = DependencyProperty.Register("ActiveBrush", typeof(Brush), typeof(MaterialRadioButton), new UIPropertyMetadata(Brushes.Aqua));
        public Brush ActiveBrush
        {
            get { return (Brush)GetValue(ActiveBrushProperty); }
            set { SetValue(ActiveBrushProperty, value); }
        }

        public new static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(MaterialRadioButton), new FrameworkPropertyMetadata(false));
        public new bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.AddHandler(MouseDownEvent, new RoutedEventHandler((o, e) =>
            {
                this.IsChecked = !IsChecked;
            }), true);
        }
    }
}
