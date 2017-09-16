﻿using Materiality.WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


//small        s   <= 600px
//medium       m   > 600px
//large        l   > 992px
//extra large  xl  > 1200px


namespace Materiality.WPF.Layouts
{
    /// <summary>
    /// Dynamic Grid for responsive content alignment
    /// </summary>
    public class MaterialityGrid : Grid
    {
        #region Fields
        public Func<FrameworkElement, int> GetCol;
        public Action<FrameworkElement, int> SetCol;

        public Func<FrameworkElement, int> GetOffset;
        public Action<FrameworkElement, int> SetOffset;

        protected const int MaxGridCount = 12;
        private List<MaterialityGridChildInfo> materialityGridInfos;

        #endregion

        #region Constructor
        public MaterialityGrid()
        {
            this.VerticalAlignment = VerticalAlignment.Top;
            this.HorizontalAlignment = HorizontalAlignment.Stretch;

            this.ColumnDefinitions.Clear();
            materialityGridInfos = new List<MaterialityGridChildInfo>();
           
            
            for(int i = 0;i < MaxGridCount;i++)
            {
                this.ColumnDefinitions.Add(new ColumnDefinition());
            }            
            this.SizeChanged += MaterialityGrid_SizeChanged;
            this.Loaded += MaterialityGrid_Loaded;
        }
        #endregion

        #region EventHandlers
        private void MaterialityGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ReFillMaterialityGrid();
        }
        
        private void MaterialityGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ReFillMaterialityGrid();
        }
        #endregion

        #region MaterialityGridChildInfo Helper Methods
        public MaterialityGridChildInfo GetInfo(FrameworkElement element)
        {
            if (materialityGridInfos == null || materialityGridInfos.Count == 0)
                 ReinitializeInfo();
            foreach(var info in materialityGridInfos)
            {
                if (info.TargetName == element.Name)
                    return info;
            }
            return null;
        }

        public void SetSM(FrameworkElement element,int sm)
        {
            GetInfo(element).SM = sm;
        }
        public void SetSM_Offset(FrameworkElement element, int offset)
        {
            GetInfo(element).SM_Offset = offset;
        }

        public void SetMD(FrameworkElement element, int md)
        {
            GetInfo(element).MD = md;
        }
        public void SetMD_Offset(FrameworkElement element, int offset)
        {
            GetInfo(element).MD_Offset = offset;
        }

        public void SetLG(FrameworkElement element, int lg)
        {
            GetInfo(element).LG = lg;
        }
        public void SetLG_Offset(FrameworkElement element, int offset)
        {
            GetInfo(element).LG_Offset = offset;
        }

        public void SetXL(FrameworkElement element, int xl)
        {
            GetInfo(element).XL = xl;
        }
        public void SetXL_Offset(FrameworkElement element, int offset)
        {
            GetInfo(element).XL_Offset = offset;
        }
        #endregion

        #region Filling Logic
        private void ReinitializeInfo()
        {
            materialityGridInfos = UIHelper.FindVisualChildren<MaterialityGridChildInfo>(this).ToList();
        }

        /// <summary>
        /// Gets the current Grid width, and the loops through each UserControl to arrange it
        /// </summary>
        private void ReFillMaterialityGrid()
        {
            if (materialityGridInfos == null)
                ReinitializeInfo();

            if (ActualWidth > 1200) //Extra Large
            {
                GetCol = (e) => GetInfo(e).XL;
                SetCol = (e, col) => SetXL(e, GetInfo(e).XL);

                GetOffset = (e) => GetInfo(e).XL_Offset;
                SetOffset = (e, col) => SetXL_Offset(e, GetInfo(e).XL_Offset);

            }
            else if (ActualWidth > 992) //Large
            {
                GetCol = (e) => GetInfo(e).LG;
                SetCol = (e, col) => SetLG(e, GetInfo(e).LG);

                GetOffset = (e) => GetInfo(e).LG_Offset;
                SetOffset = (e, col) => SetLG_Offset(e, GetInfo(e).LG_Offset);
            }
            else if (ActualWidth > 600) //Medium
            {
                GetCol = (e) => GetInfo(e).MD;
                SetCol = (e, col) => SetMD(e, GetInfo(e).MD);

                GetOffset = (e) => GetInfo(e).MD_Offset;
                SetOffset = (e, col) => SetMD_Offset(e, GetInfo(e).MD_Offset);
            }
            else if (ActualWidth <= 600)  //Small
            {
                GetCol = (e) => GetInfo(e).SM;
                SetCol = (e, col) => SetSM(e, GetInfo(e).SM);

                GetOffset = (e) => GetInfo(e).SM_Offset;
                SetOffset = (e, col) => SetSM_Offset(e, GetInfo(e).SM_Offset);
            }
            ArrangeChildren();
            return;
        }

        /// <summary>
        /// Fits single UIElement to the MaterialityGrid
        /// </summary>
        /// <param name="element"></param>
        private void ArrangeElement(UIElement element)
        {
        }

        /// <summary>
        /// Fits each UIElement to the MaterialityGrid using Column information
        /// </summary>
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
                if (!(Children[i] is MaterialityGridChildInfo))
                {
                    FrameworkElement element = (FrameworkElement)this.Children[i];
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
        #endregion
    }
}
