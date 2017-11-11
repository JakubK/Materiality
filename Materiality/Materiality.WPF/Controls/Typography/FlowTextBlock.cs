using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Materiality.WPF.Controls
{
    public class FlowTextBlock : ContentControl
    {
        static FlowTextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlowTextBlock), new FrameworkPropertyMetadata(typeof(FlowTextBlock)));
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(FlowTextBlock), new PropertyMetadata());
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}