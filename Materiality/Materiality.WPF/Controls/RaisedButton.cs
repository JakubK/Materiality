using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Materiality.WPF.Controls
{
    public class RaisedButton : Button
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(RaisedButton), new PropertyMetadata("NEW BUTTON"));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty HoverBrushProperty = DependencyProperty.Register("HoverBrush",typeof(Brush),typeof(RaisedButton), new UIPropertyMetadata(Brushes.White));
        public Brush HoverBrush
        {
            get { return (Brush)GetValue(HoverBrushProperty); }
            set { SetValue(HoverBrushProperty, value); }
        }

        public static readonly DependencyProperty RippleBrushProperty = DependencyProperty.Register("RippleBrush", typeof(Brush), typeof(RaisedButton), new UIPropertyMetadata(Brushes.White));
        public Brush RippleBrush
        {
            get { return (Brush)GetValue(RippleBrushProperty); }
            set { SetValue(RippleBrushProperty, value); }
        }

        static RaisedButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RaisedButton), new FrameworkPropertyMetadata(typeof(RaisedButton)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.Click += MaterialButton_Click;
        }

        private void MaterialButton_Click(object sender, RoutedEventArgs e)
        {
            Ripple ripple = GetTemplateChild("Ripple") as Ripple;
            ripple.ScaleUpRipple();
        }
    }
}
