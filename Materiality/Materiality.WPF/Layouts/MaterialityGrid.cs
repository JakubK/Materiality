using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Materiality.WPF.Layouts
{
    public enum ColumnPrefix
    {
        Small,Medium,Large,ExtraLarge
    }
    /// <summary>
    /// Dynamic Grid for responsive content alignment
    /// </summary>
    public class MaterialityGrid : Grid
    {

        public Func<UIElement, int> GetCol;
        public Action<UIElement, int> SetCol;

        public Func<UIElement, int> GetOffset;
        public Action<UIElement, int> SetOffset;

        protected const int MaxGridCount = 12;

        //small        s   <= 600px
        //medium       m   > 600px
        //large        l   > 992px
        //extra large  xl  > 1200px

        #region Small Column
        public static readonly DependencyProperty SColumnProperty = DependencyProperty.RegisterAttached("SColumn", typeof(int), typeof(MaterialityGrid),new PropertyMetadata(1));
        public static void SetSColumn(UIElement element, int column)
        {
            element.SetValue(SColumnProperty, column);
        }
        public static int GetSColumn(UIElement element)
        {
            return (int)element.GetValue(SColumnProperty);
        }

        public static readonly DependencyProperty SOffsetProperty = DependencyProperty.RegisterAttached("SOffset", typeof(int), typeof(MaterialityGrid), new PropertyMetadata(0));
        public static void SetSOffset(UIElement element,int offset)
        {
            element.SetValue(SOffsetProperty, offset);
        }
        public static int GetSOffset(UIElement element)
        {
            return (int)element.GetValue(SOffsetProperty);
        }
        #endregion

        #region Medium Column
        public static readonly DependencyProperty MColumnProperty = DependencyProperty.RegisterAttached("MColumn", typeof(int), typeof(MaterialityGrid), new PropertyMetadata(1));
        public static void SetMColumn(UIElement element, int column)
        {
            element.SetValue(MColumnProperty, column);
        }
        public static int GetMColumn(UIElement element)
        {
            return (int)element.GetValue(MColumnProperty);
        }

        public static readonly DependencyProperty MOffsetProperty = DependencyProperty.RegisterAttached("MOffset", typeof(int), typeof(MaterialityGrid), new PropertyMetadata(0));
        public static void SetMOffset(UIElement element, int offset)
        {
            element.SetValue(MOffsetProperty, offset);
        }
        public static int GetMOffset(UIElement element)
        {
            return (int)element.GetValue(MOffsetProperty);
        }
        #endregion

        #region Large Column
        public static readonly DependencyProperty LColumnProperty = DependencyProperty.RegisterAttached("LColumn", typeof(int), typeof(MaterialityGrid), new PropertyMetadata(1));
        public static void SetLColumn(UIElement element, int column)
        {
            element.SetValue(LColumnProperty, column);
        }
        public static int GetLColumn(UIElement element)
        {
            return (int)element.GetValue(LColumnProperty);
        }

        public static readonly DependencyProperty LOffsetProperty = DependencyProperty.RegisterAttached("LOffset", typeof(int), typeof(MaterialityGrid), new PropertyMetadata(0));
        public static void SetLOffset(UIElement element, int offset)
        {
            element.SetValue(LOffsetProperty, offset);
        }
        public static int GetLOffset(UIElement element)
        {
            return (int)element.GetValue(LOffsetProperty);
        }
        #endregion

        #region Extra-Large Column
        public static readonly DependencyProperty XLColumnProperty = DependencyProperty.RegisterAttached("XLColumn", typeof(int), typeof(MaterialityGrid), new PropertyMetadata(1));
        public static void SetXLColumn(UIElement element, int column)
        {
            element.SetValue(XLColumnProperty, column);
        }
        public static int GetXLColumn(UIElement element)
        {
            return (int)element.GetValue(XLColumnProperty);
        }

        public static readonly DependencyProperty XLOffsetProperty = DependencyProperty.RegisterAttached("XLOffset", typeof(int), typeof(MaterialityGrid), new PropertyMetadata(0));
        public static void SetXLOffset(UIElement element, int offset)
        {
            element.SetValue(XLOffsetProperty, offset);
        }
        public static int GetXLOffset(UIElement element)
        {
            return (int)element.GetValue(XLOffsetProperty);
        }
        #endregion

        public MaterialityGrid()
        {
            this.VerticalAlignment = VerticalAlignment.Top;
            this.HorizontalAlignment = HorizontalAlignment.Stretch;

            this.ColumnDefinitions.Clear();
            
            for(int i = 0;i < MaxGridCount;i++)
            {
                this.ColumnDefinitions.Add(new ColumnDefinition());
            }            
            this.SizeChanged += MaterialityGrid_SizeChanged;
            this.Loaded += MaterialityGrid_Loaded;
            ReFillMaterialityGrid();
        }

        private void MaterialityGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ReFillMaterialityGrid();
        }
        
        private void MaterialityGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ReFillMaterialityGrid();
        }

        /// <summary>
        /// Gets the current Grid width, and the loops through each UserControl to arrange it
        /// </summary>
        private void ReFillMaterialityGrid()
        {
            if (ActualWidth > 1200) //Extra Large
            {
                GetCol = (e) => GetXLColumn(e);
                SetCol = (e, col) => SetXLColumn(e, col);

                GetOffset = (e) => GetXLOffset(e);
                SetOffset = (e,offset) => SetXLOffset(e,offset);

            }
            else if (ActualWidth > 992) //Large
            {
                GetCol = (e) => GetLColumn(e);
                SetCol = (e, col) => SetLColumn(e, col);

                GetOffset = (e) => GetLOffset(e);
                SetOffset = (e, offset) => SetLOffset(e, offset);
            }
            else if (ActualWidth > 600) //Medium
            {
                GetCol = (e) => GetMColumn(e);
                SetCol = (e, col) => SetMColumn(e, col);

                GetOffset = (e) => GetMOffset(e);
                SetOffset = (e, offset) => SetMOffset(e, offset);
            }
            else if (ActualWidth <= 600)  //Small
            {
                GetCol = (e) => GetSColumn(e);
                SetCol = (e, col) => SetSColumn(e, col);

                GetOffset = (e) => GetSOffset(e);
                SetOffset = (e, offset) => SetSOffset(e, offset);
            }
            ArrangeChildren();
            return;
        }

        private void ArrangeChildren()
        {
            if (RowDefinitions.Count == 0)
            {
                this.RowDefinitions.Add(new RowDefinition());
            }
            int RemainingSpacePerCurrentRow = MaxGridCount;
            int startCol = 0; //Current column in a loop
            int row = 0; //Current row in a loop
            for (int i = 0; i < this.Children.Count; i++)//Call for each existing UIElement in MaterialityGrid
            {
                UIElement element = this.Children[i];
                if (GetCol(element) + GetOffset(element) > RemainingSpacePerCurrentRow) //Calculate if Control with it's offset can fit the current row
                {
                    SetOffset(element, 0);
                    SetCol(element, RemainingSpacePerCurrentRow); //if not, change the desired size to available size, and set offset to 0
                }
                Grid.SetColumn(element, startCol + GetOffset(element));
                Grid.SetColumnSpan(element, GetCol(element));
                Grid.SetRow(element, row);
                startCol += GetCol(element) + GetOffset(element);
                RemainingSpacePerCurrentRow -= (GetCol(element) + GetOffset(element));
                if (RemainingSpacePerCurrentRow == 0) //If the row is filled, create a new one for future (it will have 0 height until it will be needed)
                {
                    this.RowDefinitions.Add(new RowDefinition());
                    startCol = 0;
                    row++;
                    RemainingSpacePerCurrentRow = MaxGridCount;
                }
            }
        } 
    }
}
