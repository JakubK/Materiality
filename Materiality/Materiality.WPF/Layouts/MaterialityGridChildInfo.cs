using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Materiality.WPF.Layouts
{
    /// <summary>
    /// TODO:
    ///  - Make All Properties (including Target Control) available from both Xaml and C#
    ///  - Replace Current Grid Properties with MaterialityGridChildInfo Properties
    /// 
    ///  At start of an app, MaterialityGrid will look for every MaterialityGridChildInfo in Window, then It will assign them to it. These Infos will be used for retrieving
    ///  Column Data
    /// 
    /// </summary>
    public class MaterialityGridChildInfo : UIElement
    {
        #region ControlHandle
        /// <summary>
        /// Repair the Binding
        /// </summary>
        public string TargetName
        {
            get { return (string)GetValue(TargetNameProperty); }
            set { SetValue(TargetNameProperty, value); }
        }

        public static readonly DependencyProperty TargetNameProperty =
                  DependencyProperty.Register("TargetName", typeof(string), typeof(MaterialityGridChildInfo));
        #endregion
        #region Small
        public int SM
        {
            get { return (int)GetValue(SMProperty); }
            set { SetValue(SMProperty, value); }
        }
        public static readonly DependencyProperty SMProperty = DependencyProperty.Register("SM", typeof(int), typeof(MaterialityGridChildInfo));

        public int SM_Offset
        {
            get { return (int)GetValue(SM_OffsetProperty); }
            set { SetValue(SM_OffsetProperty, value); }
        }
        public static readonly DependencyProperty SM_OffsetProperty = DependencyProperty.Register("SM-Offset", typeof(int), typeof(MaterialityGridChildInfo));
        #endregion
        #region Medium
        public int MD
        {
            get { return (int)GetValue(MDProperty); }
            set { SetValue(MDProperty, value); }
        }
        public static readonly DependencyProperty MDProperty = DependencyProperty.Register("MD", typeof(int), typeof(MaterialityGridChildInfo));

        public int MD_Offset
        {
            get { return (int)GetValue(MD_OffsetProperty); }
            set { SetValue(MD_OffsetProperty, value); }
        }
        public static readonly DependencyProperty MD_OffsetProperty = DependencyProperty.Register("MD-Offset", typeof(int), typeof(MaterialityGridChildInfo));
        #endregion
        #region Large
        public int LG
        {
            get { return (int)GetValue(LGProperty); }
            set { SetValue(LGProperty, value); }
        }
        public static readonly DependencyProperty LGProperty = DependencyProperty.Register("LG", typeof(int), typeof(MaterialityGridChildInfo));

        public int LG_Offset
        {
            get { return (int)GetValue(LG_OffsetProperty); }
            set { SetValue(LG_OffsetProperty, value); }
        }
        public static readonly DependencyProperty LG_OffsetProperty = DependencyProperty.Register("LG-Offset", typeof(int), typeof(MaterialityGridChildInfo));
        #endregion
        #region ExtraLarge
        public int XL
        {
            get { return (int)GetValue(XLProperty); }
            set { SetValue(XLProperty, value); }
        }
        public static readonly DependencyProperty XLProperty = DependencyProperty.Register("XL", typeof(int), typeof(MaterialityGridChildInfo));

        public int XL_Offset
        {
            get { return (int)GetValue(XL_OffsetProperty); }
            set { SetValue(XL_OffsetProperty, value); }
        }
        public static readonly DependencyProperty XL_OffsetProperty = DependencyProperty.Register("XL-Offset", typeof(int), typeof(MaterialityGridChildInfo));
        #endregion
    }
}
