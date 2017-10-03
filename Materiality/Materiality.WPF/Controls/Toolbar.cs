using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Materiality.WPF.Controls
{
    public class Toolbar : ItemsControl
    {
        static Toolbar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Toolbar), new FrameworkPropertyMetadata(typeof(Toolbar)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
