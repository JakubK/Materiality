using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Materiality.WPF.Controls.Navigation
{
    public enum SidebarOrientation
    {
        Left,Right
    }
    /// <summary>
    /// Is meant to be aligned to top or bottom
    /// </summary>
    public class Sidebar : ContentControl
    {
        static Sidebar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Sidebar), new FrameworkPropertyMetadata(typeof(Sidebar)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Enable = (GetTemplateChild("grid") as Border).FindResource("Show") as Storyboard;
            Disable = (GetTemplateChild("grid") as Border).FindResource("Hide") as Storyboard;

     
             this.Loaded += (o,e) =>
             {
                   this.Margin = GetAdjustedMargin(Orientation);
             };

        }


        Storyboard Enable;
        Storyboard Disable;


        public static readonly DependencyProperty ShadowDirectionProperty = DependencyProperty.Register("ShadowDirection", typeof(double), typeof(Sidebar), new FrameworkPropertyMetadata(-90.0));
        public double ShadowDirection
        {
            get { return (double)GetValue(ShadowDirectionProperty); }
            set { SetValue(ShadowDirectionProperty, value); }
        }

        public static readonly DependencyProperty BlurRadiusProperty = DependencyProperty.Register("BlurRadius", typeof(double), typeof(Sidebar), new FrameworkPropertyMetadata(10.0));
        public double BlurRadius
        {
            get { return (double)GetValue(BlurRadiusProperty); }
            set { SetValue(BlurRadiusProperty, value); }
        }

        public static readonly DependencyProperty ShadowDepthProperty = DependencyProperty.Register("ShadowDepth", typeof(double), typeof(Sidebar), new FrameworkPropertyMetadata(1.0));
        public double ShadowDepth
        {
            get { return (double)GetValue(ShadowDepthProperty); }
            set { SetValue(ShadowDepthProperty, value); }
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty,value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Sidebar), new PropertyMetadata());

        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(Sidebar), new FrameworkPropertyMetadata(false));
        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set
            {
                SetValue(IsActiveProperty, value);
                if(value == true)
                {
                    Enable.Begin();
                   // Debug.WriteLine("SHOW");
                }
                else
                {
                    Disable.Begin();
                  //  Debug.WriteLine("HIDE");
                }
            }
        }

        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(SidebarOrientation), typeof(Sidebar), new FrameworkPropertyMetadata(SidebarOrientation.Left));
        public SidebarOrientation Orientation
        {
            get { return (SidebarOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        Thickness GetAdjustedMargin(SidebarOrientation orientation)
        {
            if (orientation == SidebarOrientation.Left)
            {
                CornerRadius = new CornerRadius(2f, 0, 2f, 0);
                return new Thickness(-this.DesiredSize.Width-10, 0, 0, 0);
            }
            else
            {
                CornerRadius = new CornerRadius(0, 2f, 0, 2f);
                return new Thickness(0, 0, -this.DesiredSize.Width-10, 0);
            }
        }
    }
}
