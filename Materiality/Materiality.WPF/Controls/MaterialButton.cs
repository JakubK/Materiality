using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Materiality.WPF.Controls
{
    public enum ButtonType
    {
           FloatingAction,Raised,Flat
    }

    public class MaterialButton : Button
    {
       static MaterialButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MaterialButton),new FrameworkPropertyMetadata(typeof(MaterialButton)));
        }
    }
}
