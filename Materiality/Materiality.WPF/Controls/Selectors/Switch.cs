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
    public class Switch : CheckBox
    {
        static Switch()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Switch), new FrameworkPropertyMetadata(typeof(Switch)));
        }

        public static readonly DependencyProperty OffBackToggleBrushProperty = DependencyProperty.Register("OffBackToggleBrush", typeof(Brush), typeof(Switch), new UIPropertyMetadata(Brushes.White));
        public Brush OffBackToggleBrush
        {
            get { return (Brush)GetValue(OffBackToggleBrushProperty); }
            set { SetValue(OffBackToggleBrushProperty, value); }
        }



        public static readonly DependencyProperty OffFrontToggleBrushProperty = DependencyProperty.Register("OffFrontToggleBrush", typeof(Brush), typeof(Switch), new UIPropertyMetadata(Brushes.White));
        public Brush OffFrontToggleBrush
        {
            get { return (Brush)GetValue(OffFrontToggleBrushProperty); }
            set { SetValue(OffFrontToggleBrushProperty, value); }
        }

        public static readonly DependencyProperty OnBackToggleBrushProperty = DependencyProperty.Register("OnBackToggleBrush", typeof(Brush), typeof(Switch), new UIPropertyMetadata(Brushes.White));
        public Brush OnBackToggleBrush
        {
            get { return (Brush)GetValue(OnBackToggleBrushProperty); }
            set { SetValue(OnBackToggleBrushProperty, value); }
        }



        public static readonly DependencyProperty OnFrontToggleBrushProperty = DependencyProperty.Register("OnFrontToggleBrush", typeof(Brush), typeof(Switch), new UIPropertyMetadata(Brushes.White));
        public Brush OnFrontToggleBrush
        {
            get { return (Brush)GetValue(OnFrontToggleBrushProperty); }
            set { SetValue(OnFrontToggleBrushProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            storyboard = new Storyboard();
            toggle = GetTemplateChild("holder") as Grid;

            this.Click += Switch_Click;

        }

        public new static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(Switch), new FrameworkPropertyMetadata(false));
        public new bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        private Storyboard storyboard;
        Grid toggle;

        private bool canAnimate = true;

        private void Switch_Click(object sender, RoutedEventArgs e)
        {
            if (canAnimate)
            {
                IsChecked = !IsChecked;

                //Perform ToggleAnimation
                if (toggle != null)
                {
                    double desiredMargin;
                    canAnimate = false;
                    storyboard = new Storyboard();
                    storyboard.Completed += Storyboard_Completed;

                    if (IsChecked)
                    {
                        desiredMargin = this.ActualWidth - toggle.ActualWidth;
                        var toRight = new ThicknessAnimation
                        {
                            From = new Thickness(0, 0, 0, 0),
                            To = new Thickness(desiredMargin, 0, 0, 0),
                            Duration = TimeSpan.FromSeconds(0.5f),
                            BeginTime = TimeSpan.FromSeconds(0.0f)
                        };

                        storyboard.Children.Add(toRight);
                        Storyboard.SetTarget(toRight, toggle);
                        Storyboard.SetTargetProperty(toRight, new PropertyPath(FrameworkElement.MarginProperty));
                        storyboard.Begin();
                    }
                    else
                    {
                        desiredMargin = 0;
                        var toLeft = new ThicknessAnimation
                        {
                            From = new Thickness(toggle.Margin.Left, 0, 0, 0),
                            To = new Thickness(0, 0, 0, 0),
                            Duration = TimeSpan.FromSeconds(0.5f),
                            BeginTime = TimeSpan.FromSeconds(0.0f)
                        };

                        storyboard.Children.Add(toLeft);
                        Storyboard.SetTarget(toLeft, toggle);
                        Storyboard.SetTargetProperty(toLeft, new PropertyPath(FrameworkElement.MarginProperty));
                        storyboard.Begin();
                    }
                }
            }
            else
            {
                storyboard.Stop();
                storyboard.Begin();
            }
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            canAnimate = true;
        }
    }
}
