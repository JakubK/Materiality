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
    /// <summary>
    /// Wykonaj kroki 1a lub 1b, a następnie 2, aby użyć tej kontrolki niestandardowej w pliku XAML.
    ///
    /// Krok 1a) Użycie tej kontrolki niestandardowej w pliku XAML, który istnieje w bieżącym projekcie.
    /// Dodaj ten atrybut XmlNamespace do głównego elementu pliku znaczników, gdzie jest 
    /// do użycia:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Materiality.WPF.Controls"
    ///
    ///
    /// Krok 1b) Użycie tej kontrolki niestandardowej w pliku XAML, który istnieje w innym projekcie.
    /// Dodaj ten atrybut XmlNamespace do głównego elementu pliku znaczników, gdzie jest 
    /// do użycia:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Materiality.WPF.Controls;assembly=Materiality.WPF.Controls"
    ///
    /// Należy również dodać odwołanie do projektu z projektu, w którym znajduje się plik XAML
    /// do tego projektu i skompiluj ponownie, aby uniknąć błędów kompilacji:
    ///
    ///     Kliknij prawym przyciskiem myszy docelowy projekt w Eksploratorze rozwiązań i
    ///     „Dodaj odwołanie”->„Projekty”->[Wyszukaj i wybierz ten projekt]
    ///
    ///
    /// Krok 2)
    /// Przejdź dalej i użyj swojego formantu w pliku XAML.
    ///
    ///     <MyNamespace:MaterialButton/>
    ///
    /// </summary>
    /// 
    public enum ButtonType
    {
        Raised,Flat,FloatingAction
    }

   
    public class MaterialButton : Button
    {
        public static readonly DependencyProperty ButtonTypeProperty = DependencyProperty.Register("ButtonType", typeof(ButtonType), typeof(MaterialButton),new PropertyMetadata(ButtonType.Raised));
        public ButtonType ButtonType
        {
            get { return (ButtonType)GetValue(ButtonTypeProperty); }
            set { SetValue(ButtonTypeProperty, value); }
           
        }

        public static readonly DependencyProperty HoverBrushProperty = DependencyProperty.Register("HoverBrush",typeof(Color),typeof(MaterialButton), new UIPropertyMetadata(Colors.White));
        public Color HoverBrush
        {
            get { return (Color)GetValue(HoverBrushProperty); }
            set { SetValue(HoverBrushProperty, value); }
        }

        public static readonly DependencyProperty RippleBrushProperty = DependencyProperty.Register("RippleBrush", typeof(Color), typeof(MaterialButton), new UIPropertyMetadata(Colors.White));
        public Color RippleBrush
        {
            get { return (Color)GetValue(RippleBrushProperty); }
            set { SetValue(RippleBrushProperty, value); }
        }

        static MaterialButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MaterialButton), new FrameworkPropertyMetadata(typeof(MaterialButton)));
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
