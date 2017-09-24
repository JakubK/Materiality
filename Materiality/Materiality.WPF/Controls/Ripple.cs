using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

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

        public static readonly DependencyProperty RippleColorProperty = DependencyProperty.Register("RippleColor", typeof(Color), typeof(Ripple), new FrameworkPropertyMetadata(Colors.White));
        public Color RippleColor
        {
            get { return (Color)GetValue(RippleColorProperty); }
            set { SetValue(RippleColorProperty, value); }
        }

        bool canAnimate = true;

        public void ScaleUpRipple()
        {
            if (canAnimate)
            {
                FrameworkElement parent = (FrameworkElement)this.Parent;
                if (parent != null)
                {
                    canAnimate = false;
                    var fade = new DoubleAnimation
                    {
                        From = 0,
                        To = parent.ActualWidth * 1.5f,
                        Duration = TimeSpan.FromSeconds(0.5f),
                        BeginTime = TimeSpan.FromSeconds(0f)
                    };
                    var fade1 = new DoubleAnimation
                    {
                        From = this.Opacity,
                        To = 0.0,
                        Duration = TimeSpan.FromSeconds(0.5f),
                        BeginTime = TimeSpan.FromSeconds(0f)
                    };

                    var sb = new Storyboard();

                    Storyboard.SetTarget(fade, this);
                    Storyboard.SetTargetProperty(fade, new PropertyPath(FrameworkElement.WidthProperty));

                    Storyboard.SetTarget(fade1, this);
                    Storyboard.SetTargetProperty(fade1, new PropertyPath(FrameworkElement.OpacityProperty));

                    sb.Children.Add(fade);
                    sb.Children.Add(fade1);

                    sb.Completed += ReverseOpacity;

                    fade.AutoReverse = true;
                    sb.Begin();
                }
            }
        }

        private void ReverseOpacity(object sender, EventArgs e)
        {
            var fade2 = new DoubleAnimation
            {
                From = this.Opacity,
                To = 1.0,
                Duration = TimeSpan.FromMilliseconds(1f),
                BeginTime = TimeSpan.FromMilliseconds(1f)
            };
            var sb = new Storyboard();

            Storyboard.SetTarget(fade2, this);
            Storyboard.SetTargetProperty(fade2, new PropertyPath(FrameworkElement.OpacityProperty));
            sb.Children.Add(fade2);
            sb.Completed += ToggleAnimation;
            sb.Begin();
        }

        private void ToggleAnimation(object sender, EventArgs e)
        {
            canAnimate = true;
        }
    }
}
