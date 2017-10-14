using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Materiality.WPF.Controls
{
    /// <summary>
    /// Sub-Element of MaterialButton that represents interaction with MaterialButton
    /// </summary>
    public class Ripple : ContentControl
    {
        static Ripple()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Ripple), new FrameworkPropertyMetadata(typeof(Ripple)));
        }

        public static readonly DependencyProperty RippleColorProperty = DependencyProperty.Register("RippleColor", typeof(Brush), typeof(Ripple), new FrameworkPropertyMetadata(Brushes.White));
        public Brush RippleColor
        {
            get { return (Brush)GetValue(RippleColorProperty); }
            set { SetValue(RippleColorProperty, value); }
        }

        Ellipse ellipse;
        Storyboard animation;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            ellipse = GetTemplateChild("ellipse") as Ellipse;
            animation = (GetTemplateChild("grid") as Grid).FindResource("anim") as Storyboard;

            this.AddHandler(MouseDownEvent, new RoutedEventHandler((sender, e) =>
             {
                 var targetWidth = Math.Max(DesiredSize.Width, DesiredSize.Height) * 2;
                 var mousePosition = (e as MouseButtonEventArgs).GetPosition(this);
                 var startMargin = new Thickness(mousePosition.X, mousePosition.Y, 0, 0);
                 ellipse.Margin = startMargin;

                 (animation.Children[0] as DoubleAnimation).To = targetWidth;
                 (animation.Children[1] as ThicknessAnimation).From = startMargin;
                 (animation.Children[1] as ThicknessAnimation).To = new Thickness(mousePosition.X - targetWidth / 2, mousePosition.Y - targetWidth / 2, 0, 0);
                 ellipse.BeginStoryboard(animation);
             }), true);
        }
    }
}
