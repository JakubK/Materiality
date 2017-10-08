using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.ComponentModel;
using Materiality.WPF.Classes.Icons;

namespace Materiality.WPF.Controls
{
    public class Icon : ContentControl
    {
        public Path IconPath; 

        static Icon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Icon), new FrameworkPropertyMetadata(typeof(Icon)));
        }

        public static readonly DependencyProperty IconTypeProperty = DependencyProperty.Register("Type", typeof(IconType), typeof(Icon), new FrameworkPropertyMetadata(IconType.AccessPoint));
        public IconType Type
        {
            get { return (IconType)GetValue(IconTypeProperty); }
            set { SetValue(IconTypeProperty, value); }
        }

        public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(Icon), new FrameworkPropertyMetadata(Brushes.Black));
        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        public Icon()
        {
            IconPath = new Path();
            //Path path = new Path();
            //string sData = "M 250,40 L200,20 L200,60 Z";
            //var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            //path.Data = (Geometry)converter.ConvertFrom(sData);
        }
    }
}
