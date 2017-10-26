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
    /// <summary>
    /// Is meant to be aligned to top or bottom
    /// </summary>
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
