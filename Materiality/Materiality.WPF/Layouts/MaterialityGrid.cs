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
        #endregion

        public MaterialityGrid()
        {
            this.VerticalAlignment = VerticalAlignment.Stretch;
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



        //Gets the current resolution and then loops through each control
        private void ReFillMaterialityGrid()
        {
            if (ActualWidth > 1200) //Extra Large
            {
                ArrangeExtraLargeSize();
                return;
            }
            if (ActualWidth > 992) //Large
            {
                ArrangeLargeSize();
                return;
            }
            if (ActualWidth > 600) //Medium
            {
                ArrangeMediumSize();
                return;
            }
            if (ActualWidth <= 600)  //Small
            {
                ArrangeSmallSize();
                return;
            }
        }

        private void ArrangeSmallSize()
        {
            this.RowDefinitions.Clear();
            int RemainingSpacePerCurrentRow = 12;
            int startCol = 0;
            int row = 0; //Current row
            for (int i = 0; i < this.Children.Count; i++)//Call for each existing UIElement in MaterialityGrid
            {
                UIElement element = this.Children[i];
                if (GetSColumn(element) > RemainingSpacePerCurrentRow) //Calculate if Control can fit the current row
                {
                    SetSColumn(element, RemainingSpacePerCurrentRow); //if not, change the desired size to available size
                }
                Grid.SetColumn(element, startCol);
                Grid.SetColumnSpan(element, GetSColumn(element));
                Grid.SetRow(element, row);
                startCol += GetSColumn(element);
                RemainingSpacePerCurrentRow -= GetSColumn(element);
                if (RemainingSpacePerCurrentRow == 0) //If the row is filled, create a new one for future (it will have 0 height until it will be needed)
                {
                    RowDefinition rowdefinition = new RowDefinition();
                    rowdefinition.Height = new GridLength(1.0, GridUnitType.Star);
                    this.RowDefinitions.Add(rowdefinition);
                    startCol = 0;
                    row++;
                    RemainingSpacePerCurrentRow = 12;
                }
            }
        }

        private void ArrangeMediumSize()
        {
            this.RowDefinitions.Clear();
            int RemainingSpacePerCurrentRow = 12;
            int startCol = 0;
            int row = 0; //Current row
            for (int i = 0; i < this.Children.Count; i++)//Call for each existing UIElement in MaterialityGrid
            {
                UIElement element = this.Children[i];
                if (GetMColumn(element) > RemainingSpacePerCurrentRow) //Calculate if Control can fit the current row
                {
                    SetMColumn(element, RemainingSpacePerCurrentRow); //if not, change the desired size to available size
                }
                Grid.SetColumn(element, startCol);
                Grid.SetColumnSpan(element, GetMColumn(element));
                Grid.SetRow(element, row);
                startCol += GetMColumn(element);
                RemainingSpacePerCurrentRow -= GetMColumn(element);
                if (RemainingSpacePerCurrentRow == 0) //If the row is filled, create a new one for future (it will have 0 height until it will be needed)
                {
                    RowDefinition rowdefinition = new RowDefinition();
                    rowdefinition.Height = new GridLength(1.0, GridUnitType.Star);
                    this.RowDefinitions.Add(rowdefinition);
                    startCol = 0;
                    row++;
                    RemainingSpacePerCurrentRow = 12;
                }
            }
        }

        private void ArrangeLargeSize()
        {
            this.RowDefinitions.Clear();
            int RemainingSpacePerCurrentRow = 12;
            int startCol = 0;
            int row = 0; //Current row
            for (int i = 0; i < this.Children.Count; i++)//Call for each existing UIElement in MaterialityGrid
            {
                UIElement element = this.Children[i];
                if (GetLColumn(element) > RemainingSpacePerCurrentRow) //Calculate if Control can fit the current row
                {
                    SetLColumn(element, RemainingSpacePerCurrentRow); //if not, change the desired size to available size
                }
                Grid.SetColumn(element, startCol);
                Grid.SetColumnSpan(element, GetLColumn(element));
                Grid.SetRow(element, row);
                startCol += GetLColumn(element);
                RemainingSpacePerCurrentRow -= GetLColumn(element);
                if (RemainingSpacePerCurrentRow == 0) //If the row is filled, create a new one for future (it will have 0 height until it will be needed)
                {
                    RowDefinition rowdefinition = new RowDefinition();
                    rowdefinition.Height = new GridLength(1.0, GridUnitType.Star);
                    this.RowDefinitions.Add(rowdefinition);
                    startCol = 0;
                    row++;
                    RemainingSpacePerCurrentRow = 12;
                }
            }
        }

        private void ArrangeExtraLargeSize()
        {
            this.RowDefinitions.Clear();
            int RemainingSpacePerCurrentRow = 12;
            int startCol = 0;
            int row = 0; //Current row
            for(int i = 0;i < this.Children.Count;i++)//Call for each existing UIElement in MaterialityGrid
            {
                UIElement element = this.Children[i];
                if (GetXLColumn(element) > RemainingSpacePerCurrentRow) //Calculate if Control can fit the current row
                {
                    SetXLColumn(element,RemainingSpacePerCurrentRow); //if not, change the desired size to available size
                }
                Grid.SetColumn(element, startCol);
                Grid.SetColumnSpan(element, GetXLColumn(element));
                Grid.SetRow(element, row);
                startCol += GetXLColumn(element);
                RemainingSpacePerCurrentRow -= GetXLColumn(element);
                if (RemainingSpacePerCurrentRow == 0) //If the row is filled, create a new one for future (it will have 0 height until it will be needed)
                {
                    RowDefinition rowdefinition = new RowDefinition();
                    rowdefinition.Height = new GridLength(1.0, GridUnitType.Star);
                    this.RowDefinitions.Add(rowdefinition);
                    startCol = 0;
                    row++;
                    RemainingSpacePerCurrentRow = 12;
                }
            }
        }
    }
}
